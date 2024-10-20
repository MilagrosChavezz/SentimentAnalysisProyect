﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace SentimentAnalysis.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Login()
        {
            var redirectUrl = Url.Action("Predict", "Prediction");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, "Google");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return SignOut(new AuthenticationProperties { RedirectUri = Url.Action("Predict", "Prediction") },
                CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
    }
