﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Indexes
{
    using Custom.Data.Metadata;
    using global::Raven.Abstractions.Indexing;
    using global::Raven.Client.Document;
    using global::Raven.Client.Indexes;

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
            var builder = new IndexDefinitionBuilder<TypeDefinition>
            {
                Map = docs => from doc in docs
                              select new { doc.Name }
            };

            var convention = new DocumentConvention
            {
                AllowQueriesOnId = true
            };

            //store.Conventions.RegisterIdConvention<Metadata.TypeDescriptor>(((dbname, commands, type) => "Type/" + commands.NextIdentityFor("Type")));

            convention.FindTypeTagName = type => type.IsSubclassOf(typeof(Data.Metadata.TypeDefinition))
                ? "Type"//DocumentConvention.DefaultTypeTagName(typeof(TypeDescriptor))
                : DocumentConvention.DefaultTypeTagName(type);

            var definition = builder.ToIndexDefinition(convention);

            definition.Indexes.Add("name", FieldIndexing.NotAnalyzed);
            definition.Stores.Add("name", FieldStorage.Yes);
            definition.TermVectors.Add("name", FieldTermVector.No);

            return definition;
        }
    }
}