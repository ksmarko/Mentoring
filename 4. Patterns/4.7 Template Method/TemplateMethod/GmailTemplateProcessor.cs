using System.Linq;

namespace TemplateMethod
{
    public class GmailTemplateProcessor : TemplateProcessor
    {
        private const string Domain = "gmail.com";
        private const string CorporateName = "Gmail";

        public GmailTemplateProcessor(Template template) : base(template)
        {
        }

        protected override bool UserHasAccess()
        {
            return !string.IsNullOrEmpty(Template.UserName);
        }

        protected override bool IsEmailsCorrect()
        {
            return Template.Emails.All(x => x.EndsWith(Domain));
        }

        protected override bool IsAllEmailsRegistered()
        {
            return true;
        }

        protected override bool HasCorrectContent()
        {
            return !string.IsNullOrEmpty(Template.Content);
        }

        protected override bool HasCorrectVariables()
        {
            return Template.Variables.Values.All(x => !string.IsNullOrEmpty(x)) && 
                   Template.Variables.ContainsKey(CorporateName);
        }
    }
}
