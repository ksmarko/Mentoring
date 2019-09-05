using ConfigurationProvider.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConfigurationProvider.Exceptions;

namespace ConfigurationProvider.DataProvider
{
    public interface IHierarchyProvider
    {
        IEnumerable<string> GetFiles(EnvironmentType env);
    }

    public class HierarchyProvider : IHierarchyProvider
    {
        private readonly string _basePath;
        private readonly IEnvironmentFactory _environmentFactory;

        private const string DefaultFileName = "default";

        public HierarchyProvider(FileProviderOptions options, IEnvironmentFactory environmentFactory)
        {
            _basePath = options.BasePath;
            _environmentFactory = environmentFactory;
        }

        public IEnumerable<string> GetFiles(EnvironmentType env)
        {
            var pattern = _environmentFactory.GetFileNamePattern(env);
            var defaultFiles = SearchByPattern(DefaultFileName).ToList();

            if (!defaultFiles.Any())
                throw new ConfigurationProviderException("At least one defauult configuration file must be specified");

            var files = SearchByPattern(pattern).ToList();

            defaultFiles.Sort();
            files.Sort();
            files.InsertRange(0, defaultFiles);

            return files;
        }

        private IEnumerable<string> SearchByPattern(string pattern)
        {
            return Directory.GetFiles(_basePath, $"*{pattern}*.*", SearchOption.AllDirectories);
        }
    }
}
