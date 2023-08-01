namespace Nutrition.And.Exercise.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
