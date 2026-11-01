using CBMS.BLL.DTOs.HallDto;
using CBMS.BLL.Exceptions;
using CBMS.DAL;
using CBMS.DAL.Repositories;

namespace CBMS.BLL.Services.HallService
{
    public class HallService : IHallService
    {
        private readonly IHallRepository _hallRepository;

        public HallService(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }

        public async Task<HallReadDto> AddAsync(HallCreateDto dto)
        {
            if (dto is null)
                throw new bllException("Hall data is required.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new bllException("Hall name is required.");

            if (dto.Capacity <= 0)
                throw new bllException("Hall capacity must be greater than zero.");

            var hall = new Hall
            {
                Name = dto.Name.Trim(),
                Capacity = dto.Capacity
            };

            _hallRepository.Add(hall);
            await _hallRepository.SaveChangesAsync();

            return new HallReadDto
            {
                Id = hall.Id,
                Name = hall.Name,
                Capacity = hall.Capacity
            };
        }

    }
}
