using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Web;

namespace Custom.DocumentModel
{
    using Custom.Objects;
    using Raven.Client;
    using Raven.Imports.Newtonsoft.Json;
    using Raven.Json.Linq;
    

    public sealed class Master : IDisposable
    {
        const string Applications = @"Applications";
        const string Separator = @"/";
        const string Enums = @"Enums";
        const string Files = @"Files";
        const string Forms = @"Forms";
        const string Grids = @"Grids";
        const string Links = @"Links";
        const string Models = @"Models";
        const string Notes = @"Notes";
        const string Operations = @"Operations";
        const string Pages = @"Pages";
        const string Reports = @"Reports";
        const string Screens = @"Screens";
        const string Jobs = @"Jobs";
        const string Tables = @"Tables";
        const string Tasks = @"Tasks";

        private IDocumentSession _session;

        public Master()
        {
        }

        private IDocumentSession Session
        {
            get { return _session ?? (_session = Masterdata.Store.OpenSession()); }
        }

        public void Dispose()
        {
            if (_session != null)
            {
                _session.Dispose();
            }
        }

        public void Import(string path)
        {
            RavenJToken document;
            MasterObject master;

            using (var textReader = System.IO.File.OpenText(path))
            {
                using (var jsonReader = new JsonTextReader(textReader))
                {
                    document = RavenJToken.ReadFrom(jsonReader);
                }

                /*master = JsonConvert.DeserializeObject<MasterObject>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
                });*/

                //Import(master);
                Import(document as RavenJObject);
            }
        }

        public void Import(RavenJObject document)
        {
            var applications = document.Array("Applications");

            if (applications != null)
            {
                foreach (var application in applications.Values().OfType<RavenJObject>())
                {
                    var name = application.Value<string>("Name");
                    if (name != null)
                    {
                        var id = "Applications/" + name;

                        var original = Session.Load<RavenJObject>(id);

                        if (original == null)
                            Session.Store(application, id);
                        else
                        {
                            original.Merge(application);
                            var etag = Session.Advanced.GetEtagFor(original);
                            if (etag.HasValue)
                                Session.Store(original, etag.Value);
                            else
                                Session.Store(original, id);
                        }
                    }
                }
            }
        }

        public void Import(MasterObject master)
        {
            foreach (var application in master.Applications)
            {
                var jso = Session.Load<RavenJObject>(application.Id());
                //var entity = Session.Load<ApplicationObject>(application.Id());
                if (jso == null)
                    Session.Store(application);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(jso);
                    if (etag.HasValue)
                        Session.Store(jso, etag.Value);
                    else
                        Session.Store(jso);
                }
            }

