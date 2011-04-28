
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public static class sArtExtensions
    {
        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper html, string imgSrc, string action, [Optional, DefaultParameterValue(null)] IEnumerable<object> parameters, [Optional, DefaultParameterValue(null)] object imgHtmlAttributes, [Optional, DefaultParameterValue(null)] string controller)
        {

            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            TagBuilder imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgSrc);
            if (imgHtmlAttributes != null)
            {
                imgTagBuilder.MergeAttributes<string, string>(imgHtmlAttributes.GetDictionary());
            }
            string img = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            string url = urlHelper.Action(action, controller, BuildRouteValueDictionary(parameters));

            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = img
            };
            tagBuilder.MergeAttribute("href", url);

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        internal static IDictionary<string, string> GetDictionary(this object source)
        {
            if (source == null)
            {
                return null;
            }
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(source);
            Dictionary<string, string> d = new Dictionary<string, string>();
            for (int i = 0; i < props.Count; i++)
            {
                d.Add(props[i].Name, props[i].GetValue(source).ToString());
            }
            return d;
        }

        internal static RouteValueDictionary BuildRouteValueDictionary([Optional, DefaultParameterValue(null)] IEnumerable<object> parameters)
        {
            RouteValueDictionary rvd = new RouteValueDictionary();
            foreach (object parameter in parameters)
            {
                rvd.Add("id", parameter);
            }

            return rvd;
        }

    }
}
