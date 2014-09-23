namespace System.Web.Mvc.Html
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    public static class KnockoutHtmlHelper
    {
        public static MvcHtmlString KnockoutHelperFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string tagName = "label")
        {
            string propertyName = ModelMetadata.FromLambdaExpression(expression, helper.ViewData).PropertyName;
 
            return Tag(propertyName, tagName);
        }

        public static MvcHtmlString KnockoutHelperFor(this HtmlHelper helper, string name, string tagName = "label")
        {
            return Tag(name, tagName);
        }

        public static MvcHtmlString Tag(string name, string tagName = "label")
        {
            var tag = new TagBuilder(tagName);
            tag.Attributes.Add("data-bind", String.Format("text: language().{0}", name));

            return new MvcHtmlString(tag.ToString());
        }
    }
}