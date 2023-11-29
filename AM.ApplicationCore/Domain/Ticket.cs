using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public string classe { get; set; }
        public string destination { get; set; }
        public int id {  get; set; }
        public virtual IList<ReservationTicket> Reservations { get; set; }
    }
}
