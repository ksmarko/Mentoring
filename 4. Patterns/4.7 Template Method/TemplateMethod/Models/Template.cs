using System.Collections.Generic;

namespace TemplateMethod
{
    public class Template
    {
        public List<string> Emails { get; set; }
        public Dictionary<string, string> Variables { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
    }
}
