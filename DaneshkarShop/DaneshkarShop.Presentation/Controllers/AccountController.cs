using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.SiteSode.Account;
using DaneshkarShop.Domain.Entitties.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.Presentation.Controllers;

public class AccountController : Controller
{
    #region Ctor

    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
            _userService = userService;
    }

    #endregion

    #region Register

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Register(UserRegisterDTO userDTO)
    {
        if (ModelState.IsValid)
        {
            if (_userService.IsExistUserByMobile(userDTO.Mobile) == false)
            {
                //Object Mapping
                User user = new User()
                {
                    Mobile = userDTO.Mobile.Trim(),
                    Password = PasswordHelper.EncodePasswordMd5(userDTO.Password),
                    Username = userDTO.Username,
                };

                //Add User To Data Base 
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        return View();
    }

    #endregion

    #region Login

    #endregion

    #region Log Out

    #endregion
}
