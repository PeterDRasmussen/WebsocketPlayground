using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace WebsocketPlaygroundChat.Websocket
{
    public interface IWebsocketHandler
    {
        Task Handle(Guid id, WebSocket websocket);
    }
}