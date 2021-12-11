namespace Pelikula.API.Validation
{
    public interface IBaseValidator<Entity>
        where Entity : class
    {
        void ValidateEntityExists(int id);
    }
}
