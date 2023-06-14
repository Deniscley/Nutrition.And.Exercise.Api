namespace Nutrition.And.Exercise.Borders.Interfaces.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
