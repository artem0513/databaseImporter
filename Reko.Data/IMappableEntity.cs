namespace Reko.Data
{
    public interface IMappableEntity<out TEntity, TDto, TId> : IEntity<TId>
    {
        TDto ToDto();
        TEntity FromDto(TDto dto);
    }
}