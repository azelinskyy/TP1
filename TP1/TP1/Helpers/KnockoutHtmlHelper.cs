// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnockoutHtmlHelper.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The knockout html helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TP1.Helpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    /// <summary>
    /// The knockout html helper.
    /// </summary>
    public static class KnockoutHtmlHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// The knockout helper for.
        /// </summary>
        public static MvcHtmlString KnockoutHelperForValidationError<TModel>(this HtmlHelper<TModel> helper, string propertyName, string errorName)
        {
            return new MvcHtmlString(string.Format("<p data-bind=\"validationMessage: {0}, text: langModule().language().{1} \"></p>", propertyName, errorName));   
        }

        /// <summary>
        /// The knockout helper for.
        /// </summary>
        public static MvcHtmlString KnockoutHelperFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string tagName = "label")
        {
            string propertyName = ModelMetadata.FromLambdaExpression(expression, helper.ViewData).PropertyName;

            return Tag(propertyName, tagName);
        }

        /// <summary>
        /// The knockout helper for.
        /// </summary>
        public static MvcHtmlString KnockoutHelperFor(this HtmlHelper helper, string name, string tagName = "label", string additionBinders = "")
        {
            return Tag(name, tagName, additionBinders);
        }

        /// <summary>
        /// The knockout helper for.
        /// </summary>
        public static MvcHtmlString KnockoutHelperFor(this HtmlHelper helper, string name, string tagName = "label", string additionBinders = "", params string[] values)
        {
            return Tag(name, tagName, additionBinders, values);
        }

        /// <summary>
        /// The knockout helper for button.
        /// </summary>
        public static MvcHtmlString KnockoutHelperForButton(this HtmlHelper helper, string name, string additionBinders, string classes)
        {
            return Tag(name, "button", additionBinders, classes);
        }

        /// <summary>
        /// The tag.
        /// </summary>
        public static MvcHtmlString Tag(string name, string tagName, string additionBinders = "", string classes = "")
        {
            var tag = new TagBuilder(tagName);
            if (additionBinders != string.Empty)
            {
                additionBinders = ", " + additionBinders;
            }

            if (!string.IsNullOrEmpty(classes))
            {
                foreach (string c in classes.Split(' '))
                {
                    tag.AddCssClass(c);
                }
            }

            tag.Attributes.Add("data-bind", string.Format("text: langModule().language().{0}{1}", name, additionBinders));

            return new MvcHtmlString(tag.ToString());
        }

        /// <summary>
        /// The tag.
        /// </summary>
        public static MvcHtmlString Tag(string name, string tagName, string additionBinders = "", params string[] values)
        {
            var tag = new TagBuilder(tagName);
            if (additionBinders != string.Empty)
            {
                additionBinders = ", " + additionBinders;
            }

            tag.Attributes.Add(
                "data-bind",
                string.Format("text: String.format(langModule().language().{0}{1},{2})", name, additionBinders, string.Join(", ", values)));
            return new MvcHtmlString(tag.ToString());
        }

        #endregion
    }
}