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
    }
}
