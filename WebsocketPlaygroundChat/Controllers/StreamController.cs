using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebsocketPlaygroundChat.Websocket;

namespace MyApplication.Controllers
{
    [Route("api/[controller]")]
    public class StreamController : Controller
    {
        public IWebsocketHandler WebsocketHandler { get; }

        public StreamController(IWebsocketHandler websocketHandler)
        {
            WebsocketHandler = websocketHandler;
        }


        [HttpGet]
        public async Task Get()
        {

            var context = ControllerContext.HttpContext;
            var isSocketRequest = context.WebSockets.IsWebSocketRequest;

            if (isSocketRequest)
            {
                WebSocket websocket = await context.WebSockets.AcceptWebSocketAsync();

                await WebsocketHandler.Handle(Guid.NewGuid(), websocket);
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }
    }
}
