using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Models;

namespace KYHBPA.Controllers
{
    public class EventController : Controller
    {
        //Refer to this link in order to set up the Calendar.
        //http://scheduler-net.com/docs/simple-.net-mvc-application-with-scheduler.html#step_2_add_the_scheduler_reference

        public readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            //try { 
            //var scheduler = new DHXScheduler(this); //initializes dhtmlxScheduler
            //scheduler.LoadData = true;// allows loading data
            //scheduler.EnableDataprocessor = true;// enables DataProcessor in order to enable implementation CRUD operations

            //    return View(scheduler);
            //}
            //catch (Exception ex)
            //{
            //    if (ex != null)
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }                
            //}

            //return RedirectToAction("Index", "Home");
            return View("Calendar");
        }

        public JsonResult Data()
        {
            //Using Dxhtml JavaScript Edition (open source)
            var events = db.Events;

            var formatedEvents = new List<object>();
            foreach (var ev in events)
            {
                var formattingEvent = new
                {
                    id = ev.Id,
                    start_date = ev.StartDate.ToString(),
                    end_date = ev.EndDate.ToString(),
                    text = ev.Description
                };
                formatedEvents.Add(formattingEvent);
            }



            return Json(formatedEvents, JsonRequestBehavior.AllowGet);

            //Using Dxhtml MVC Scheduler Edition (free trial)
            //events for loading to scheduler
            //return new SchedulerAjaxData(_db.Events);
        }

        public ActionResult Save(string id, string text, string start_date, string end_date)
        {

            var existingEvent = db.Events.FirstOrDefault(e => e.Id.ToString() == id);
            var newStartDate = Convert.ToDateTime(start_date);
            var newEndDate = Convert.ToDateTime(end_date);


            if (existingEvent != null)
            {
                existingEvent.StartDate = newStartDate;
                existingEvent.EndDate = newEndDate;
                existingEvent.Description = text;
            }
            else
            {

                var newEvent = new Event()
                {
                    StartDate = newStartDate,
                    EndDate = newEndDate,
                    Description = text
                };
                db.Events.Add(newEvent);
            }

            db.SaveChanges();



            return View("Calendar");
        }

        public ActionResult Delete(string id, string text, string start_date, string end_date)
        {

            var existingEvent = db.Events.FirstOrDefault(e => e.Id.ToString() == id);
            var newStartDate = Convert.ToDateTime(start_date);
            var newEndDate = Convert.ToDateTime(end_date);

            if (existingEvent != null)
            {
                db.Events.Remove(existingEvent);
                db.SaveChanges();
            }

            return View("Calendar");
        }


        //public ActionResult Save(Event updatedEvent, FormCollection formData)
        //{
        //    var action = new DataAction(formData);

        //    try
        //    {
        //        switch (action.Type)
        //        {
        //            case DataActionTypes.Insert: // your Insert logic
        //                _db.Events.Add(updatedEvent);
        //                break;
        //            case DataActionTypes.Delete: // your Delete logic
        //                updatedEvent = _db.Events.SingleOrDefault(ev => ev.id == updatedEvent.id);
        //                _db.Events.Remove(updatedEvent);
        //                break;
        //            default:// "update" // your Update logic
        //                updatedEvent = _db.Events.SingleOrDefault(
        //                ev => ev.id == updatedEvent.id);
        //                UpdateModel(updatedEvent);
        //                break;
        //        }
        //        _db.SaveChanges();
        //        action.TargetId = updatedEvent.id;
        //    }
        //    catch (Exception e)
        //    {
        //        action.Type = DataActionTypes.Error;
        //    }
        //    return (new AjaxSaveResponse(action));
        //}

    protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
