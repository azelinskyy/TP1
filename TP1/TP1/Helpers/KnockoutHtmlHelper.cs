namespace System.Web.Mvc.Html
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    public static class KnockoutHtmlHelper
    {
        public static MvcHtmlString KnockoutHelperFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string tagName = "label")
        {
            string propertyName = ModelMetadata.FromLambdaExpression(expression, helper.ViewData).PropertyName;

            return Tag(propertyName, tagName);
        }

        public static MvcHtmlString KnockoutHelperFor(this HtmlHelper helper, string name, string tagName = "label", string additionBinders = "")
        {
            return Tag(name, tagName, additionBinders);
        }

        public static MvcHtmlString KnockoutHelperFor(this HtmlHelper helper, string name, string tagName = "label", string additionBinders = "", params string[] values)
        {
            return Tag(name, tagName, additionBinders, values);
        }

        public static MvcHtmlString Tag(string name, string tagName, string additionBinders = "")
        {
            var tag = new TagBuilder(tagName);
            if (additionBinders != string.Empty)
            {
                additionBinders = ", " + additionBinders;
            }

            tag.Attributes.Add("data-bind", String.Format("text: language().{0}{1}", name, additionBinders));
            return new MvcHtmlString(tag.ToString());
        }

        public static MvcHtmlString Tag(string name, string tagName, string additionBinders = "", params string[] values)
        {
            var tag = new TagBuilder(tagName);
            if (additionBinders != string.Empty)
            {
                additionBinders = ", " + additionBinders;
            }

            tag.Attributes.Add("data-bind", String.Format("text: String.format(language().{0}{1},{2})", name, additionBinders, string.Join(", ", values)));
            return new MvcHtmlString(tag.ToString());
        }

        public static MvcHtmlString KnockoutHelperForButton(this HtmlHelper helper, string name, string additionBinders)
        {
            return Tag(name, "button", additionBinders);
        }
    }
}