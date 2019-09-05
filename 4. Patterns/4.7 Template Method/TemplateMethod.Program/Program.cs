using AutoFixture;
using System;
using System.Linq;

namespace TemplateMethod.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var fixture = new Fixture();
            var template = fixture.Create<Template>();
            template.Variables.Add("Gmail", "true");
            template.Emails = fixture.CreateMany<string>(5)
                .Select(email => $"{email}@gmail.com")
                .ToList();

            var processor = new GmailTemplateProcessor(template);
            processor.Process();

            var processorE = new EpamTemplateProcessor(template);
            processorE.Process();

            Console.ReadKey();
        }
    }
}
