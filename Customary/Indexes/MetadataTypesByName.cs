using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Indexes
{
    using Custom.Metadata;
    using Raven.Abstractions.Indexing;
    using Raven.Client.Document;
    using Raven.Client.Indexes;

    public class MetadataTypesByName : AbstractIndexCreationTask
    {
        public static string Name
        {
            get { return "Type/ByName"; }
        }

        public override string IndexName
        {
            get { return Name; }
        }

        public override bool IsMapReduce
        {
            get { return false; }
        }

        public override IndexDefinition CreateIndexDefinition()
        {
            var builder = new IndexDefinitionBuilder<TypeDescriptor>
            {
                Map = docs => from doc in docs
                              select new { doc.Name, doc.Namespace }
            };

            var convention = new DocumentConvention
            {
                AllowQueriesOnId = true
            };

            //store.Conventions.RegisterIdConvention<Metadata.TypeDescriptor>(((dbname, commands, type) => "Type/" + commands.NextIdentityFor("Type")));

            convention.RegisterIdConvention<Metadata.TypeDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));
            convention.RegisterIdConvention<Metadata.PrimitiveDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));
            convention.RegisterIdConvention<Metadata.ObjectDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));
            convention.RegisterIdConvention<Metadata.EnumDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));
            convention.RegisterIdConvention<Metadata.UnitDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));
            convention.RegisterIdConvention<Metadata.EntityDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));

            convention.FindTypeTagName = type => type.IsSubclassOf(typeof(Metadata.TypeDescriptor))
                ? "Type"//DocumentConvention.DefaultTypeTagName(typeof(TypeDescriptor))
                : DocumentConvention.DefaultTypeTagName(type);

            var definition = builder.ToIndexDefinition(convention);

            definition.Indexes.Add("Name", FieldIndexing.NotAnalyzed);
            definition.Indexes.Add("Namespace", FieldIndexing.NotAnalyzed);
            definition.Stores.Add("Name", FieldStorage.Yes);
            definition.Stores.Add("Namespace", FieldStorage.Yes);
            definition.TermVectors.Add("Name", FieldTermVector.No);
            definition.TermVectors.Add("Namespace", FieldTermVector.No);

            return definition;
        }
    }
}