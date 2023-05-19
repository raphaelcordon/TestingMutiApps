using System.ComponentModel.DataAnnotations;

namespace WebApi.Infrastructure.Dtos
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public DateTime ConsultingTime { get; set; } = DateTime.Now.Date;
    }
}
