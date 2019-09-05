using ConfigurationProvider.Exceptions;
using ConfigurationProvider.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConfigurationProvider.DataProvider
{
    public interface IDataProvider
    {
        IEnumerable<ConfigurationProperty> GetProperties(EnvironmentType env);
    }

    public class FileProvider : IDataProvider
    {
        private readonly IHierarchyProvider _hierarchyProvider;
        private readonly IFileParser _fileParser;
        private readonly IFileReader _fileReader;
        private readonly IPropertiesFilter _filter;

        public FileProvider(
            IHierarchyProvider hierarchyProvider, 
            IFileReader fileReader, 
            IFileParser fileParser, 
            IPropertiesFilter filter)
        {
            _hierarchyProvider = hierarchyProvider;
            _fileParser = fileParser;
            _fileReader = fileReader;
            _filter = filter;
        }

        public IEnumerable<ConfigurationProperty> GetProperties(EnvironmentType env)
        {
            var files = _hierarchyProvider.GetFiles(env);
            var properties = GetProperties(files);
            return _filter.Filter(properties);
        }

        private IEnumerable<ConfigurationProperty> GetProperties(IEnumerable<string> files)
        {
            foreach (var path in files)
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException(path);

                using (var enumerator = _fileReader.Read(path).GetEnumerator())
                {
                    int index = 1;

                    while (enumerator.MoveNext())
                    {
                        ConfigurationProperty property;

                        try
                        {
                            var line = enumerator.Current;
                            property = _fileParser.Parse(line);

                            if (property == null)
                                continue;
                        }
                        catch (Exception ex)
                        {
                            throw new FileParsingException(path, index, ex);
                        }

                        yield return property;
                        index++;
                    }
                }
            }
        }
    }
}
