using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;


namespace Intertravel.Utility
{
   
    public static class DateTimeEditorExtensions
    {
        private static string datetype = "Date";
        private static string datetimetype = "DateTime";
        public static MvcHtmlString DateFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.EditorFor(expression, datetype);
        }
        public static MvcHtmlString DateFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object additionalViewData)
        {
            return html.EditorFor(expression, datetype, additionalViewData);
        }
        public static MvcHtmlString DateTimeFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.EditorFor(expression, datetimetype);
        }
        public static MvcHtmlString DateTimeFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object additionalViewData)
        {
            return html.EditorFor(expression, datetimetype, additionalViewData);
        }

        public class MyDateTimeModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                string key = bindingContext.ModelName;
                ValueProviderResult result = bindingContext.ValueProvider.GetValue(key);

                if (result != null)
                {
                    return result.ConvertTo(typeof(DateTime), CultureInfo.CurrentCulture);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}