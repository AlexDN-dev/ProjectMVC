using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public UserController(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
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

    [HttpGet]
    public IActionResult Edit(int id)
    {
        List<RoleDto> roles = _roleService.GetAllRoles();
        UserDto? user = _userService.GetUserById(id);
        if (user is null)
        {
            return NotFound();
        }

        UserEdit ue = new UserEdit
        {
            Roles = roles,
            User = user,
            SelectedRoleIds = user.Role.Select(r => r.Id).ToList()
        };

        return View(ue);
    }
    [HttpPost]
    public IActionResult Edit(UserEdit model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        model.Roles = _roleService.GetAllRoles();
        model.User.Role = model.Roles
            .Where(r => model.SelectedRoleIds.Contains(r.Id))
            .ToList();

        _userService.EditUser(model.User);
        TempData["Message"] = "Succès de l'édition de l'utilisateur";
        return RedirectToAction("Index");
    }
}

public class UserEdit
{
    public List<RoleDto> Roles { get; set; } = new();

    public UserDto User { get; set; } = null!;

    public List<int> SelectedRoleIds { get; set; } = new();
}