            foreach (var association in master.Associations)
            {
                var entity = Session.Load<AssociationObject>(association.Id());
                if (entity == null)
                    Session.Store(association);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            foreach (var account in master.DropboxAccounts)
            {
                var entity = Session.Load<DropboxAccount>(account.Id);
                if (entity == null)
                    Session.Store(account);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            foreach (var folder in master.DropboxFolders)
            {
                var entity = Session.Load<DropboxFolder>(folder.Id);
                if (entity == null)
                    Session.Store(folder);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            foreach (var file in master.DropboxFiles)
            {
                var entity = Session.Load<DropboxFile>(file.Id);
                if (entity == null)
                    Session.Store(file);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            foreach (var account in master.EvernoteAccounts)
            {
                var entity = Session.Load<EvernoteAccount>(account.Id);
                if (entity == null)
                    Session.Store(account);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            foreach (var notebook in master.EvernoteNotebooks)
            {
                var entity = Session.Load<EvernoteNotebook>(notebook.Id);
                if (entity == null)
                    Session.Store(notebook);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            foreach (var note in master.EvernoteNotes)
            {
                var entity = Session.Load<EvernoteNote>(note.Id);
                if (entity == null)
                    Session.Store(note);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            /*foreach (var link in master.Links)
            {
                var entity = Session.Load<RelationshipObject>(link.Id());
                if (entity == null)
                    Session.Store(link);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }*/

            foreach (var model in master.Models)
            {
                var entity = Session.Load<ModelObject>(model.Id());
                if (entity == null)
                    Session.Store(model);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            foreach (var relationship in master.Relationships)
            {
                var entity = Session.Load<RelationshipObject>(relationship.Id());
                if (entity == null)
                    Session.Store(relationship);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            foreach (var report in master.Reports)
            {
                var entity = Session.Load<ReportObject>(report.Id());
                if (entity == null)
                    Session.Store(report);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            foreach (var screen in master.Screens)
            {
                var entity = Session.Load<ScreenObject>(screen.Id());
                if (entity == null)
                    Session.Store(screen);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            foreach (var table in master.Tables)
            {
                var entity = Session.Load<TableObject>(table.Id());
                if (entity == null)
                    Session.Store(table);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            foreach (var task in master.Tasks)
            {
                var entity = Session.Load<TaskObject>(task.Id());
                if (entity == null)
                    Session.Store(task);
                else
                {
                    var etag = Session.Advanced.GetEtagFor(entity);
                    if (etag.HasValue)
                        Session.Store(entity, etag.Value);
                    else
                        Session.Store(entity);
                }
            }

            Session.SaveChanges();
        }

        public Application Application(string name)
        {
            var data = Session.Load<RavenJObject>("Applications" + Separator + name);
            return data != null ? new Application(data) : null;
        }

        public Application LookupApplication(string name)
        {
            var entity = Session.Load<RavenJObject>(Applications + Separator + name);
            return entity != null ? new Application(entity, this, Applications) : null;
        }

        public Enum LookupEnum(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Enum(entity, this, Enums) : null;
        }

        public File LookupFile(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new File(entity, this, Files) : null;
        }

        public Form LookupForm(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Form(entity, this, Forms) : null;
        }

        public Grid LookupGrid(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Grid(entity, this, Grids) : null;
        }

        public Job LookupJob(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Job(entity, this, Jobs) : null;
        }

        public Link LookupLink(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Link(entity, this, Links) : null;
        }

        public Template LookupModel(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Template(entity, this, Models) : null;
        }

        public Note LookupNote(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Note(entity, this, Notes) : null;
        }

        public Operation LookupOperation(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Operation(entity, this, Operations) : null;
        }

        public Page LookupPage(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Page(entity, this, Pages) : null;
        }

        public Report LookupReport(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Report(entity, this, Reports) : null;
        }

        public Screen LookupScreen(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Screen(entity, this, Screens) : null;
        }

        public Table LookupTable(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Table(entity, this, Tables) : null;
        }

        public Task LookupTask(string name)
        {
            var entity = Session.Load<RavenJObject>(name);
            return entity != null ? new Task(entity, this, Tasks) : null;
        }
        
        public LookupResult Lookup(Lookup lookup)
        {
            if (lookup.Path.Count.Equals(0))
                return null;// LookupApplication(Masterdata.SiteName) ?? (Component)this;

            Resource resource = null;

            var name = lookup.Path.Pop();

            if (lookup.Path.Count > 0)
            {
                var segment = name;
                name = lookup.Path.Pop();

                if (Applications.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                {
                    _session.Load<RavenJObject>("Applications/" + name);
                }
                else if (Jobs.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    resource = LookupJob(name);
                else if (Tables.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    resource = LookupTable(name);
                else if (Tasks.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    resource = LookupTask(name);

                if (resource != null)
                    return Value(resource.Lookup(lookup), resource);

                lookup.Path.Push(name);
                name = segment;
            }

            lookup.Path.Push(name);

            resource = LookupApplication(Masterdata.SiteName);

            if (resource != null)
                return Value(resource.Lookup(lookup), resource);

            return this;
        }

        public void SaveChanges()
        {
            Session.SaveChanges();
        }

        public void RejectChanges()
        {
            _session = null;
        }
    }
}