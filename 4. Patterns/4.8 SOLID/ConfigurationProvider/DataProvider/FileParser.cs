using ConfigurationProvider.Exceptions;
using ConfigurationProvider.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConfigurationProvider.DataProvider
{
    public interface IFileParser
    {
        ConfigurationProperty Parse(string line);
    }

    public class FileParser : IFileParser
    {
        private const char CommentDelimeter = '#';
        private const string NameValueDelimeter = " = ";
        private const char NamePartsDelimeter = '.';

        public ConfigurationProperty Parse(string line)
        {
            if (string.IsNullOrEmpty(line))
                return null;

            if (line.Contains(CommentDelimeter))
                line = line.Substring(0, line.LastIndexOf(CommentDelimeter));

            if (string.IsNullOrEmpty(line))
                return null;

            var nameValueArray = line.Split(NameValueDelimeter);

            if (nameValueArray.Length != 2)
                throw new LineParsingException("Property definition must be in format {namespace (optional)}.{class}.{property} = {value}");

            var property = DefineProperty(nameValueArray[0]);
            property.Value = nameValueArray[1].Trim();

            return property;
        }

        private ConfigurationProperty DefineProperty(string fullPropertyName) 
        {
            var nameParts = fullPropertyName.Split(NamePartsDelimeter).ToList();

            if (nameParts.Count < 2)
                throw new LineParsingException("Property and class names are required");

            nameParts.ForEach(Validate);

            var parts = new Stack<string>(nameParts);

            return new ConfigurationProperty
            {
                Property = parts.Pop(),
                Class = parts.Pop(),
                Namespace = string.Join(NamePartsDelimeter, parts.Reverse().ToArray())
            };
        }

        private void Validate(string namePart)
        {
            var startsWithLetter = char.IsLetter(namePart[0]);
            var startsWithUnderscore = namePart.StartsWith('_');
            var containsSpaces = namePart.Contains(' ');
            var containsInvalidCharacters = Regex.IsMatch(namePart, @"^[a-zA-Z0-9_]$");

            if (!(startsWithLetter || startsWithUnderscore) || containsSpaces || containsInvalidCharacters)
                throw new NameValidationException($"Invalid name: [{namePart}]");
        }
    }
}
