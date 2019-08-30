using Boardgamesleeves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Boardgamesleeves.HtmlHelpers
{
    public static class SideopdelingHjaelper
    {
        // PageLinks extension method (from the HtmlHelper class) generates the HTML for a set of page links
        // using the information provided in a PagingInfo object
        // Func parameter accepts a delegate that it uses to generate the links to view other pages
        // Also adds CSS classes that styles buttons and makes it possible to see where you are with "selected"
        public static MvcHtmlString SideLinks(this HtmlHelper html, SideopdelingsInfo sideopdelingsInfo, Func<int, string> sideUrl)
        {
            StringBuilder resultat = new StringBuilder();
            for (int i = 1; i <= sideopdelingsInfo.TotaleSider; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", sideUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == sideopdelingsInfo.NuvaerendeSide)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-default");
                resultat.Append(tag.ToString());
            }

            return MvcHtmlString.Create(resultat.ToString());
        }
    }
}