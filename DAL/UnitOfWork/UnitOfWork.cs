using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repository;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CrewRepository crewRepository;
        private FlightRepository flightRepository;
        private DepartureRepository departureRepository;
        private PilotRepository pilotRepository;
        private PlaneRepository planeRepository;
        private StewadressRepository stewadressRepository;
        private PlaneTypeRepository typeRepository;
        private TicketRepository ticketRepository;

        public IRepository<Flight> Flights
        {
            get
            {
                if (flightRepository == null)
                    flightRepository = new FlightRepository();
                return flightRepository;
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository();
                return ticketRepository;
            }
        }

        public IRepository<Departure> Departures
        {
            get
            {
                if (departureRepository == null)
                    departureRepository = new DepartureRepository();
                return departureRepository;
            }
        }
        public IRepository<Stewadress> Stewadresses
        {
            get
            {
                if (stewadressRepository == null)
                    stewadressRepository = new StewadressRepository();
                return stewadressRepository;
            }
        }
        public IRepository<Pilot> Pilots
        {
            get
            {
                if (pilotRepository == null)
                    pilotRepository = new PilotRepository();
                return pilotRepository;
            }
        }
        public IRepository<Crew> Crew
        {
            get
            {
                if (crewRepository == null)
                    crewRepository = new CrewRepository();
                return crewRepository;
            }
        }
        public IRepository<Plane> Planes
        {
            get
            {
                if (planeRepository == null)
                    planeRepository = new PlaneRepository();
                return planeRepository;
            }
        }
        public IRepository<PlaneType> Types
        {
            get
            {
                if (typeRepository == null)
                    typeRepository = new PlaneTypeRepository();
                return typeRepository;
            }
        }

        public void Dispose()
        {
            
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
