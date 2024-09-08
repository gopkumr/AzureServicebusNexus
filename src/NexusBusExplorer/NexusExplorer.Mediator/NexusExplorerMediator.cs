using NexusExplorer.Mediator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NexusExplorer.Mediator
{
    public sealed class NexusExplorerMediator
    {
        private readonly IEnumerable<INexusExplorerRequestHandler<INexusExplorerRequest, INexusExplorerResponse>> _requestHandlers;
        private readonly IEnumerable<INexusExplorerCommandHandler<INexusExplorerRequest>> _commandHandlers;
        private readonly Channel<INexusExplorerRequest> _channel;
        private readonly ChannelWriter<INexusExplorerRequest> _channelWriter;

        public NexusExplorerMediator(IEnumerable<INexusExplorerRequestHandler<INexusExplorerRequest, INexusExplorerResponse>> requestHandlers,
                                     IEnumerable<INexusExplorerCommandHandler<INexusExplorerRequest>> commandHandlers,
                                     Channel<INexusExplorerRequest>? channel = null)
        {
            _requestHandlers = requestHandlers;
            _commandHandlers = commandHandlers;

            if (channel != null)
                _channel = channel;
            else
                _channel = Channel.CreateBounded<INexusExplorerRequest>(new BoundedChannelOptions(10)
                {
                    SingleWriter = true,
                    SingleReader = false
                });

            _channelWriter = _channel.Writer;
            InitiatiateChannelReaders(5);
        }

        public async Task<INexusExplorerResponse> HandleRequest(INexusExplorerRequest request)
        {
            var handler = _requestHandlers.FirstOrDefault(q => q.CanHandle(request));

            if (handler == null)
            {
                throw new Exceptions.NexusExplorerMediatorException($"No handler found for the request {request.GetType().Name}");
            }

            return await handler.Handle(request);
        }

        public async Task HandleCommand(INexusExplorerRequest request)
        {
            await _channelWriter.WriteAsync(request);
            _channelWriter.Complete();
        }

        private void InitiatiateChannelReaders(int count)
        {
            var allReaders = Enumerable.Range(0, count).Select(q => Task.Run(async () =>
              {
                  var channelReader = _channel.Reader;
                  await foreach (var request in channelReader.ReadAllAsync())
                  {
                      var handlers = _commandHandlers.Where(q => q.CanHandle(request));
                      if (handlers.Any())
                      {
                          foreach (var handler in handlers)
                              await handler.Handle(request);
                      }

                  }
              }));
        }
    }
}
