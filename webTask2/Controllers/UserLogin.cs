using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webTask2.Models;

namespace webTask2.Controllers
{
    public class UserLogin
    {
        public static bool login(string userName,string password)
        {
            using (TaskDataModel db = new TaskDataModel())
            {
                return db.Users.Any(u=>u.UserName.Equals(userName,StringComparison.OrdinalIgnoreCase)
                    && u.Password==password);
            }
        }
    }
}