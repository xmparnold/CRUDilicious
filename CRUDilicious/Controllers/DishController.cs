using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDilicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDilicious.Controllers;

public class DishController : Controller
{

    private CRUDiliciousContext _context;


    public DishController(CRUDiliciousContext context)
    {
        _context = context;
    }

    [HttpGet("/dishes/all")]
    public IActionResult All()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();

        return View("All", AllDishes);
    }


    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        return View("New");
    }

    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid == false) {
            return New();
        }

        _context.Dishes.Add(newDish);
        _context.SaveChanges();

        return RedirectToAction("All");
    }


    [HttpGet("/dishes/{dishId}")]
    public IActionResult ViewDish(int dishId)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

        if (dish == null)
        {
            return RedirectToAction("All");
        }

        return View("ViewDish", dish);
    }

    [HttpPost("/dishes/{deleteDishId}/delete")]
    public IActionResult Delete( int deleteDishId) 
    {
        Dish? dishToBeDeleted = _context.Dishes.FirstOrDefault(dish => dish.DishId == deleteDishId);

        if (dishToBeDeleted != null)
        {
            _context.Dishes.Remove(dishToBeDeleted);
            _context.SaveChanges();
        }

        return RedirectToAction("All");
    }

    [HttpGet("/dishes/{dishToBeEdited}/edit")]
    public IActionResult EditDish(int dishToBeEdited)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishToBeEdited);

        if (dish == null)
        {
            return RedirectToAction("All");
        }

        return View("Edit", dish);
    }


    [HttpPost("/dishes/{updatedDishId}/update")]
    public IActionResult UpdatePost(int updatedDishId, Dish updatedDish)
    {
        if (ModelState.IsValid == false)
        {
            return EditDish(updatedDishId);
        }

        Dish? dbDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == updatedDishId);

        if (dbDish == null)
        {
            return RedirectToAction("All");
        }

        dbDish.Name = updatedDish.Name;
        dbDish.Chef = updatedDish.Chef;
        dbDish.Tastiness = updatedDish.Tastiness;
        dbDish.Calories = updatedDish.Calories;
        dbDish.Description = updatedDish.Description;
        dbDish.UpdatedAt = DateTime.Now;

        _context.Dishes.Update(dbDish);
        _context.SaveChanges();

        return RedirectToAction("ViewDish", new { dishId = dbDish.DishId });
    }
}
