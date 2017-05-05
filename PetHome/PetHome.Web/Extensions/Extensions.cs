using System.Web.Mvc;

namespace PetHome.Web.Extensions
{
    public static class Extensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string path, string alt)
        {
            TagBuilder builder = new TagBuilder("img");

            builder.MergeAttribute("src", path);
            builder.MergeAttribute("alt", alt);

            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string path, string alt, int width, int height)
        {
            TagBuilder builder = new TagBuilder("img");

            builder.AddCssClass("img-rounded");
            builder.MergeAttribute("src", path);
            builder.MergeAttribute("alt", alt);

            builder.MergeAttribute("style", $"width: {width}px; height: {height}px");


            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }
    }
}