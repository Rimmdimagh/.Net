using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    //[Owned]
    public class FullName
    {
        [MinLength(3, ErrorMessage = "Invalid"), MaxLength(25, ErrorMessage = "Invalid")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
