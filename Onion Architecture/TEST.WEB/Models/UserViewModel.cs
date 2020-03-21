using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.WEB.Models
{
    public class UserViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
