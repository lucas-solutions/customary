using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Custom
{
    using Custom.Diagnostics;
    using Custom.Data.Metadata;
    using Custom.Data.Persistence;
    using Raven.Json.Linq;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private ILogger Logger
        {
            get { return Global.Logger; }
        }

        protected void Application_BeginRequest()
        {
            var startTime = DateTime.Now;
            System.Web.HttpContext.Current.Items["SessionStartTime"] = (Nullable<DateTime>)startTime;
        }

        protected void Application_EndRequest()
        {
            System.Web.HttpContext.Current.Items["SessionStartTime"] = null;
            System.Web.HttpContext.Current.Items["RavenSession"] = null;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            BinderConfig.RegisterBinders(ModelBinders.Binders);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //Loggly.LogglyConfiguration.Configure(c => c.AuthenticateWith("", ""));

            Logger.Log<AppLog>().Info("Application_Start");

            var perfCounterMgr = new DiagnosticsManager();
            /*perfCounterMgr.Create(Server.MapPath("~/bin"), "*.dll");
            Application[DiagnosticsManager.PerformanceCounterManagerApplicationKey] = perfCounterMgr;*/

            ControllerBuilder.Current.SetControllerFactory(typeof(Web.Mvc.ControllerFactory));

            var metadataDir = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Seeds/Metadata");
            var metadataSeeds = new System.IO.DirectoryInfo(metadataDir).GetFiles("*.js").ToArray();
            foreach (var file in metadataSeeds)
            {
                Global.Metadata.Store.Import(new System.IO.FileInfo(file.FullName));
            }

            var cultures = Cultures(System.Globalization.CultureTypes.AllCultures).Values().OfType<RavenJObject>();

            //Global.Metadata.Store.Import(cultures);

            /*using (var fileStream = System.IO.File.Open(metadataDir + "\\Metadata.zip", System.IO.FileMode.Open))
            {
                DocumentArchive.Import(Global.Metadata.Store, fileStream);
            }*/

            var dictionary = Data.DataDictionary.Current;

            var descriptor = dictionary.Describe("Metadata");

            /*var globalizationSeeds = new System.IO.DirectoryInfo(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Seeds/Globalization")).GetFiles("*.js").ToArray();
            foreach (var file in globalizationSeeds)
            {
                Repositories.GlobalizationContext.Import(file.FullName);
            }*/

            using (var fileStream = System.IO.File.Create(metadataDir + "\\Metadata.zip", 65536, System.IO.FileOptions.WriteThrough))
            {
                DocumentArchive.Export(Global.Metadata.Store, fileStream, System.IO.Compression.CompressionLevel.Optimal);
            }
        }

        private RavenJArray Cultures(System.Globalization.CultureTypes cultureTypes)
        {
            var culturesJArray = new RavenJArray();

            var cultureInfoGUID = typeof(System.Globalization.CultureInfo).GUID.ToByteArray();
            foreach (var culture in System.Globalization.CultureInfo.GetCultures(cultureTypes))
            {
                var cultureJObject = new Raven.Json.Linq.RavenJObject();

                culturesJArray.Add(cultureJObject);

                var id = typeof(System.Globalization.CultureInfo).GUID.ToByteArray();
                Array.Copy(BitConverter.GetBytes((culture.LCID ^ culture.Name.GetHashCode() ^ BitConverter.ToInt32(id, 12))), 0, id, 12, 4);

                cultureJObject["key"] = "Culture/" + new Guid(id).ToString("D");
                cultureJObject["Id"] = new RavenJValue(new Guid(id));
                cultureJObject["Name"] = culture.Name;
                cultureJObject["LCID"] = culture.LCID;

                var cultureNumberFormat = new RavenJObject();
                cultureJObject[""] = cultureNumberFormat;

                cultureNumberFormat["CurrencyDecimalDigits"] = culture.NumberFormat.CurrencyDecimalDigits;
                cultureNumberFormat["CurrencyDecimalSeparator"] = culture.NumberFormat.CurrencyDecimalSeparator;
                cultureNumberFormat["CurrencyGroupSeparator"] = culture.NumberFormat.CurrencyGroupSeparator;
                cultureNumberFormat["CurrencyGroupSizes"] = new RavenJArray(culture.NumberFormat.CurrencyGroupSizes);
                cultureNumberFormat["CurrencyNegativePattern"] = culture.NumberFormat.CurrencyNegativePattern;
                cultureNumberFormat["CurrencyPositivePattern"] = culture.NumberFormat.CurrencyPositivePattern;
                cultureNumberFormat["CurrencySymbol"] = culture.NumberFormat.CurrencySymbol;
                cultureNumberFormat["DigitSubstitution"] = System.Enum.GetName(typeof(System.Globalization.DigitShapes), culture.NumberFormat.DigitSubstitution);
                cultureNumberFormat["IsReadOnly"] = culture.NumberFormat.IsReadOnly;
                cultureNumberFormat["NaNSymbol"] = culture.NumberFormat.NaNSymbol;
                cultureNumberFormat["NativeDigits"] = new RavenJArray(culture.NumberFormat.NativeDigits);
                cultureNumberFormat["NegativeInfinitySymbol"] = culture.NumberFormat.NegativeInfinitySymbol;
                cultureNumberFormat["NegativeSign"] = culture.NumberFormat.NegativeSign;
                cultureNumberFormat["NumberDecimalDigits"] = culture.NumberFormat.NumberDecimalDigits;
                cultureNumberFormat["NumberDecimalSeparator"] = culture.NumberFormat.NumberDecimalSeparator;
                cultureNumberFormat["NumberGroupSeparator"] = culture.NumberFormat.NumberGroupSeparator;
                cultureNumberFormat["NumberGroupSizes"] = new RavenJArray(culture.NumberFormat.NumberGroupSizes);
                cultureNumberFormat["NumberNegativePattern"] = culture.NumberFormat.NumberNegativePattern;
                cultureNumberFormat["PercentDecimalDigits"] = culture.NumberFormat.PercentDecimalDigits;
                cultureNumberFormat["PercentDecimalSeparator"] = culture.NumberFormat.PercentDecimalSeparator;
                cultureNumberFormat["PercentGroupSeparator"] = culture.NumberFormat.PercentGroupSeparator;
                cultureNumberFormat["PercentGroupSizes"] = new RavenJArray(culture.NumberFormat.PercentGroupSizes);
                cultureNumberFormat["PercentNegativePattern"] = culture.NumberFormat.PercentNegativePattern;
                cultureNumberFormat["PercentPositivePattern"] = culture.NumberFormat.PercentPositivePattern;
                cultureNumberFormat["PercentSymbol"] = culture.NumberFormat.PercentSymbol;
                cultureNumberFormat["PerMilleSymbol"] = culture.NumberFormat.PerMilleSymbol;
                cultureNumberFormat["PositiveInfinitySymbol"] = culture.NumberFormat.PositiveInfinitySymbol;
                cultureNumberFormat["PositiveSign"] = culture.NumberFormat.PositiveSign;

                var optionalCalendarsInfoJObject = new RavenJArray();
                cultureJObject["OptionalCalendars"] = optionalCalendarsInfoJObject;
                foreach (var calendar in culture.OptionalCalendars)
                {
                    var calendarJObject = new RavenJObject();
                    optionalCalendarsInfoJObject.Add(calendarJObject);
                    calendarJObject["AlgorithmType"] = System.Enum.GetName(typeof(System.Globalization.CalendarAlgorithmType), calendar.AlgorithmType);
                    calendarJObject["Eras"] = new RavenJArray(calendar.Eras);
                    calendarJObject["MaxSupportedDateTime"] = calendar.MaxSupportedDateTime;
                    calendarJObject["MinSupportedDateTime"] = calendar.MinSupportedDateTime;
                    calendarJObject["TwoDigitYearMax"] = new RavenJArray(calendar.TwoDigitYearMax);
                }

                var parent = typeof(System.Globalization.CultureInfo).GUID.ToByteArray();
                Array.Copy(BitConverter.GetBytes((culture.Parent.LCID ^ culture.Parent.Name.GetHashCode() ^ BitConverter.ToInt32(parent, 12))), 0, parent, 12, 4);
                cultureJObject["Parent"] = new RavenJValue(new Guid(parent));

                var textInfoJObject = new RavenJObject();
                cultureJObject["TextInfo"] = textInfoJObject;
                textInfoJObject["ANSICodePage"] = culture.TextInfo.ANSICodePage;
                textInfoJObject["CultureName"] = culture.TextInfo.CultureName;
                textInfoJObject["EBCDICCodePage"] = culture.TextInfo.EBCDICCodePage;
                textInfoJObject["IsReadOnly"] = culture.TextInfo.IsReadOnly;
                textInfoJObject["IsRightToLeft"] = culture.TextInfo.IsRightToLeft;
                textInfoJObject["LCID"] = culture.TextInfo.LCID;
                textInfoJObject["ListSeparator"] = culture.TextInfo.ListSeparator;
                textInfoJObject["MacCodePage"] = culture.TextInfo.MacCodePage;
                textInfoJObject["OEMCodePage"] = culture.TextInfo.OEMCodePage;

                cultureJObject["ThreeLetterISOLanguageName"] = culture.ThreeLetterISOLanguageName;
                cultureJObject["ThreeLetterWindowsLanguageName"] = culture.ThreeLetterWindowsLanguageName;
                cultureJObject["TwoLetterISOLanguageName"] = culture.TwoLetterISOLanguageName;
                cultureJObject["UseUserOverride"] = culture.UseUserOverride;

                var cultureTitleJObject = new Raven.Json.Linq.RavenJObject();
                cultureJObject["Title"] = cultureTitleJObject;

                cultureTitleJObject[culture.Name] = culture.NativeName;
                cultureTitleJObject["en"] = culture.EnglishName;
            }

            return culturesJArray;
        }
    }
}