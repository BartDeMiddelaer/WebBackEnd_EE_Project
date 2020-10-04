using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wba.EE.DeMiddelaerBart.Web.Models;
using static Wba.EE.DeMiddelaerBart.Web.DataServices;


namespace Wba.EE.DeMiddelaerBart.Web.Controllers
{
    public class PlayController : Controller
    {
        readonly HttpContext curentHttpContent;

        public PlayController(IHttpContextAccessor httpContextAccessor) => curentHttpContent = httpContextAccessor.HttpContext;           
        
        public IActionResult Index() => View( new PlayerViewModel { 
                ShowThisDeck = GetUser(curentHttpContent).PlayDeck
        });
               
    }
}