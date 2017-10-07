namespace Prova.Data.UoW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
