namespace TP1.Binders
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Tools.Export;

    public class ExportConfigurationBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
            if (bindingContext.ModelType == typeof(ExportConfiguration) && request.HttpMethod.ToUpper().Equals("GET") && request.QueryString.Count != 0)
            {
                var config = new ExportConfiguration
                                 {
                                     Culture = request.QueryString.Get("Culture"),
                                     From = DateTime.Parse(request.QueryString.Get("From")),
                                     To = DateTime.Parse(request.QueryString.Get("To")),
                                     Model = (ReportModels)Enum.Parse(typeof(ReportModels), request.QueryString.Get("Model")),
                                     UnselectedIds = request.QueryString.AllKeys.Contains("UnselectedIds[]") 
                                        ? request.QueryString.Get("UnselectedIds[]").Split(',').Select(int.Parse).ToList() 
                                        : null
                                 };

                return config;
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}