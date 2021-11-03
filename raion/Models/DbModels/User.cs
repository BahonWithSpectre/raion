using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace raion.Models.DbModels
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now.AddHours(13);
    }
}
