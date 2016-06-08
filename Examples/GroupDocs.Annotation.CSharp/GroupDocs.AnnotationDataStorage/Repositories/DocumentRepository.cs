using System;
using GroupDocs.Annotation.Data.Contracts.DataObjects;
using GroupDocs.Annotation.Data.Contracts.Repositories;

namespace GroupDocs.Data.Json.Repositories
{
    public class DocumentRepository : JsonRepository<Document>, IDocumentRepository
    {
        private const string _repoName = "GroupDocs.annotation.documents.json";

        public DocumentRepository(IRepositoryPathFinder pathFinder)
            : base(pathFinder.Find(_repoName))
        {
        }

        public DocumentRepository(string filePath)
            : base(filePath)
        {
        }

        public Document GetDocument(string name)
        {
            lock (_syncRoot)
            {
                try
                {
                    return Data.Find(x => x.Name == name);
                }
                catch(Exception e)
                {
                    throw new DataJsonException("Failed to get document by id.", e);
                }
            }
        }
    }
}
