using NHibernate.Context;
using RomViewer.Core;
using NHibernate.Bytecode;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using SharpLite.NHibernateProvider;

namespace RomViewer.NHibernateProvider
{
    public class NHibernateInitializer
    {
        public static Configuration Initialize() {
            Configuration configuration = new Configuration();

            configuration
                .Proxy(p => p.ProxyFactoryFactory<DefaultProxyFactoryFactory>())
                .DataBaseIntegration(db => {
                    db.ConnectionStringName = "RomViewerConnectionString";
                    db.Dialect<MsSql2008Dialect>();
                })
                .AddAssembly(typeof(ActionConfirmation<>).Assembly)
                .CurrentSessionContext<CallSessionContext>();
                //.CurrentSessionContext<LazySessionContext>();

            ConventionModelMapper mapper = new ConventionModelMapper();
            mapper.WithConventions(configuration);

            return configuration;
        }
    }
}