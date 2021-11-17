using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace raion.Models.apiModels
{
    public class apiModel
    {
    }

    public class Login
    {
        [Required]
        public string login { get; set; }
        [Required]
        public string password { get; set; }
    }

    public class Register
    {
        public string login { get; set; }
        public string password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }


    public class Error
    {
        public string id { get; set; }
        public string error { get; set; }
    }
}
