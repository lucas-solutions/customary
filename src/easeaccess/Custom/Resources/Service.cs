using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Documents;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;
    
    public abstract class Service : Component
    {
        protected const string Separator = @"/";
        protected const string Enums = @"Enums";
        protected const string Files = @"Files";
        protected const string Forms = @"Forms";
        protected const string Grids = @"Grids";
        protected const string Links = @"Links";
        protected const string Models = @"Models";
        protected const string Notes = @"Notes";
        protected const string Operations = @"Operations";
        protected const string Pages = @"Pages";
        protected const string Reports = @"Reports";
        protected const string Screens = @"Screens";

        protected Service(RavenJObject data, string path)
            : base(data, path)
        {
        }
        public override Component Lookup(Lookup lookup)
        {
            if (lookup.Path.Count.Equals(0))
                return null;

            Component component = null;

            var name = lookup.Path.Pop();
            
            if (lookup.Path.Count > 0)
            {
                var segment = name;
                name = lookup.Path.Pop();
                /*
                if (Enums.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    component = Enum(name);
                else if (Files.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    component = File(name);
                else if (Forms.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    component = Form(name);
                else if (Links.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    component = Link(name);
                else if (Models.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    component = Model(name);
                else if (Notes.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    component = Note(name);
                else if (Operations.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    component = Operation(name);
                else if (Pages.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    component = Page(name);
                else if (Reports.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    component = Report(name);
                else if (Screens.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    component = Screen(name);
                */
                if (component != null)
                    return Value(component.Lookup(lookup), component);

                lookup.Path.Push(name);
                name = segment;
            }

            lookup.Path.Push(name);

            return null;
        }
        /*
        public Enum Enum(string name)
        {
            var entity = Entity.Enums.SingleOrDefault(o => name.Equals(o.Name, StringComparison.InvariantCultureIgnoreCase));

            if (entity != null)
                return new Enum(entity, this, Path + Separator + Enums);
            
            var parent = Parent as IService;

            return parent != null ? parent.LookupEnum(name) : null;
        }

        public File File(string name)
        {
            var entity = Entity.Files.SingleOrDefault(o => name.Equals(o.Name, StringComparison.InvariantCultureIgnoreCase));

            if (entity != null)
                return new File(entity, this, Path + Separator + Files);

            var parent = Parent as IService;

            return parent != null ? parent.LookupFile(name) : null;
        }

        public Form Form(string name)
        {
            var entity = Entity.Forms.SingleOrDefault(o => name.Equals(o.Name, StringComparison.InvariantCultureIgnoreCase));

            if (entity != null)
                return new Form(entity, this, Path + Separator + Forms);

            var parent = Parent as IService;

            return parent != null ? parent.LookupForm(name) : null;
        }

        public Grid Grid(string name)
        {
            var entity = Entity.Grids.SingleOrDefault(o => name.Equals(o.Name, StringComparison.InvariantCultureIgnoreCase));

            if (entity != null)
                return new Grid(entity, this, Path + Separator + Grids);

            var parent = Parent as IService;

            return parent != null ? parent.LookupGrid(name) : null;
        }

        public Link Link(string name)
        {
            var entity = Entity.Links.SingleOrDefault(o => name.Equals(o.Principal + "_" + o.Dependant, StringComparison.InvariantCultureIgnoreCase));

            if (entity != null)
                return new Link(entity, this, Path + Separator + Links);

            var parent = Parent as IService;

            return parent != null ? parent.LookupLink(name) : null;
        }

        public Model Model(string name)
        {
            var entity = Entity.Models.SingleOrDefault(o => name.Equals(o.Name, StringComparison.InvariantCultureIgnoreCase));

            if (entity != null)
                return new Model(entity, this, Path + Separator + Models);

            var parent = Parent as IService;

            return parent != null ? parent.LookupModel(name) : null;
        }

        public Note Note(string name)
        {
            var entity = Entity.Notes.SingleOrDefault(o => name.Equals(o.Name, StringComparison.InvariantCultureIgnoreCase));

            if (entity != null)
                return new Note(entity, this, Path + Separator + Notes);

            var parent = Parent as IService;

            return parent != null ? parent.LookupNote(name) : null;
        }

        public Operation Operation(string name)
        {
            var entity = Entity.Operations.SingleOrDefault(o => name.Equals(o.Name, StringComparison.InvariantCultureIgnoreCase));

            if (entity != null)
                return new Operation(entity, this, Path + Separator + Operations);
            
            var parent = Parent as IService;

            return parent != null ? parent.LookupOperation(name) : null;
        }

        public Page Page(string name)
        {
            var entity = Entity.Pages.SingleOrDefault(o => name.Equals(o.Name, StringComparison.InvariantCultureIgnoreCase));

            if (entity != null)
                return new Page(entity, this, Path + Separator + Pages);

            var parent = Parent as IService;

            return parent != null ? parent.LookupPage(name) : null;
        }

        public Report Report(string name)
        {
            var entity = Entity.Reports.SingleOrDefault(o => name.Equals(o.Name, StringComparison.InvariantCultureIgnoreCase));

            if (entity != null)
                return new Report(entity, this, Path + Separator + Reports);

            var parent = Parent as IService;

            return parent != null ? parent.LookupReport(name) : null;
        }

        public Screen Screen(string name)
        {
            var entity = Entity.Screens.SingleOrDefault(o => name.Equals(o.Name, StringComparison.InvariantCultureIgnoreCase));

            if (entity != null)
                return new Screen(entity, this, Path + Separator + Screens);

            var parent = Parent as IService;

            return parent != null ? parent.LookupScreen(name) : null;
        }
        */
        #region - mvc -

        public override string MvcRouteName
        {
            get { return Parent.MvcRouteName; }
        }

        public override string MvcAreaName
        {
            get { return Parent.MvcAreaName; }
        }

        #endregion - mvc -
    }
}