using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {

        //public int Id { get; set; }
        [Key,StringLength(7)]
        public string PassportNumber { get; set; }
        public FullName fullname { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime BirthDate { get; set; }
        //[DataType(DataType.PhoneNumber)]
        //[Phone]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public int? TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        public virtual IList<Flight> Flights { get; set; }
        public virtual IList<ReservationTicket> Reservations { get; set; }

        //public override string ToString()
        //{
        //    return "FirstName: " + FirstName + " LastName: " + LastName + " date of Birth: " + BirthDate;
        //}

        //poly par signature 
        public bool CheckProfile (string firstName , string lastName)
        {
            return fullname.FirstName==firstName && fullname.LastName==lastName;  

        }

        public bool CheckProfile(string firstName , string lastName,string email)
        {
            return fullname.FirstName == firstName && fullname.LastName == lastName && EmailAddress == email;    
        }

        public bool login(string firstName, string lastName, string email = null)
        {
           if(email != null)
            return fullname.FirstName == firstName && fullname.LastName == lastName && EmailAddress == email;
            return fullname.FirstName == firstName && fullname.LastName == lastName;
        }

        public bool login1(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return CheckProfile(firstName, lastName, email);
            return CheckProfile(firstName, lastName);
        }
        //return email != null ? checkprofile(nom,prenom,email):checkprofile(nom,prenom)

        //poly par héritage 
        public virtual void PassengerType()
        {

            Console.WriteLine("I'm Passenger");
        }

    }
}
