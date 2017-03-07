using System.Web.Mvc;

namespace Nik.Advanced.Web.Core.Extensions
{
    public static class HtmlExtension
    {
        public static MvcHtmlString Br(this HtmlHelper helper)
        {
            var builder = new TagBuilder("br");
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}
