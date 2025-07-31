namespace BusinessLayer.Services;

public interface IGenericService<TViewDto, TCreateDto>
{
    Task<IEnumerable<TViewDto>> GetAllAsync();
    Task<TViewDto?> GetByIdAsync(uint id);
    Task<TViewDto> CreateAsync(TCreateDto dto);
    Task UpdateAsync(TViewDto dto);
    Task DeleteAsync(uint id);
    Task SaveAsync();
}