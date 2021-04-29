using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Mai.SalaryComputation.Infrastructure.Extensions
{
    public static class HtmlDocumentExtensions
    {
        private static readonly Regex NumberRegex = new Regex("[^0-9]+", RegexOptions.Compiled);

        public static int? GetNumberOrDefault(this HtmlDocument htmlDocument, string xpath, bool removeOtherChars = true)
        {
            return htmlDocument.DocumentNode.GetNumberOrDefault(xpath, removeOtherChars);
        }

        public static int? GetNumberOrDefault(this HtmlNode htmlDocument, string xpath, bool removeOtherChars = true)
        {
            var str = htmlDocument.GetStringOfDefault(xpath);

            if (removeOtherChars)
            {
                str = NumberRegex.Replace(str, string.Empty);
            }

            return int.TryParse(str, out var number) ? number : (int?) null;
        }

        public static string GetStringOfDefault(this HtmlDocument htmlDocument, string xpath)
        {
            return htmlDocument?.DocumentNode?.GetStringOfDefault(xpath) ?? string.Empty;
        }

        public static string GetStringOfDefault(this HtmlNode htmlDocument, string xpath)
        {
            return WebUtility.HtmlDecode(htmlDocument?.SelectSingleNode(xpath)?.InnerText ?? string.Empty);
        }

        public static ICollection<string> GetCollectionOfChildElements(this HtmlDocument htmlDocument, string xpath)
        {
            return htmlDocument?.DocumentNode?.SelectSingleNode(xpath)
                ?.ChildNodes
                ?.Select(x => WebUtility.HtmlDecode(x?.InnerText ?? string.Empty))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList() ?? new List<string>();
        }
    }
}