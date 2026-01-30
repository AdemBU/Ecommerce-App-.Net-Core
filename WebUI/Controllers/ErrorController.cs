using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Aradığınız sayfa bulunamadı!";
                    break;
                case 403:
                    ViewBag.ErrorMessage = "Bu sayfaya erişim yetkiniz bulunmuyor.";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Sunucu tarafında bir hata oluştu.";
                    break;
                default:
                    ViewBag.ErrorMessage = "Bir şeyler ters gitti.";
                    break;
            }

            return View("ErrorPage", statusCode);
        }
    }
}
