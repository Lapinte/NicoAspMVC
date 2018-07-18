using Roomax.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomax.Utils.Validators
{
    public class ExistingEmail : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            using (RoomaxDbContext db = new RoomaxDbContext())
            {
                return !db.Users.Any(x => x.Mail == value.ToString());
            }
        }
    }
}