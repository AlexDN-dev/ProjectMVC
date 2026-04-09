using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        List<UserDto> users = _userService.GetAllUsers();
        return View(users);
    }

    public IActionResult Details(int id)
    {
        UserDto? user = _userService.GetUserById(id);
        if (user is null)
        {
            return NotFound();
        }

        return View(user);
    }
    [HttpGet]
    public IActionResult AddUser()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddUser(CreateUserDto user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        bool isSuccess = _userService.CreateUser(user);
        string message  = isSuccess == true
            ? "L'utilisateur à bien été rajouté."
            : "L'utilisateur n'a pas pu être ajouté.";
        TempData["Message"] = message;

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        UserDto? user = _userService.GetUserById(id);
        if (user is null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpPost]
    public IActionResult Delete(UserDto user)
    {
        bool isSuccess = _userService.DeleteUserById(user.Id);
        if (isSuccess)
        {
            TempData["Message"] = "Succès de la suppression de l'utilisateur ";
        }
        else
        {
            TempData["Message"] = "Impossible de supprimer cet utilisateur";
        }

        return RedirectToAction("Index");
    }
}