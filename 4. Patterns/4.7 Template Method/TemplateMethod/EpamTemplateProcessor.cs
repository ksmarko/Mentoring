using System.Linq;

namespace TemplateMethod
{
    public class EpamTemplateProcessor : TemplateProcessor
    {
        private const string Domain = "@epam.com";
        private const string CorporateName = "Epam";

        public EpamTemplateProcessor(Template template) : base(template)
        {
        }

        protected override bool UserHasAccess()
        {
            return EpamUsersStorage.HasUser(Template.UserName);
        }

        protected override bool IsEmailsCorrect()
        {
            return Template.Emails.All(x => x.EndsWith(Domain));
        }

        protected override bool IsAllEmailsRegistered()
        {
            return Template.Emails.All(EpamUsersStorage.HasUserWithEmail);
        }

        protected override bool HasCorrectContent()
        {
            return !string.IsNullOrEmpty(Template.Content) &&
                Template.Content.StartsWith(CorporateName);
        }

        protected override bool HasCorrectVariables()
        {
            return Template.Variables.Values.All(x => !string.IsNullOrEmpty(x)) &&
                   Template.Variables.ContainsKey(CorporateName);
        }
    }
}
