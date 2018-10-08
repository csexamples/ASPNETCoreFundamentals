﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Pages.Restaurants
{
    [Authorize]
    public class EditModel : PageModel
    {
        private IRestaurantData _restaurantData;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public EditModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public void OnGet(int id)
        {
            Restaurant = _restaurantData.Get(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _restaurantData.Update(Restaurant);
                return RedirectToAction("Index", "Home", new { id = Restaurant.Id });
            }

            return Page();
        }
    }
}
