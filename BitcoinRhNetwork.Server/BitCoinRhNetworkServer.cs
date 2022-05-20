using System;
using System.Web;
using System.Web.Hosting;
using System.Configuration;
using BitCoinRhNetwork.EF;
using BitCoinRhNetwork.Library;

namespace BitCoinRhNetwork.Server
{
    public class BitCoinRhNetworkServer : IRegisteredObject
    {
        static BitCoinRhNetworkServer()
        {
            Current = new BitCoinRhNetworkServer();
        }

        public static BitCoinRhNetworkServer Current { get; private set; }
        public EnvironmentTypes Environment { get; set; }

        public DataContextConfiguration DataContextConfiguration { get; private set; }

        public DbContextScopeFactory BitCoinRhNetworkDbContextScopeFactory;
        public AmbientDbContextLocator BitCoinRhNetworkDbContextLocator;

        public BitCoinRhNetworkException Errors;
        public BitCoinRhNetworkCache Cache;

        public string[] EntityFrameworkLevel2CacheExcludedTables;
        public EntityFrameworkLevel2CacheDefinitionTypes EntityFrameworkLevel2CacheDefinition;

        public enum EnvironmentTypes
        {
            Production = 0,
            Test = 1 //initialization of database
        }

        public enum EntityFrameworkLevel2CacheDefinitionTypes
        {
            CacheAllExcludedDefined = 0,
            CacheNothingOnlyDefined = 1
        }

        public void Initialize(string[] level2CacheExcludedTables = null,
                               EntityFrameworkLevel2CacheDefinitionTypes level2CacheDefinition = EntityFrameworkLevel2CacheDefinitionTypes.CacheAllExcludedDefined)
        {
            /* Cache */
            Cache = new BitCoinRhNetworkCache();
            EntityFrameworkLevel2CacheExcludedTables = level2CacheExcludedTables;
            EntityFrameworkLevel2CacheDefinition = level2CacheDefinition;
            /* Environment */
            Environment = InitializeEnvironment();

            /* Database */
            DataContextConfiguration = InitializeConfiguration();
            BitCoinRhNetworkDbContextScopeFactory = new DbContextScopeFactory();
            BitCoinRhNetworkDbContextLocator = new AmbientDbContextLocator();

            if (Environment == EnvironmentTypes.Test) //db init only with test
            {
                using (var context = new BitCoinRhNetworkDbContext())
                {
                    context.Initialize();
                }
            }

            /* Errors */
            Errors = new BitCoinRhNetworkException();
        }

        public void Stop(bool immediate)
        {
            
        }

        public static DataContextConfiguration InitializeConfiguration()
        {
            var settings = ConfigurationManager.AppSettings;

            return new DataContextConfiguration
                {
                    ContextName = settings["BitCoinRhNetwork:DbContextName"],
                    SchemaName = settings["BitCoinRhNetwork:DbSchemaName"]
                };
        }

        public static EnvironmentTypes InitializeEnvironment()
        {
            var settings = ConfigurationManager.AppSettings;

            var environment = EnvironmentTypes.Test;

            Enum.TryParse(settings["BitCoinRhNetwork:ServerEnvironment"], out environment);

            return environment;
        }

        public string GetHost
        {
            get
            {
                if (Environment == EnvironmentTypes.Production)
                {
                    return string.Format(
                        "{0}://{1}",
                        HttpContext.Current.Request.Url.Scheme,
                        HttpContext.Current.Request.Url.Host);
                }
                else
                {
                    return string.Format(
                        "{0}://{1}:{2}",
                        HttpContext.Current.Request.Url.Scheme,
                        HttpContext.Current.Request.Url.Host,
                        HttpContext.Current.Request.Url.Port);
                }
            }
        }
    }
}
