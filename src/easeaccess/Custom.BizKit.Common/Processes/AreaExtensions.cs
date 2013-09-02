using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Custom.Processes
{
    using Custom.Extensions;
    using Custom.Models;
    using Raven.Imports.Newtonsoft.Json.Linq;

    public static class AreaExtensions
    {
        private static Raven.Client.IDocumentStore _store;
        public static Raven.Client.IDocumentStore DocumentStore
        {
            get { return _store ?? (_store = Custom.Documents.DocumentStoreHolder.Store); }
        }

        public static object Delete(this Area area, Stream stream)
        {
            var input = stream.JObject();
            JToken data;
            if (input.TryGetValue("data", out data))
            {
                var arr = data as JArray;
                if (arr != null)
                {
                    using (var session = DocumentStore.OpenSession())
                    {
                        foreach (var item in arr)
                        {
                            string id;
                            var obj = item as JObject;
                            if (obj != null && null != (id = obj.Value<string>("id")))
                            {
                                var entity = session.Load<Area>(id);
                                if (entity != null)
                                {
                                    session.Delete(entity);
                                }
                            }
                        }
                    }
                }
            }

            return new { success = false, message = "Not implemented " + input.ToString() };
        }

        public static object Insert(this Area area, Stream stream)
        {
            DictionaryObject dic = stream;

            return new { success = false, message = "Not implemented" };
        }

        public static object Update(this Area area, Stream stream)
        {
            DictionaryObject dic = stream;

            var jObject = stream;

            return new { success = false, message = "Not implemented" };
        }

        public static string Json(this Area area)
        {
            object id = area.Name;
            DateTime lastUpdated = DateTime.Now;
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append(string.Concat("Id: ", '"', id, '"', ','));
            sb.Append(string.Concat("Name: ", '"', area.Name, '"', ','));
            sb.Append(string.Concat("Title: ", '"', area.Title, '"', ','));
            sb.Append(string.Concat("LastUpdate:", '"', lastUpdated.ToString("s"), '"', ','));
            sb.Append("}");
            return sb.ToString();
        }

        public static Node[] Children(this Area area)
        {
            return new[]
                {
                    new Node
                    {
                        name = "Files",
                        text = "Files",
                        type = "files"
                    },
                    new Node
                    {
                        name = "Grids",
                        text = "Grids",
                        type = "grids"
                    },
                    new Node
                    {
                        name = "Lists",
                        text = "Lists",
                        type = "lists"
                    },
                    new Node
                    {
                        name = "Notes",
                        text = "Notes",
                        type = "notes"
                    }
                }.Union(area.AreasChildren()).ToArray();
        }

        public static Node[] AreasChildren(this Area area)
        {
            return area.Areas.Select(o => new Node
            {
                name = o.Name,
                text = o.Name,
                type = "Area"
            }).ToArray();
        }

        public static string AreasStore(this Area area, int skip, int take)
        {
            var data = area.Areas.Skip(skip).Take(take).Select(o => o.Json()).ToArray();

            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append("  success: true,");
            sb.Append("  data: [");
            sb.Append(string.Join(", ", data));
            sb.Append("  ], total: ");
            sb.Append(area.Areas.Count());
            sb.Append("}");
            return sb.ToString();
        }

        public static Node[] FilesChildren(this Area area)
        {
            return area.Files.Select(o => new Node
            {
                leaf = true,
                name = o.Name,
                text = o.Name,
                type = "File"
            }).ToArray();
        }

        public static Node[] GridsChildren(this Area area)
        {
            return area.Grids.Select(o => new Node
            {
                leaf = true,
                name = o.Name,
                text = o.Name,
                type = "Grid"
            }).ToArray();
        }

        public static Node[] ListsChildren(this Area area)
        {
            return area.Lists.Select(o => new Node
            {
                leaf = true,
                name = o.Name,
                text = o.Name,
                type = "List"
            }).ToArray();
        }

        public static Node[] NotesChildren(this Area area)
        {
            return area.Notes.Select(o => new Node
            {
                leaf = true,
                name = o.Name,
                text = o.Name,
                type = "Note"
            }).ToArray();
        }

        public static Area Get(this Area self, Area area)
        {
            return null;
        }

        public static File Get(this Area self, File file)
        {
            return null;
        }

        public static List Get(this Area self, List list)
        {
            return null;
        }

        public static Grid Get(this Area self, Grid model)
        {
            return null;
        }

        public static Note Get(this Area self, Note note)
        {
            return null;
        }

        public static bool Has(this Area self, Area area)
        {
            return self.Areas.Any(o => o.Name == area.Name);
        }

        public static bool Has(this Area self, File file)
        {
            return self.Files.Any(o => o.Name == file.Name);
        }

        public static bool Has(this Area self, List list)
        {
            return self.Lists.Any(o => o.Name == list.Name);
        }

        public static bool Has(this Area self, Grid model)
        {
            return self.Grids.Any(o => o.Name == model.Name);
        }

        public static bool Has(this Area self, Note note)
        {
            return self.Notes.Any(o => o.Name == note.Name);
        }

        public static void Merge(this Area self, Area other)
        {
        }

        public static XDocument Medatada(this Area self)
        {
            return (XDocument)new Metadata(self);
        }

        public static void Store(this Area self, Area area)
        {
            lock (self)
            {
                if (self.Has(new File { Name = area.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new List { Name = area.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new Grid { Name = area.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new Note { Name = area.Name }))
                    throw new InvalidOperationException("");

                var current = self.Areas.SingleOrDefault(o => o.Name == area.Name);

                if (current != null)
                {
                    current.Merge(area);
                }
                else
                {
                    self.Areas.Add(area);
                }
            }
        }

        public static void Store(this Area self, File file)
        {
            lock (self)
            {
                if (self.Has(new Area { Name = file.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new List { Name = file.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new Grid { Name = file.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new Note { Name = file.Name }))
                    throw new InvalidOperationException("");

                var current = self.Files.SingleOrDefault(o => o.Name == file.Name);

                if (current != null)
                {
                    current.Merge(file);
                }
                else
                {
                    self.Files.Add(file);
                }
            }
        }

        public static void Store(this Area self, List list)
        {
            lock (self)
            {
                if (self.Has(new Area { Name = list.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new File { Name = list.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new Grid { Name = list.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new Note { Name = list.Name }))
                    throw new InvalidOperationException("");

                var current = self.Lists.SingleOrDefault(o => o.Name == list.Name);

                if (current != null)
                {
                    current.Merge(list);
                }
                else
                {
                    self.Lists.Add(list);
                }
            }
        }

        public static void Store(this Area self, Grid model)
        {
            lock (self)
            {
                if (self.Has(new Area { Name = model.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new File { Name = model.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new List { Name = model.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new Note { Name = model.Name }))
                    throw new InvalidOperationException("");

                var current = self.Grids.SingleOrDefault(o => o.Name == model.Name);

                if (current != null)
                {
                    current.Merge(model);
                }
                else
                {
                    self.Grids.Add(model);
                }
            }
        }

        public static void Store(this Area self, Note note)
        {
            lock (self)
            {
                if (self.Has(new Area { Name = note.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new File { Name = note.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new List { Name = note.Name }))
                    throw new InvalidOperationException("");

                if (self.Has(new Grid { Name = note.Name }))
                    throw new InvalidOperationException("");

                var current = self.Notes.SingleOrDefault(o => o.Name == note.Name);

                if (current != null)
                {
                    current.Merge(note);
                }
                else
                {
                    self.Notes.Add(note);
                }
            }
        }
    }
}
