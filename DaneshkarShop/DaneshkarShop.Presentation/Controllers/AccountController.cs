﻿using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.SiteSode.Account;
using DaneshkarShop.Domain.Entitties.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DaneshkarShop.Presentation.Controllers;

public class AccountController : Controller
{
    #region Ctor

    private readonly IUserService _userService;
    private static readonly HttpClient client = new HttpClient();

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
            bool result = _userService.RegisterUser(userDTO);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        TempData["ErrorMessage"] = "کابری با شماره موبایل وارد شده در سیستم وجود دارد .";
        return View();
    }

    #endregion

    #region Login

    [HttpGet]
    public IActionResult Login(string ReturnUrl="")
    {
        UserLoginDTO returnModel = new UserLoginDTO();

        if (!string.IsNullOrEmpty(ReturnUrl))
        {
            returnModel.ReturnUrl = ReturnUrl;
        }

        return View(returnModel);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLoginDTO userDTO , string? amirName)
    {
        if (ModelState.IsValid)
        {
            var user = _userService.GetUserByMobile(userDTO.Mobile);

            if (user != null)
            {
                var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new (ClaimTypes.MobilePhone, user.Mobile),
                new (ClaimTypes.Name, user.Username),
            };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimIdentity);

                var authProps = new AuthenticationProperties();
                //authProps.IsPersistent = model.RememberMe;

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);

                if (!string.IsNullOrEmpty(amirName))
                {
                    return Redirect(amirName);
                }

                return RedirectToAction("Index", "Home");
            }
        }

        TempData["ErrorMessage"] = "کاربری با مشخصات وارد شده یافت نشده است.";
        return View();
    }

    #endregion

    #region Log Out

    [HttpGet("Logout")]
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index" , "Home");
    }

    #endregion

    #region CheckUserRoleForLogin

    public IActionResult ManageUserForLogin()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction(nameof(Login));
        }

        return RedirectToAction(nameof(LogOut));
    }

    #endregion
}
