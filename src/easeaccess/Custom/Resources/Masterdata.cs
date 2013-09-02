using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization.Formatters;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Newtonsoft.Json;
    using Raven.Client;
    using Raven.Client.Embedded;

    public class Masterdata
    {
        const string Separator = @"/";
        const string Applications = @"Applications";
        const string Areas = @"Areas";
        const string Enums = @"Enums";
        const string Files = @"Files";
        const string Forms = @"Forms";
        const string Grids = @"Grids";
        const string Jobs = @"Jobs";
        const string Links = @"Links";
        const string Models = @"Models";
        const string Notes = @"Notes";
        const string Operations = @"Operations";
        const string Pages = @"Pages";
        const string Reports = @"Reports";
        const string Screens = @"Screens";
        const string Tables = @"Tables";
        const string Tasks = @"Tasks";

        public static string ConnectionStringName = "RavenDB";
        private static readonly object _lock = new object();
        private static IDocumentStore _store;
        private static MemoryCache _cache;
        private static string _siteName;
        private static Masterdata _instance;

        public static Masterdata Instance
        {
            get
            {
                var instance = _instance;

                // return without locking if already exist
                if (instance != null)
                    return instance;

                // lock and check again
                lock (_lock)
                {
                    if (_instance != null)
                        instance = _instance;
                    else
                    {
                        // create new instance if doesn't exist
                        instance = new Masterdata();

                        _instance = instance;
                    }
                }

                return instance;
            }
        }

        public static IDocumentStore Store
        {
            get
            {
                var store = _store;

                // return without locking if already exist
                if (store != null)
                    return store;

                // lock and check again
                lock (_lock)
                {
                    if (_store != null)
                        store = _store;
                    else
                    {
                        // create new instance if doesn't exist
                        store = new EmbeddableDocumentStore()
                        {
                            ConnectionStringName = ConnectionStringName
                        };

                        store.Initialize()
                            .RegisterApplicationIdConvention()
                            .RegisterEnumIdConvention()
                            .RegisterFileIdConvention()
                            .RegisterFormIdConvention()
                            .RegisterGridIdConvention()
                            .RegisterJobIdConvention()
                            .RegisterModelIdConvention()
                            .RegisterNoteIdConvention()
                            .RegisterOperationIdConvention()
                            .RegisterPageIdConvention()
                            .RegisterReportIdConvention()
                            .RegisterScreenIdConvention()
                            .RegisterTableIdConvention()
                            .RegisterTaskIdConvention();

                        _store = store;
                    }
                }

                return store;
            }
        }

        public static MemoryCache Cache
        {
            get
            {
                var cache = _cache;

                // return without locking if already exist
                if (cache != null)
                    return cache;

                // lock and check again
                lock (_lock)
                {
                    if (_store != null)
                        cache = _cache;
                    else
                    {
                        // create new instance if doesn't exist
                        cache = new MemoryCache("Masterdata")
                        {
                        };

                        _cache = cache;
                    }
                }

                return cache;
            }
        }

        public static string SiteName
        {
            get { return _siteName ?? (_siteName = System.Web.Hosting.HostingEnvironment.SiteName); }
        }

        public void Import(string path)
        {
        }
    }
}