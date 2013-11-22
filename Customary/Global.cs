
namespace Custom
{
    using Custom.Data;
    using Custom.Data.Metadata;
    using Custom.Data.Persistence;
    using Custom.Diagnostics;

    public static class Global
    {
        public static class Routes
        {
            public const string AreaSetRouteName = "Area_Set";
            public const string AreaItemRouteName = "Area_Item";
            public const string EnumSetRouteName = "Enum_Set";
            public const string EnumItemRouteName = "Enum_Item";
            public const string ModelSetRouteName = "Model_Set";
            public const string ModelItemRouteName = "Model_Item";
            public const string ModelItemInvokeRouteName = "Model_Item_Invoke";
            public const string ModelItemEntityInvokeRouteName = "Model_Item_Entity_Invoke";
            public const string ModelItemEntityItemRouteName = "Model_Item_Entity_Item";
            public const string ModelItemEntitySetRouteName = "Model_Item_Entity_Set";
            public const string StoreSetRouteName = "Store_Set";
            public const string StoreItemRouteName = "Store_Item";
            public const string TypeSetRouteName = "Type_Set";
            public const string TypeItemRouteName = "Type_Item";
            public const string ValueSetRouteName = "Value_Set";
            public const string ValueItemRouteName = "Value_Item";

            public const string DataNameMetadataRouteName = "Data_Name_Metadata";

            public const string ExtRouteName = "Scripts_Ext";
            public const string ExtAreaRouteName = "Scripts_Area_Ext";
            public const string DataDomainRouteName = "Data_Domain";
            public const string DataDirectoryRouteName = "Data_Directory";
            public const string DataEntityRouteName = "Data_Entity_Item";
            public const string DataPropertyRouteName = "Data_Property_Item";
            public const string DataEntityInvokeRouteName = "Data_Entity_Invoke";
            public const string DataTypeRouteName = "Data_Type";
            public const string DataTypeInvokeRouteName = "Data_Type_Invoke";

            public const string DefaultPathRouteName = "Default_Path";
        }

        public const string StoreRouteName = "Store_Default";
        public const string StoreDetailRouteName = "Store_Detail";
        public const string DataGreedyRouteName = "Data_Greedy";
        public const string DataGroupRouteName = "Data_Group";
        public const string DataStoreRouteName = "Data_Repository";
        public const string DataRouteName = "Data_Default";

        private static readonly object _lock = new object();
        private static SimpleInjector.Container _container;
        private static ILogger _logger;
        private static GlobalizationContext _globalization;
        private static MasterdataContext _masterdata;
        private static MetadataContext _metadata;
        private static NavigationContext _navigation;

        public static SimpleInjector.Container Container
        {
            get
            {
                var container = _container;

                if (container == null)
                {
                    lock (_lock)
                    {
                        container = _container ?? (_container = new SimpleInjector.Container());
                    }
                }

                return container;
            }
        }

        public static ILogger Logger
        {
            get
            {

                const string LogglyInputDefault = "1205e89a-b51c-467f-a6c4-843f1e2b8827";
                const string inputJSON = "2405d6e9-00c3-4b3f-9202-2f5676501cdb";

                var logger = _logger;

                if (logger == null)
                {
                    lock (_lock)
                    {
                        //logger = _logger ?? (_logger = new LogglyLogger("1205e89a-b51c-467f-a6c4-843f1e2b8827"));

                        logger = _logger;
                        
                        if (logger == null)
                        {
                            var multi = new MultiLogger();

                            var loggly = new LogglyLogger(inputJSON);
                            multi.Add("loggly", loggly);
                            
                            //var log4net = new Log4NetLogger();
                            //multi.Add("log4net", log4net);

                            _logger = logger = multi;
                        }
                    }
                }

                return logger;
            }
        }

        public static GlobalizationContext Globalization
        {
            get
            {
                var globalization = _globalization;

                if (globalization == null)
                {
                    lock (_lock)
                    {
                        globalization = _globalization ?? (_globalization = new GlobalizationContext());
                    }
                }

                return globalization;
            }
        }

        public static MasterdataContext Masterdata
        {
            get
            {
                var masterdata = _masterdata;

                if (masterdata == null)
                {
                    lock (_lock)
                    {
                        masterdata = _masterdata ?? (_masterdata = new MasterdataContext());
                    }
                }

                return masterdata;
            }
        }

        public static MetadataContext Metadata
        {
            get
            {
                var metadata = _metadata;

                if (metadata == null)
                {
                    lock (_lock)
                    {
                        metadata = _metadata ?? (_metadata = new MetadataContext());
                    }
                }

                return metadata;
            }
        }

        public static NavigationContext Navigation
        {
            get
            {
                var navigation = _navigation;

                if (navigation == null)
                {
                    lock (_lock)
                    {
                        navigation = _navigation ?? (_navigation = new NavigationContext());
                    }
                }

                return navigation;
            }
        }
    }
}