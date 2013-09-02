using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    using Custom.Models;
    using Raven.Client;
    using Raven.Imports.Newtonsoft.Json;
    

    public static class IDocumentStoreExtensions
    {
        public static void Import(this IDocumentStore store, string path)
        {
            using (var reader = System.IO.File.OpenText(path))
            {
                var json = reader.ReadToEnd();

                var import = JsonConvert.DeserializeObject<Objects.CloudObject>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
                });

                using (var session = store.OpenSession())
                {
                    foreach (var app in import.Apps)
                    {
                        session.Store(app);
                    }

                    foreach (var account in import.DropboxAccounts)
                    {
                        session.Store(account);
                    }

                    foreach (var folder in import.DropboxFolders)
                    {
                        session.Store(folder);
                    }

                    foreach (var file in import.DropboxFiles)
                    {
                        session.Store(file);
                    }

                    foreach (var account in import.EvernoteAccounts)
                    {
                        session.Store(account);
                    }

                    foreach (var notebook in import.EvernoteNotebooks)
                    {
                        session.Store(notebook);
                    }

                    foreach (var note in import.EvernoteNotes)
                    {
                        session.Store(note);
                    }

                    session.SaveChanges();
                }
            }
        }
    }
}
