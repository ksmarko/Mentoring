using System;

namespace TemplateMethod
{
    public abstract class TemplateProcessor
    {
        protected Template Template;

        protected abstract bool UserHasAccess();
        protected abstract bool IsEmailsCorrect();
        protected abstract bool IsAllEmailsRegistered();
        protected abstract bool HasCorrectContent();
        protected abstract bool HasCorrectVariables();

        protected TemplateProcessor(Template template)
        {
            Template = template;
        }

        public void Process()
        {
            if (!UserHasAccess())
            {
                Console.WriteLine("Access denied");
                return;
            }

            if (!IsEmailsCorrect())
            {
                Console.WriteLine("Emails are invalid");
                return;
            }

            if (!IsAllEmailsRegistered())
            {
                Console.WriteLine("Emails does not registered");
                return;
            }

            if (!HasCorrectContent())
            {
                Console.WriteLine("Invalid content");
                return;
            }

            if (!HasCorrectVariables())
            {
                Console.WriteLine("Invalid variables");
                return;
            }

            Console.WriteLine("Template saved");
        }
    }
}
