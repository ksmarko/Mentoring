using ConfigurationProvider.Models;
using System;

namespace ConfigurationProvider.DataProvider
{
    public interface IEnvironmentFactory
    {
        string GetFileNamePattern(EnvironmentType env);
    }

    public class EnvironmentFactory : IEnvironmentFactory
    {
        public string GetFileNamePattern(EnvironmentType env)
        {
            switch (env)
            {
                case EnvironmentType.Development:
                    return "dev";
                case EnvironmentType.Uat:
                    return "uat";
                case EnvironmentType.Production:
                    return "prod";
                default:
                    throw new NotImplementedException($"Unknown environment type {env.ToString()}");
            }
        }
    }
}
