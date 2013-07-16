using NHibernate;

namespace RpgTome.Repositories
{
    public interface ICommand
    {
        void Execute(ISession session);
    }
}
