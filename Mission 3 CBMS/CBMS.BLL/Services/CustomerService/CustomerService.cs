using CBMS.BLL.DTOs.CustomerDto;
using CBMS.BLL.DTOs.MovieDto;
using CBMS.BLL.DTOs.TicketDto;
using CBMS.BLL.Exceptions;
using CBMS.DAL;
using CBMS.DAL.Repositories;

namespace CBMS.BLL.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ITicketRepositry _ticketRepository;

        public CustomerService(
            ICustomerRepository customerRepository,
            IMovieRepository movieRepository,
            ITicketRepositry ticketRepository)
        {
            _customerRepository = customerRepository;
            _movieRepository = movieRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<CustomerReadDto> AddAsync(CustomerWriteDto dto)
        {
            if (dto is null)
                throw new bllException("Customer data is required.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new bllException("Customer name is required.");

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new bllException("Customer email is required.");

            var customer = new Customer
            {
                Name = dto.Name.Trim(),
                Email = dto.Email.Trim()
            };

            if (dto.MovieId.HasValue && dto.MovieId.Value > 0)
            {
                var movie = await _movieRepository.GetById(dto.MovieId.Value);
                if (movie == null)
                    throw new bllException("This movie is not found");
                customer.Movies.Add(movie);
            }

            if (dto.ticket != null)
            {
                customer.Ticket = new Ticket
                {
                    Price = dto.ticket.Price,
                    SeatNumber = dto.ticket.SeatNumber,
                    ShowTime = dto.ticket.ShowTime
                };
            }

            _customerRepository.Add(customer);
            await _customerRepository.SaveChangesAsync();

            return new CustomerReadDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Ticket = customer.Ticket != null ? new TicketReadDto
                {
                    Id = customer.Ticket.Id,
                    SeatNumber = customer.Ticket.SeatNumber,
                    Price = customer.Ticket.Price,
                    ShowTime = customer.Ticket.ShowTime
                } : null,
                Movies = customer.Movies.Select(m => new MovieReadDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Duration = m.Duration,
                    HallName = m.Hall?.Name ?? string.Empty
                }).ToList()
            };
        }

        public async Task<IEnumerable<CustomerReadDto>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(customer => new CustomerReadDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Ticket = customer.Ticket != null ? new TicketReadDto
                {
                    Id = customer.Ticket.Id,
                    SeatNumber = customer.Ticket.SeatNumber,
                    Price = customer.Ticket.Price,
                    ShowTime = customer.Ticket.ShowTime
                } : null,
                Movies = customer.Movies.Select(m => new MovieReadDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Duration = m.Duration,
                    HallName = m.Hall?.Name ?? string.Empty
                }).ToList()
            });
        }

        public async Task<CustomerReadDto?> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetById(id);
            if (customer is null) return null;

            return new CustomerReadDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Ticket = customer.Ticket != null ? new TicketReadDto
                {
                    Id = customer.Ticket.Id,
                    SeatNumber = customer.Ticket.SeatNumber,
                    Price = customer.Ticket.Price,
                    ShowTime = customer.Ticket.ShowTime
                } : null,
                Movies = customer.Movies.Select(m => new MovieReadDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Duration = m.Duration,
                    HallName = m.Hall?.Name ?? string.Empty
                }).ToList()
            };
        }

        public async Task<CustomerReadDto?> UpdateAsync(int id, CustomerWriteDto dto)
        {
            if (dto is null) return null;

            var customer = await _customerRepository.GetById(id);
            if (customer is null)
                throw new bllException("This customer is not found");

            customer.Name = dto.Name;
            customer.Email = dto.Email;

            if (dto.MovieId.HasValue && dto.MovieId.Value > 0)
            {
                var movie = await _movieRepository.GetById(dto.MovieId.Value);
                if (movie == null)
                    throw new bllException("This movie is not found");

                customer.Movies.Clear();
                customer.Movies.Add(movie);
            }

            if (dto.ticket != null)
            {
                if (customer.Ticket != null)
                {
                    customer.Ticket.SeatNumber = dto.ticket.SeatNumber;
                    customer.Ticket.ShowTime = dto.ticket.ShowTime;
                    customer.Ticket.Price = dto.ticket.Price;
                }
                else
                {
                    customer.Ticket = new Ticket
                    {
                        SeatNumber = dto.ticket.SeatNumber,
                        ShowTime = dto.ticket.ShowTime,
                        Price = dto.ticket.Price
                    };
                }
            }

            _customerRepository.Update(customer);
            await _customerRepository.SaveChangesAsync();

            return new CustomerReadDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Ticket = customer.Ticket != null ? new TicketReadDto
                {
                    Id = customer.Ticket.Id,
                    SeatNumber = customer.Ticket.SeatNumber,
                    Price = customer.Ticket.Price,
                    ShowTime = customer.Ticket.ShowTime
                } : null,
                Movies = customer.Movies.Select(m => new MovieReadDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Duration = m.Duration,
                    HallName = m.Hall?.Name ?? string.Empty
                }).ToList()
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _customerRepository.GetById(id);
            if (customer is null) return false;

            _customerRepository.Delete(customer);
            await _customerRepository.SaveChangesAsync();
            return true;
        }
    }
}
