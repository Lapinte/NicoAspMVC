
using Roomax.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomax.Areas.BackOffice.Controllers
{
    public class BaseController : Controller
    {
        protected RoomaxDbContext db = new RoomaxDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        protected void DisplayMessage(string message, MessageType type)
        {
            TempData["Message"] = message;
            switch (type)
            {
                case MessageType.SUCCESS:
                    TempData["MessageType"] = "success";
                    break;
                case MessageType.WARNING:
                    TempData["MessageType"] = "warning";
                    break;
                case MessageType.ERROR:
                    TempData["MessageType"] = "danger";
                    break;
            }
        }
    }

    public enum MessageType
    {
        SUCCESS,
        WARNING,
        ERROR
    }
}