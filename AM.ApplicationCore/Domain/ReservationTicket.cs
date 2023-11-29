using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class ReservationTicket
    { 
        
        public DateTime DateReservation {  get; set; }
        public float prix {  get; set; }
        [ForeignKey("ticketFK")]
        public virtual Ticket ticket {  get; set; }
        [ForeignKey("passengerFK")]
        public virtual Passenger passenger { get; set; }

        public string passengerFK { get; set; }
        public int ticketFK { get; set; }

    }
}
