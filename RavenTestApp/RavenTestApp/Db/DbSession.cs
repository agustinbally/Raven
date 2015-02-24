using Raven.Client;
using Raven.Client.Document;
using RavenTestApp.Entities;

namespace RavenTestApp.Db
{
    public class DbSession
    {
        private static IDocumentSession CurrentSession { get; set; }
    
        static DbSession()
        {
            var documentStore  = new DocumentStore
            {
                Url = "http://localhost:8080/",	// server URL
                DefaultDatabase = "DbTest"	// default database
            };

            documentStore.Initialize(); 
            CurrentSession = documentStore.OpenSession();
        }

        public static string Store<T>(T data) where T: EntityId
        {
            CurrentSession.Store(data);
            CurrentSession.SaveChanges();

            return data.Id;
        }

        public static T Load<T>(string id)
        {
            return CurrentSession.Load<T>(id);
        }
    }
}