using Infrastructure.Repository;
using AutoMapper;
using Infrastructure.UnitOfWork;
using Domain.Entities;

namespace BusinessLayer.Services;
public abstract class GenericService<TEntity, TViewDto, TCreateDto> : IGenericService<TViewDto, TCreateDto>
    where TEntity : class, IEntity
{
    protected readonly IGenericRepository<TEntity> _repository;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    protected GenericService(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TViewDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(MapToViewDto);
    }

    public virtual async Task<TViewDto?> GetByIdAsync(uint id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity == null ? default : MapToViewDto(entity);
    }

    public virtual async Task<TViewDto> CreateAsync(TCreateDto dto)
    {
        ValidateCreateDto(dto);

        var entity = _mapper.Map<TEntity>(dto);
        await _repository.AddAsync(entity);
        await SaveAsync();

        return MapToViewDto(entity);
    }

    public virtual async Task UpdateAsync(TViewDto dto)
    {
        ValidateUpdateDto(dto);

        var existing = await _repository.GetByIdAsync(GetId(dto));
        if (existing == null) throw new InvalidOperationException($"{typeof(TEntity).Name} not found");

        MapToEntity(dto, existing);

        await _repository.UpdateAsync(existing);
    }

    public virtual async Task DeleteAsync(uint id)
    {
        await _repository.DeleteAsync(id);
    }

    public virtual async Task SaveAsync() => await _unitOfWork.CommitAsync();

    protected abstract TViewDto MapToViewDto(TEntity entity);
    protected abstract void MapToEntity(TViewDto dto, TEntity entity);
    protected abstract uint GetId(TViewDto dto);
    protected virtual void ValidateCreateDto(TCreateDto dto) { }
    protected virtual void ValidateUpdateDto(TViewDto dto) { }
}
