using NHibernate.Mapping.ByCode;

namespace RomViewer.NHibernateProvider.Overrides
{
    internal interface IOverride
    {
        void Override(ModelMapper mapper);
    }
}
