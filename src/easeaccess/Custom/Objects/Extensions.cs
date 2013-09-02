using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    using Raven.Client;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;
    using System.Web.Caching;

    internal static class Extensions
    {
        const string Separator = @"/";
        const string Applications = @"Applications";
        const string Areas = @"Areas";
        const string Associations = @"Associations";
        const string DropboxAccounts = @"DropboxAccounts";
        const string DropboxFolders = @"DropboxFolders";
        const string DropboxFiles = @"DropboxFiles";
        const string Enums = @"Enums";
        const string EvernoteAccounts = @"EvernoteAccounts";
        const string EvernoteNotes = @"EvernoteNotes";
        const string EvernoteNotebooks = @"EvernoteNotebooks";
        const string Files = @"Files";
        const string Forms = @"Forms";
        const string Functions = @"Functions";
        const string Grids = @"Grids";
        const string Jobs = @"Jobs";
        const string Links = @"Links";
        const string Models = @"Models";
        const string Notes = @"Notes";
        const string Relationships = @"Relationships";
        const string Reports = @"Reports";
        const string Screens = @"Screens";
        const string Tables = @"Tables";
        const string Tasks = @"Tasks";

        public static int ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            var count = 0;
            foreach (var item in collection)
            {
                action(item);
            }
            return count;
        }

        public static int ForEach<T>(this IEnumerable<T> collection, Action<T, string> action, Func<T, string> func)
        {
            var count = 0;
            foreach (var item in collection)
            {
                action(item, func(item));
            }
            return count;
        }

        public static void Merge(this RavenJArray target, params RavenJArray[] values)
        {
            foreach (var source in values)
            {
                if (source == null)
                    continue;
            }
        }

        public static void Merge(this RavenJObject target, params RavenJObject[] values)
        {
            foreach (var source in values)
            {
                if (source == null)
                    continue;

                foreach (var key in source.Keys)
                {
                    var value = source[key];
                    RavenJToken original;
                    if (!target.TryGetValue(key, out original))
                        target[key] = value;
                    else if (original.Type != value.Type)
                        target[key] = value;
                    else
                    {
                        switch (original.Type)
                        {
                            case JTokenType.Object:
                                (original as RavenJObject).Merge(value as RavenJObject);
                                break;

                            default:
                                target[key] = value;
                                break;
                        }
                    }
                }
            }
        }

        public static RavenJArray Array(this RavenJObject jobject, string name)
        {
            RavenJToken value;
            if (jobject.TryGetValue(name, out value))
                return value as RavenJArray;
            return null;
        }

        public static string Id(this ApplicationObject entity)
        {
            return entity != null ? Applications + Separator + entity.Name : null;
        }

        public static string Id(this AssociationObject entity)
        {
            return entity != null ? Associations + Separator + entity.Principal + '_' + entity.Dependant : null;
        }

        public static string Id(this JobObject entity)
        {
            return entity != null ? Jobs + Separator + entity.Name : null;
        }

        public static string Id(this LinkObject entity)
        {
            return entity != null ? Links + Separator + entity.Principal + '_' + entity.Dependant : null;
        }

        public static string Id(this ModelObject entity)
        {
            return entity != null ? Models + Separator + entity.Name : null;
        }

        public static string Id(this RelationshipObject entity)
        {
            return entity != null ? Relationships + Separator + entity.Principal + '_' + entity.Dependant : null;
        }

        public static string Id(this ReportObject entity)
        {
            return entity != null ? Reports + Separator + entity.Name : null;
        }

        public static string Id(this ScreenObject entity)
        {
            return entity != null ? Screens + Separator + entity.Name : null;
        }

        public static string Id(this TableObject entity)
        {
            return entity != null ? Tables + Separator + entity.Name : null;
        }

        public static string Id(this TaskObject entity)
        {
            return entity != null ? Tasks + Separator + entity.Name : null;
        }

        public static IDocumentStore RegisterApplicationIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<ServiceObject>((dbname, commands, o) => Applications + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterAssociationIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<AssociationObject>((dbname, commands, o) => Associations + Separator + o.Principal + '_' + o.Dependant);
            return store;
        }

        public static IDocumentStore RegisterRelationshipIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<RelationshipObject>((dbname, commands, o) => Relationships + Separator + o.Principal + '_' + o.Dependant);
            return store;
        }

        public static IDocumentStore RegisterEnumIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<EnumObject>((dbname, commands, o) => Enums + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterFileIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<FileObject>((dbname, commands, o) => Files + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterFormIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<FormObject>((dbname, commands, o) => Forms + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterGridIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<GridObject>((dbname, commands, o) => Grids + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterJobIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<JobObject>((dbname, commands, o) => Jobs + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterLinkIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<LinkObject>((dbname, commands, o) => Links + Separator + o.Principal + '_' + o.Dependant);
            return store;
        }

        public static IDocumentStore RegisterModelIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<ModelObject>((dbname, commands, o) => Models + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterNoteIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<NoteObject>((dbname, commands, o) => Notes + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterOperationIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<OperationObject>((dbname, commands, o) => Functions + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterPageIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<PageObject>((dbname, commands, o) => Reports + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterReportIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<ReportObject>((dbname, commands, o) => Reports + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterScreenIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<ScreenObject>((dbname, commands, o) => Screens + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterTableIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<TableObject>((dbname, commands, o) => Tables + Separator + o.Name);
            return store;
        }

        public static IDocumentStore RegisterTaskIdConvention(this IDocumentStore store)
        {
            store.Conventions.RegisterIdConvention<TaskObject>((dbname, commands, o) => Tasks + Separator + o.Name);
            return store;
        }
    }
}