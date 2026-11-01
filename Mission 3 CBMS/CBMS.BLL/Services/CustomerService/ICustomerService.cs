using CBMS.BLL.DTOs.CustomerDto;

namespace CBMS.BLL.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<CustomerReadDto> AddAsync(CustomerWriteDto dto);
        Task<IEnumerable<CustomerReadDto>> GetAllAsync();
        Task<CustomerReadDto?> GetByIdAsync(int id);
        Task<CustomerReadDto?> UpdateAsync(int id, CustomerWriteDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
