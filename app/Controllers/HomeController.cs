using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.DataAccess.Contracts;
using app.DataAccess.Implementations.Entities;
using app.Models;

namespace app.Controllers;

public class HomeController : Controller
{
    private readonly IToDoElementRepository _iToDoElementRepository;

    public HomeController(IToDoElementRepository context)
    {
        _iToDoElementRepository = context;
    }

    public IActionResult Index()
    {
        return View(_iToDoElementRepository.GetAll().ToList());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet, ActionName("Delete")]
    public IActionResult DeleteElement(int id)
    {
        _iToDoElementRepository.Remove(_iToDoElementRepository.GetById(id));
        _iToDoElementRepository.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost, ActionName("Add")]
    public IActionResult AddElement(string textElement)
    {
        var newToDoElement = new ToDoElement(textElement);
        newToDoElement.Completed = false; 
        _iToDoElementRepository.Add(newToDoElement);
        _iToDoElementRepository.SaveChanges();
        return Json(newToDoElement);
    }
    

    [HttpGet, ActionName("Finish")]
    public IActionResult FinishElement(int id)
    {
        var changedToDoElement = _iToDoElementRepository.GetById(id);
        changedToDoElement.Completed = true;
        _iToDoElementRepository.Update(changedToDoElement);
        _iToDoElementRepository.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpGet] 
    public IActionResult GetTask(string text)
    {
        var task = _iToDoElementRepository.Find(t => t.Text == text);
        if (task != null)
        {
            return Json(task);
        }
        else
        {
            return NotFound();
        }
    }
}