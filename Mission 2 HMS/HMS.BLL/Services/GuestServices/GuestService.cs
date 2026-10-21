using HMS.BLL.DTOs;
using HMS.DAL;

namespace HMS.BLL.Services
{
    public class GuestService : IGuestServices
    {
        private readonly IGuestRepository _repo;
        private readonly IStaffRepository _staffRepository;
        private readonly IRoomRepositorey _roomRepository;
        public GuestService(IGuestRepository repo, IStaffRepository staffrepo, IRoomRepositorey roomRepository)
        {
            _repo = repo;
            _staffRepository = staffrepo;
            _roomRepository = roomRepository;
        }

        public async Task<int> Add(GuestCreateDto guest)
        {
            if (guest is null)
                throw new bllException("Invalid data");

            var isExist = (await _repo.GetAll()).Any(x => x.Email == guest.Email);
            if (isExist)
                throw new bllException("This email already exists");

            Room? room = null;
            if (guest.Room is not null && !string.IsNullOrWhiteSpace(guest.Room.RoomNumber))
            {
                room = new Room
                {
                    RoomNumber = guest.Room.RoomNumber,
                    Type = guest.Room.Type
                };
            }

            var newGuest = new Guest
            {
                Email = guest.Email,
                Name = guest.Name,
                Room = room
            };

            if (guest.StaffIds is not null && guest.StaffIds.Any())
            {
                foreach (var item in guest.StaffIds)
                {
                    var staff = await _staffRepository.GetById(item);
                    if (staff is not null)
                        newGuest.Staffs.Add(staff);
                }
            }

            _repo.Add(newGuest);
            await _repo.SaveChangesAsync();
            return newGuest.Id;
        }

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
                return false;

            var guest = await _repo.GetById(id);
            if (guest is null)
                return false;

            _repo.Delete(guest);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GuestReadDto>> GetAll()
        {
            var guests = await _repo.GetAll();

            return guests.Select(x => new GuestReadDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Room = x.Room != null ? new RoomReadDto
                {
                    Id = x.Room.Id,
                    RoomNumber = x.Room.RoomNumber,
                    Type = x.Room.Type
                } : null,
                StaffMembers = x.Staffs.Select(s => new StaffReadDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    Phone = s.Phone,
                    DepartmentId = s.DepartmentId,
                    DepartmentName = s.Department?.Name ?? "No Department"
                }).ToList()
            });
        }

        public async Task<bool> Update(int id, GuestCreateDto dto)
        {
            if (id <= 0 || dto is null)
                return false;

            var guest = await _repo.GetById(id);
            if (guest is null)
                return false;

            guest.Email = dto.Email;
            guest.Name = dto.Name;

            if (dto.Room is not null)
            {
                if (guest.Room is not null)
                {
                    guest.Room.RoomNumber = dto.Room.RoomNumber;
                    guest.Room.Type = dto.Room.Type;
                }
                else
                {
                    guest.Room = new Room
                    {
                        RoomNumber = dto.Room.RoomNumber,
                        Type = dto.Room.Type
                    };
                }
            }

            if (dto.StaffIds is not null)
            {
                guest.Staffs.Clear();
                if (dto.StaffIds.Any())
                {
                    foreach (var item in dto.StaffIds)
                    {
                        var staff = await _staffRepository.GetById(item);
                        if (staff is not null)
                            guest.Staffs.Add(staff);
                    }
                }
            }

            _repo.Update(guest);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
