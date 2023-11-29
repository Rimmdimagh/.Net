using AM.ApplicationCore.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight :IService<Flight>
    {
        List<DateTime> GetFlightDates(string destination);
        void GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
         int ProgrammedFlightNumber(DateTime startDate);
         double DurationAverage(string destination);
        IEnumerable<Flight> OrderedDurationFlights();
        IEnumerable<Passenger> SeniorTravellers(Flight flight);
         IEnumerable<IGrouping<string, Flight>>DestinationGroupedFlights();
        IEnumerable<Flight> volOrdoParDateDepNDer(int n);
        IList<Traveller> GetTravByPlaneAndDate(Plane pl, DateTime date);
        IList<Staff> GetStaffMembersByFlightId(int flightId);
        bool CanReserveSeats(Flight flight, int n);

    }
}
