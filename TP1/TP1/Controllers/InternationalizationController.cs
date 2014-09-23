namespace TP1.Controllers
{
    using System;
    using System.Web.Mvc;

    public class InternationalizationController : Controller
    {
        public string GetLanguage(string language)
        {
            return System.IO.File.ReadAllText(Server.MapPath(String.Format("~/Scripts/Internationalization/{0}.js", language)));
        }
    }
}
