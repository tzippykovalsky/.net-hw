using Lesson5.Core.Entities;
using Lesson5.Data.Repositories;

namespace Lesson5.Service
{
    public class FlightService
    {
        private readonly FlightRepository _flightRepository;
        private readonly PilotRepository _pilotRepository;

        public FlightService(FlightRepository flightRepository, PilotRepository pilotRepository)
        {
            _flightRepository = flightRepository;
            _pilotRepository = pilotRepository;
        }

        public List<Flight> GetFlights()
        {
            return _flightRepository.GetFlights();
        }

        public Flight? GetFlightById(int id)
        {
            return _flightRepository.GetFlightById(id);
        }

        public void AddFlight(Flight flight)
        {
            // לוגיקה 1
            if (flight.Price <= 0)
                throw new ArgumentException("מחיר הטיסה חייב להיות מספר חיובי.");

            // לוגיקה 2
            if (string.IsNullOrWhiteSpace(flight.Destination))
                throw new ArgumentException("יש להזין יעד לטיסה.");

            // מספר שעות לא חוקי
            if (flight.NumHours <= 0 || flight.NumHours > 24)
                throw new ArgumentException("מספר שעות חייב להיות בין 1 ל-24.");

            // בדיקה שהטייס קיים
            var pilot = _pilotRepository.GetPilotById(int.Parse(flight.PilotId));
            if (pilot == null)
                throw new InvalidOperationException("טייס לא קיים במערכת.");

            // לוגיקה 5: לא לאפשר טיסה כפולה באותו שער, יעד וטייס
            var existingFlights = _flightRepository.GetFlights();
            bool conflict = existingFlights.Any(f =>
                f.Gate == flight.Gate &&
                f.Destination == flight.Destination &&
                f.PilotId == flight.PilotId);

            if (conflict)
                throw new InvalidOperationException("כבר קיימת טיסה דומה במערכת עם אותו טייס, יעד ושער.");

            _flightRepository.AddFlight(flight);
        }

        public void RemoveFlight(int id)
        {
            _flightRepository.RemoveFlight(id);
        }

        public void UpdateFlight(Flight flight)
        {
            // אפשר להוסיף לוגיקות גם כאן כמו בבדיקה של Add
            _flightRepository.UpdateFlight(flight);
        }
    }
}
