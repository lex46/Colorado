using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Auth.HtmlHelpers
{
    public static class HtmlUserCustomForm
    {
        public static string Show(string target, string text, object[] values)
        {
            var resultContent = (values == null) ?
                 GetEmptyFormContent(text) : GetFullFormContent(text, values);

            return String.Format("<div class=\"user-form\" for='{0}'>{1}</div>", target, resultContent);
        }

        private static string GetEmptyFormContent(string text)
        {
            var matches = Regex.Matches(text, @"\{\d\}");
            var emptyForm = text;

            foreach (Match match in matches)
            {
                emptyForm = emptyForm.Replace(match.Captures[0].Value, string.Empty);
            }

            return emptyForm;
        }
        private static string GetFullFormContent(string text, object[] values)
        {
            return string.Format(text, values);
        }
    }

}