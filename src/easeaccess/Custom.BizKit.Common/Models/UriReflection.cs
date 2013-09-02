using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    using Custom.Models;
    using Custom.Repositories;
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Database.Json;
    using Raven.Json.Linq;

    public class UriReflection : Reflection,  IDisposable
    {
        const string Apps = @"Apps";
        const string Areas = @"Areas";
        const string Columns = @"Columns";
        const string Fields = @"Fields";
        const string Files = @"Files";
        const string Forms = @"Forms";
        const string Grids = @"Grids";
        const string Items = @"Items";
        const string Lists = @"Lists";
        const string Notes = @"Notes";
        const string Texts = @"Texts";

        private IDocumentSession _session;
        private string _id;
        private App _app;
        private Area _area;
        private Field _field;
        private File _file;
        private Item _item;
        private List _list;
        private Grid _grid;
        private Note _note;
        private Column _column;
        private Model _form;
        private string _path;
        private string _property;
        private Queue<string> _segments;
        private readonly Uri _uri;
        private int _count;
        private List<PatchRequest> _patchList;

        public UriReflection(Uri uri)
        {
            var segments = uri.LocalPath.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            _uri = uri;
            _path = string.Empty;
            _session = Documents.DocumentStoreHolder.Store.OpenSession();
            _segments = new Queue<string>(segments);
            _patchList = new List<PatchRequest>();

            _session.Advanced.UseOptimisticConcurrency = true;

            var applications = _session.Query<App>().ToArray();

            _count = _segments.Count.Equals(0) ? 0 : Weight(applications, Match);

            if (_count.Equals(0))
            {
                segments.Insert(0, uri.Host);
                _segments = new Queue<string>(segments);

                _count = Weight(applications, Match);
            }

            _session.Dispose();
        }

        #region - properties -

        public override App App
        {
            get { return _app; }
        }

        public override Area Area
        {
            get { return _area; }
        }

        public override Column Column
        {
            get { return _column; }
        }

        public override Field Field
        {
            get { return _field; }
        }

        public override File File
        {
            get { return _file; }
        }

        public override Model Form
        {
            get { return _form; }
        }

        public override Grid Grid
        {
            get { return _grid; }
        }

        public override Item Item
        {
            get { return _item; }
        }

        public override List List
        {
            get { return _list; }
        }

        public override Note Note
        {
            get { return _note; }
        }

        public Uri Original
        {
            get { return _uri; }
        }

        internal Stack<PatchRequest> Stack
        {
            get { return new Stack<PatchRequest>(_patchList); }
        }

        public string Path
        {
            get { return _path; }
        }

        public string Property
        {
            get { return _property; }
        }

        protected Queue<string> Queue
        {
            get { return _segments; }
        }

        #endregion - properties -

        public void Dispose()
        {
            _session.Dispose();
        }

        public int Weight<T>(T arg, params Func<T, int>[] arr)
        {
            int weight = 0;
            foreach (var fn in arr)
            {
                if (0 < (weight = fn(arg)))
                    break;
            }
            return weight;
        }

        public int Weight<T>(IEnumerable<T> collection, Func<T, int> fn)
        {
            int weight = 0;
            foreach (var item in collection)
            {
                if (0 < (weight = fn(item)))
                    break;
            }
            return weight;
        }

        private int Child(Area area)
        {
            int weight;

            if (0 < (weight = Weight(area.Areas, Match)))
                return weight;

            if (0 < (weight = Weight(area.Files, Match)))
                return weight;

            if (0 < (weight = Weight(area.Grids, Match)))
                return weight;

            if (0 < (weight = Weight(area.Lists, Match)))
                return weight;

            if (0 < (weight = Weight(area.Notes, Match)))
                return weight;

            return 0;
        }


        private int Child(Model form)
        {
            int weight;

            if (0 < (weight = Weight(form.Fields, Match)))
                return weight;

            return 0;
        }

        private int Child(Grid grid)
        {
            int weight;

            if (0 < (weight = Weight(grid.Columns, Match)))
                return weight;

            /*if (0 < (weight = Weight(grid.Rows, Match)))
                return weight;*/

            return 0;
        }

        private int Child(List list)
        {
            int weight;

            if (0 < (weight = Weight(list.Items, Match)))
                return weight;

            return 0;
        }

        protected virtual bool Metadata(Area area)
        {
            var lookahead = _segments.Peek();

            if ("$metadata".Equals(lookahead, StringComparison.InvariantCultureIgnoreCase))
            {
                _area = area;
                _path += "/$metadata";

                return true;
            }

            return false;
        }

        private int Navigation(Area area)
        {
            var lookahead = _segments.Peek();

            if (Areas.Equals(lookahead, StringComparison.InvariantCultureIgnoreCase))
            {
                _segments.Dequeue();
                _path += '/' + Areas;
                _patchList.Last().Name = Areas;

                var weight = _segments.Count.Equals(0) ? 1 : 1 + Weight(area.Areas, Match);

                if (weight.Equals(1))
                {
                    _property = Areas;
                }

                return weight;
            }

            if (Files.Equals(lookahead, StringComparison.InvariantCultureIgnoreCase))
            {
                _segments.Dequeue();
                _path += '/' + Files;
                _patchList.Last().Name = Files;

                var weight = _segments.Count.Equals(0) ? 1 : 1 + Weight(area.Files, Match);

                if (weight.Equals(1))
                {
                    _property = Files;
                }

                return weight;
            }

            if (Grids.Equals(lookahead, StringComparison.InvariantCultureIgnoreCase))
            {
                _segments.Dequeue();
                _path += '/' + Grids;
                _patchList.Last().Name = Grids;

                var weight = _segments.Count.Equals(0) ? 1 : 1 + Weight(area.Grids, Match);

                if (weight.Equals(1))
                {
                    _property = Grids;
                }

                return weight;
            }

            if (Lists.Equals(lookahead, StringComparison.InvariantCultureIgnoreCase))
            {
                _segments.Dequeue();
                _path += '/' + Lists;
                _patchList.Last().Name = Lists;

                var weight = _segments.Count.Equals(0) ? 1 : 1 + Weight(area.Lists, Match);

                if (weight.Equals(1))
                {
                    _property = Lists;
                }

                return weight;
            }

            if (Notes.Equals(lookahead, StringComparison.InvariantCultureIgnoreCase))
            {
                _segments.Dequeue();
                _path += '/' + Notes;
                _patchList.Last().Name = Notes;

                var weight = _segments.Count.Equals(0) ? 1 : 1 + Weight(area.Notes, Match);

                if (weight.Equals(1))
                {
                    _property = Notes;
                }

                return weight;
            }

            return 0;
        }

        private int Navigation(Model form)
        {
            var lookahead = _segments.Peek();

            if (Fields.Equals(lookahead, StringComparison.InvariantCultureIgnoreCase))
            {
                _segments.Dequeue();
                _path += '/' + Fields;
                _patchList.Last().Name = Fields;

                var weight = _segments.Count.Equals(0) ? 1 : 1 + Weight(form.Fields, Match);

                if (weight.Equals(1))
                {
                    _property = Fields;
                }

                return weight;
            }

            return 0;
        }

        private int Navigation(Grid grid)
        {
            var lookahead = _segments.Peek();

            if (Columns.Equals(lookahead, StringComparison.InvariantCultureIgnoreCase))
            {
                _segments.Dequeue();
                _path += '/' + Columns;
                _patchList.Last().Name = Columns;

                var weight = _segments.Count.Equals(0) ? 1 : 1 + Weight(grid.Columns, Match);

                if (weight.Equals(1))
                {
                    _property = Columns;
                }

                return weight;
            }

            /*if (Forms.Equals(lookahead, StringComparison.InvariantCultureIgnoreCase))
            {
                _segments.Dequeue();
                _path += '/' + Forms;
                _patchList.Last().Name = Forms;

                var weight = _segments.Count.Equals(0) ? 1 : 1 + Weight(grid.Rows, Match);

                if (weight.Equals(1))
                {
                    _property = Forms;

                }

                return weight;
            }*/

            return 0;
        }

        private int Navigation(List list)
        {
            var lookahead = _segments.Peek();

            if (Items.Equals(lookahead, StringComparison.InvariantCultureIgnoreCase))
            {
                _segments.Dequeue();
                _path += '/' + Items;
                _patchList.Last().Name = Items;

                var weight = _segments.Count.Equals(0) ? 1 : 1 + Weight(list.Items, Match);

                if (weight.Equals(1))
                {
                    _property = Items;
                }

                return weight;
            }

            return 0;
        }

        protected virtual int Match(App app)
        {
            if (!_segments.Peek().Equals(app.Id, StringComparison.InvariantCultureIgnoreCase))
                return -1;

            _path = app.Id;
            _app = app;
            _segments.Dequeue();

            var metadata = _session.Advanced.GetMetadataFor(app);
            _id = app.Id;// metadata.Value<string>("Raven-Entity-Name") + '/' + metadata.Value<string>("@id");

            var patch = new PatchRequest { Type = PatchCommandType.Modify, PrevVal = RavenJObject.Parse(@"{ ""Id"": """ + app.Id + @"""}"), };
            var index = _patchList.Count;

            _patchList.Add(patch);

            var weight = _segments.Count.Equals(0) || Metadata(app) ? 2 : 2 + Weight(app, Navigation, Child);

            if (_patchList.Count > index + 1)
            {
                patch.Nested = new[] { _patchList[index + 1] };
            }

            return weight;
        }

        protected virtual int Match(Area area)
        {
            if (!_segments.Peek().Equals(area.Name, StringComparison.InvariantCultureIgnoreCase))
                return 0;

            _area = area;
            _path += '/' + area.Name;
            _segments.Dequeue();

            var patch = new PatchRequest { Type = PatchCommandType.Modify, PrevVal = RavenJObject.Parse(@"{ ""Id"": """ + area.Name + @"""}"), };
            var index = _patchList.Count;

            _patchList.Add(patch);

            var weight = _segments.Count.Equals(0) || Metadata(area) ? 2 : 2 + Weight(area, Navigation, Child);

            if (_patchList.Count > index + 1)
            {
                patch.Nested = new[] { _patchList[index + 1] };
            }

            return weight;
        }

        protected virtual int Match(Column column)
        {
            if (!_segments.Peek().Equals(column.Name, StringComparison.InvariantCultureIgnoreCase))
                return 0;

            _column = column;
            _path += "/" + column.Name;
            _segments.Dequeue();
            _patchList.Add(new PatchRequest { Type = PatchCommandType.Modify, PrevVal = RavenJObject.Parse(@"{ ""Id"": """ + column.Name + @"""}"), });

            return 1;
        }

        protected virtual int Match(Field field)
        {
            if (!_segments.Peek().Equals(field.Name, StringComparison.InvariantCultureIgnoreCase))
                return 0;

            _field = field;
            _path += "/" + field.Name;
            _segments.Dequeue();
            _patchList.Add(new PatchRequest { Type = PatchCommandType.Modify, PrevVal = RavenJObject.Parse(@"{ ""Id"": """ + field.Name + @"""}"), });

            return 1;
        }

        protected virtual int Match(File file)
        {
            if (!_segments.Peek().Equals(file.Name, StringComparison.InvariantCultureIgnoreCase))
                return 0;

            _file = file;
            _path += "/" + file.Name;
            _segments.Dequeue();
            _patchList.Add(new PatchRequest { Type = PatchCommandType.Modify, PrevVal = RavenJObject.Parse(@"{ ""Id"": """ + file.Name + @"""}"), });

            return 1;
        }

        protected virtual int Match(Model form)
        {
            if (!_segments.Peek().Equals(form.Name, StringComparison.InvariantCultureIgnoreCase))
                return 0;

            _form = form;
            _path += "/" + form.Name;
            _segments.Dequeue();

            var patch = new PatchRequest { Type = PatchCommandType.Modify, PrevVal = RavenJObject.Parse(@"{ ""Id"": """ + form.Name + @"""}"), };
            var index = _patchList.Count;

            _patchList.Add(patch);

            var weight = _segments.Count.Equals(0) ? 2 : 2 + Weight(form, Navigation, Child);

            if (_patchList.Count > index + 1)
            {
                patch.Nested = new[] { _patchList[index + 1] };
            }

            return weight;
        }

        protected virtual int Match(Grid grid)
        {
            if (!_segments.Peek().Equals(grid.Name, StringComparison.InvariantCultureIgnoreCase))
                return 0;

            _grid = grid;
            _path += "/" + grid.Name;
            _segments.Dequeue();

            var patch = new PatchRequest { Type = PatchCommandType.Modify, PrevVal = RavenJObject.Parse(@"{ ""Id"": """ + grid.Name + @"""}"), };
            var index = _patchList.Count;

            _patchList.Add(patch);

            var weight = _segments.Count.Equals(0) ? 2 : 2 + Weight(grid, Navigation, Child);

            if (_patchList.Count > index + 1)
            {
                patch.Nested = new[] { _patchList[index + 1] };
            }

            return weight;
        }

        protected virtual int Match(List list)
        {
            if (!_segments.Peek().Equals(list.Name, StringComparison.InvariantCultureIgnoreCase))
                return 0;

            _list = list;
            _path += "/" + list.Name;
            _segments.Dequeue();

            var patch = new PatchRequest { Type = PatchCommandType.Modify, PrevVal = RavenJObject.Parse(@"{ ""Id"": """ + list.Name + @"""}"), };
            var index = _patchList.Count;

            _patchList.Add(patch);

            var weight = _segments.Count.Equals(0) ? 2 : 2 + Weight(list, Navigation, Child);

            if (_patchList.Count > index + 1)
            {
                patch.Nested = new[] { _patchList[index + 1] };
            }

            return weight;
        }

        protected virtual int Match(Item item)
        {
            if (!_segments.Peek().Equals(item.Name, StringComparison.InvariantCultureIgnoreCase))
                return 0;

            _item = item;
            _path += "/" + item.Name;
            _segments.Dequeue();
            _patchList.Add(new PatchRequest { Type = PatchCommandType.Modify, PrevVal = RavenJObject.Parse(@"{ ""Id"": """ + item.Name + @"""}"), });

            return 1;
        }

        protected virtual int Match(Note note)
        {
            if (!_segments.Peek().Equals(note.Name, StringComparison.InvariantCultureIgnoreCase))
                return 0;

            _note = note;
            _path += "/" + note.Name;
            _segments.Dequeue();
            _patchList.Add(new PatchRequest { Type = PatchCommandType.Modify, PrevVal = RavenJObject.Parse(@"{ ""Id"": """ + note.Name + @"""}"), });

            return 1;
        }

        public virtual void SaveChanges()
        {
            _session.SaveChanges();
        }
    }
}
