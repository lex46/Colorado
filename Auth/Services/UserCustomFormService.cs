using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace Auth.Services
{
    public class UserCustomFormService
    {
        private static Dictionary<string, string> forms;

        static UserCustomFormService()
        {
            Init();
        }

        public UserCustomFormService()
        {
            Init();
        }
        private static void Init()
        {
            forms = GetForms();
        }
        private static Dictionary<string, string> GetForms()
        {
            var formsList = new Dictionary<string, string>();
            string[] fileEntries = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/UserForms"), "*.html");

            for (var i = 0; i < fileEntries.Length; i++)
            {
                var name = ResolveName(fileEntries[i]);
                var form = GetForm(fileEntries[i]);
                formsList.Add(name, form);
            }
            return formsList;
        }

        private static string ResolveName(string fileEntry)
        {
            var match = Regex.Match(fileEntry, @"([^\\]+)\.html", RegexOptions.RightToLeft);
            return match.Groups[1].Value;
        }
        private static string GetForm(string path)
        {
            var content = string.Empty;

            using (StreamReader sr = File.OpenText(path))
            {
                content = sr.ReadToEnd();
            }

            return content;
        }
        public Dictionary<string, string> All()
        {
            return forms;
        }
    }
}