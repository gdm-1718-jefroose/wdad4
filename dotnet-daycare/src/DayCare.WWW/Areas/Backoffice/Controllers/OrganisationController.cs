using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DayCare.Db;
using DayCare.Models;
using DayCare.Models.Security;
using DayCare.Models.Utilities;
using DayCare.Models.ViewModels;

namespace DayCare.WWW.Areas.Backoffice.Controllers 
{
    [Area("Backoffice")]
    public class OrganisationController : BaseController 
    {
        public OrganisationController(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {
        }

        public async Task<IActionResult> Index() 
        {
            var model = await ApplicationDbContext.Organisations.OrderBy(o => o.Name).ToListAsync();

            if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
            {
                return PartialView("_ListPartial", model);
            }
            
            return View(model);

        }

        [HttpGet]
        public IActionResult Create() 
        {
            var model = new Organisation();

            return View(model);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Organisation model)
        {
            var alert = new Alert();
            try
            {
                if(!ModelState.IsValid) {
                    alert.Message = alert.ExceptionMessage = ApplicationDbContextMessage.INVALID;
                    throw new Exception();
                }
                    
                
                ApplicationDbContext.Organisations.Add(model);
                if (await ApplicationDbContext.SaveChangesAsync() == 0)
                {
                    alert.Message = alert.ExceptionMessage = ApplicationDbContextMessage.CREATENOK;
                    throw new Exception();
                }   

                alert.Message = ApplicationDbContextMessage.CREATEOK;
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                alert.Type = AlertType.Error;
                alert.ExceptionMessage = ex.Message;

                ModelState.AddModelError(string.Empty, alert.ExceptionMessage);
            }
            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(Int16? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(400);
            }
            
            var model = await ApplicationDbContext.Organisations.FirstOrDefaultAsync(m => m.Id == id);
            
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Organisation model)
        {
            var alert = new Alert();
            try 
            {
                if(!ModelState.IsValid)
                {
                    alert.Message = alert.ExceptionMessage = ApplicationDbContextMessage.INVALID;
                    throw new Exception();
                }   
                    
                var originalModel = ApplicationDbContext.Organisations.FirstOrDefault(m => m.Id == model.Id);
                
                if(originalModel == null) 
                {
                    alert.Message = alert.ExceptionMessage = ApplicationDbContextMessage.NOTEXISTS;
                    throw new Exception();
                }
                    
                originalModel.Name = model.Name;
                originalModel.Description = model.Description;
                
                ApplicationDbContext.Organisations.Attach(originalModel);
                ApplicationDbContext.Entry(originalModel).State = EntityState.Modified;
                
                if (await ApplicationDbContext.SaveChangesAsync() == 0)
                {
                    alert.Message = alert.ExceptionMessage = ApplicationDbContextMessage.EDITNOK;
                    throw new Exception();
                } 
                
                alert.Message = ApplicationDbContextMessage.EDITOK;
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                alert.Type = AlertType.Error;
                alert.ExceptionMessage = ex.Message;

                ModelState.AddModelError(string.Empty, alert.ExceptionMessage);
            }
            return View(model);
        }

        [HttpGet("[area]/[controller]/[action]/{id:int}")]
        public async Task<IActionResult> Delete(Int16 id, [FromQuery] ActionType actionType)
        {
            var model = await ApplicationDbContext.Organisations.FirstOrDefaultAsync(m => m.Id == id);
            
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            
            var viewModel = new ActionOrganisationViewModel()
            {
                BaseEntity = model,
                ActionType = actionType
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ActionOrganisationViewModel model)
        {
            var alert = new Alert();// Alert
            try
            {
                var originalModel = ApplicationDbContext.Organisations.FirstOrDefault(m => m.Id == model.BaseEntity.Id);
                
                if(originalModel == null)
                {
                    alert.Message = alert.ExceptionMessage = ApplicationDbContextMessage.NOTEXISTS;
                    throw new Exception();
                }

                switch(model.ActionType)
                {
                    case ActionType.Delete:
                        alert.Message = ApplicationDbContextMessage.DELETEOK;
                        ApplicationDbContext.Entry(originalModel).State = EntityState.Deleted;
                        break;
                    case ActionType.SoftDelete:
                        alert.Message = ApplicationDbContextMessage.SOFTDELETEOK;
                        originalModel.DeletedAt = DateTime.Now;
                        ApplicationDbContext.Entry(originalModel).State = EntityState.Modified;
                        break;
                    case ActionType.SoftUnDelete:
                        alert.Message = ApplicationDbContextMessage.SOFTUNDELETEOK;
                        originalModel.DeletedAt = (Nullable<DateTime>)null;
                        ApplicationDbContext.Entry(originalModel).State = EntityState.Modified;
                        break;
                }

                
                if (await ApplicationDbContext.SaveChangesAsync() == 0)
                {                   
                    switch(model.ActionType)
                    {
                        case ActionType.Delete:
                            alert.Message = ApplicationDbContextMessage.DELETENOK;
                            break;
                        case ActionType.SoftDelete:
                            alert.Message = ApplicationDbContextMessage.SOFTDELETENOK;
                            break;
                        case ActionType.SoftUnDelete:
                            alert.Message = ApplicationDbContextMessage.SOFTUNDELETENOK;
                            break;
                    }
                    throw new Exception();
                } 

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(alert);
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                alert.Type = AlertType.Error;
                alert.ExceptionMessage = ex.Message;

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(alert);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }
    }
}