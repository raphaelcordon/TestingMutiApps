using AutoMapper;
using WebApi.Infrastructure;
using WebApi.Infrastructure.Dtos;
using WebApi.Models;

namespace WebApi.Services
{
    public class UserServices
    {
        private IMapper _mapper;
        private UserDbContext _context;

        public UserServices(IMapper mapper, UserDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void CreateUser(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IList<ReadUserDto> GetUsers()
        {
            return _mapper.Map<List<ReadUserDto>>(_context.Users.ToList());
        }

		public Task PutUser(UpdateUserDto dto)
		{
			var user = _context.Users.FirstOrDefault(user => user.Id == dto.Id);
            if (user != null)
            {
                _mapper.Map(dto, user);
                _context.SaveChanges();
				return Task.CompletedTask;
			}
			throw new Exception("No user detected");
		}

        public Task DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            if(user != null)
            {
				_context.Users.Remove(user);
                _context.SaveChanges();
				return Task.CompletedTask;
			}
            throw new Exception("No user detected");
        }

		public object GetOneUser(int id)
		{
			var user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                return _mapper.Map<ReadUserDto>(user);
            }
			throw new Exception("No user detected");
		}
	}
}
