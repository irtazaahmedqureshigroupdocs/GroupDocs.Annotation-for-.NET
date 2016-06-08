using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace GroupDocs.Data.Json
{
    public interface IRepositoryPathFinder
    {
        string Find(string repository);
    }

    public class RepositoryPathFinder : IRepositoryPathFinder
    {
        public const string RepoBasePathKey = "GroupDocsRepoBasePath";

        public string Find(string repository)
        {
            var ctx = HttpContext.Current;
            if (ctx == null)
            {
                return GetConfiguredPath(repository);
            }

            var basePath = (ctx.Application != null ? (string) ctx.Application[RepoBasePathKey] : null);
            return (string.IsNullOrWhiteSpace(basePath) ?
                (ctx.Server != null ?
                    ctx.Server.MapPath(string.Format("~/App_Data/{0}", repository)) : GetConfiguredPath(repository)) :
                Path.Combine(basePath, repository));
        }

        private static string GetConfiguredPath(string repository)
        {
            return Path.Combine(
                ConfigurationManager.AppSettings[RepoBasePathKey] ?? AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                repository);
        }
    }
}
