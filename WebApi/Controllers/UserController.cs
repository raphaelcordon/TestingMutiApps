using Microsoft.AspNetCore.Mvc;
using WebApi.Infrastructure.Dtos;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private UserServices _userServices;

    public UserController(UserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserDto dto)
    {
        _userServices.CreateUser(dto);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetUsers() 
    {
        return Ok(_userServices.GetUsers());

    }
}
