using DAL.Models;
using System;
using System.Collections.Generic;


public class DataSource
{
    public List<Flight> Flights { get; set; }
    public List<Ticket> Tickets { get; set; }
    public List<Crew> Crew { get; set; }
    public List<Departure> Depatures { get; set; }
    public List<Pilot> Pilots { get; set; }
    public List<Stewadress> Stewadresses { get; set; }
    public List<Plane> Planes { get; set; }
    public List<PlaneType> Types { get; set; }        

    public DataSource ()
    {
        Flights = new List<Flight>();
        Tickets = new List<Ticket>();
        Crew = new List<Crew>();
        Depatures = new List<Departure>();
        Pilots = new List<Pilot>();
        Stewadresses = new List<Stewadress>();
        Planes = new List<Plane>();
        Types = new List<PlaneType>();

        #region Pilots initializing
        Pilots.Add(
            new Pilot
            {
                Id = 1,
                Name = "Alex",
                LastName = "Zamekula",
                Birthday = new DateTime(1994, 8, 5),
                Experience = 3
            }
            );
        Pilots.Add(
            new Pilot
            {
                Id = 2,
                Name = "Ksu",
                LastName = "White",
                Birthday = new DateTime(1992, 5, 31),
                Experience = 4
            }
            );
        Pilots.Add(
            new Pilot
            {
                Id = 3,
                Name = "Yuri",
                LastName = "Chuklib",
                Birthday = new DateTime(1993, 9, 6),
                Experience = 2
            }
            );
        Pilots.Add(
            new Pilot
            {
                Id = 1,
                Name = "Dima",
                LastName = "Polik",
                Birthday = new DateTime(1990, 11, 15),
                Experience = 8
            }
            );
        #endregion

        #region Stewardess initilizing
        Stewadresses.Add(
            new Stewadress
            {
                Id = 1,
                Name = "Tanya",
                LastName = "Sinchuk",
                Birthday = new DateTime(1996, 8, 27)
            }
            );
        Stewadresses.Add(
            new Stewadress
            {
                Id = 2,
                Name = "Viktorua",
                LastName = "Dachuk",
                Birthday = new DateTime(1995, 3, 18)
            }
            );
        Stewadresses.Add(
           new Stewadress
           {
               Id = 3,
               Name = "Kate",
               LastName = "Kostash",
               Birthday = new DateTime(1996, 12, 5)
           }
           );
        Stewadresses.Add(
           new Stewadress
           {
               Id = 4,
               Name = "Svetlana",
               LastName = "Polyshuk",
               Birthday = new DateTime(1998, 2, 23)
           }
           );
        Stewadresses.Add(
           new Stewadress
           {
               Id = 5,
               Name = "Natalia",
               LastName = "Dorohova",
               Birthday = new DateTime(1996, 6, 21)
           }
           );
        Stewadresses.Add(
           new Stewadress
           {
               Id = 6,
               Name = "Maryna",
               LastName = "Medvin",
               Birthday = new DateTime(1996, 1, 24)
           }
           );
        #endregion

        #region Crews initializing
        Crew.Add(new DAL.Models.Crew
        {
            Id=1,
            Pilot = Pilots[0],
            Stewadresses = new List<Stewadress>()
            {
                Stewadresses[0],
                Stewadresses[1],
                Stewadresses[5]
            }
        }
        );
        Crew.Add(new DAL.Models.Crew
        {
            Id = 2,
            Pilot = Pilots[1],
            Stewadresses = new List<Stewadress>()
            {
                Stewadresses[2],
                Stewadresses[3],
                Stewadresses[4]
            }
        }
        );
        Crew.Add(new DAL.Models.Crew
        {
            Id = 3,
            Pilot = Pilots[2],
            Stewadresses = new List<Stewadress>()
            {
                Stewadresses[0],
                Stewadresses[2],
                Stewadresses[4]
            }
        }
        );
        #endregion

        #region Ticket initializing
        Tickets.Add(
            new Ticket
            {
                Id=1,
                Price=200m
            }
            );
        Tickets.Add(
           new Ticket
           {
               Id = 2,
               Price = 200m
           }
           );
        Tickets.Add(
           new Ticket
           {
               Id = 3,
               Price = 100m
           }
           );
        Tickets.Add(
           new Ticket
           {
               Id = 4,
               Price = 300m
           }
           );
        Tickets.Add(
           new Ticket
           {
               Id = 5,
               Price = 300m
           }
           );
        Tickets.Add(
           new Ticket
           {
               Id = 6,
               Price = 400m
           }
           );
        #endregion

        #region Flights Initializing
        Flights.Add(new Flight
        {
            Id = 1,
            DeparturePoint = "Kyiv",
            DepartureTime = new DateTime(2018, 1, 1, 12, 0, 0),
            DestinationPoint = "Lviv",
            DestinationTime = new DateTime(2018, 1, 1, 14, 0, 0),
            Number = new Guid(),
            Tickets = new List<Ticket>()
        }
        );

        Flights.Add(new Flight
        {
            Id = 1,
            DeparturePoint = "Kyiv",
            DepartureTime = new DateTime(2018, 1, 1, 14, 0, 0),
            DestinationPoint = "Berlin",
            DestinationTime = new DateTime(2018, 1, 1, 17, 0, 0),
            Number = new Guid(),
            Tickets = new List<Ticket>()
        }
        );
        Flights.Add(new Flight
        {
            Id = 1,
            DeparturePoint = "Lviv",
            DepartureTime = new DateTime(2018, 1, 1, 21, 0, 0),
            DestinationPoint = "London",
            DestinationTime = new DateTime(2018, 1, 2, 0, 0, 0),
            Number = new Guid(),
            Tickets = new List<Ticket>()
        }
        );
        #endregion

        #region Linking tickets and flights
        Tickets[0].Flight = Flights[0];
        Tickets[1].Flight = Flights[0];
        Tickets[2].Flight = Flights[0];
        Tickets[3].Flight = Flights[1];
        Tickets[4].Flight = Flights[1];
        Tickets[5].Flight = Flights[2];

        Flights.ForEach(f => f.Tickets = Tickets.FindAll(t => t.Flight.Id == f.Id));
        #endregion

        #region Types initializing
        Types.Add(
            new PlaneType
            {
                Id=1,
                Model="Model1",
                FleightLength=9000,
                MaxHeight=11000,
                MaxMass=900,
                Places=150,
                Speed=900
            }
            );

        Types.Add(
            new PlaneType
            {
                Id = 2,
                Model = "Model2",
                FleightLength = 7500,
                MaxHeight = 9000,
                MaxMass = 1100,
                Places = 218,
                Speed = 800
            }
            );
        Types.Add(
            new PlaneType
            {
                Id = 1,
                Model = "Model3",
                FleightLength = 10000,
                MaxHeight = 8000,
                MaxMass = 80000,
                Places = 90,
                Speed = 900
            }
            );
        #endregion

        #region Plane initializing
        Planes.Add(
            new Plane
            {
                Id = 1,
                Name = "Bobo",
                Created = new DateTime(2015, 2, 1),
                Type = Types[0],
                Expired = new TimeSpan(750, 0, 0, 0)
            }
            );
        Planes.Add(
            new Plane
            {
                Id = 2,
                Name = "Gutu",
                Created = new DateTime(2014, 2, 1),
                Type = Types[0],
                Expired = new TimeSpan(360, 0, 0, 0)
            }
            );
        Planes.Add(
            new Plane
            {
                Id = 3,
                Name = "Ulu",
                Created = new DateTime(2012, 6, 23),
                Type = Types[0],
                Expired = new TimeSpan(40, 0, 0, 0)
            }
            );
        Planes.Add(
            new Plane
            {
                Id = 4,
                Name = "Ukoz",
                Created = new DateTime(2017, 11, 14),
                Type = Types[0],
                Expired = new TimeSpan(1355, 0, 0, 0)
            }
            );
        #endregion

        #region Departure initializing
        Depatures.Add(
            new Departure
            {
                Id = 1,
                Flight = Flights[0],
                Date = new DateTime(2018, 11, 14),
                Plane = Planes[0],
                Crew = Crew[0]
            }
            );
        Depatures.Add(
            new Departure
            {
                Id = 2,
                Flight = Flights[0],
                Date = new DateTime(2018, 10, 14),
                Plane = Planes[1],
                Crew = Crew[2]
            }
            );
        Depatures.Add(
            new Departure
            {
                Id = 3,
                Flight = Flights[1],
                Date = new DateTime(2018, 8, 10),
                Plane = Planes[2],
                Crew = Crew[1]
            }
            );
        Depatures.Add(
            new Departure
            {
                Id = 4,
                Flight = Flights[2],
                Date = new DateTime(2018, 8, 15),
                Plane = Planes[3],
                Crew = Crew[0]
            }
            );
        #endregion
    }

    public List<TEntity> SetOf<TEntity>() where TEntity: Entity
    {
        if (Flights is List<TEntity>)
            return Flights as List<TEntity>;
        else if (Depatures is IEnumerable<TEntity>)
            return Depatures as List<TEntity>;
        else if (Crew is IEnumerable<TEntity>)
            return Crew as List<TEntity>;
        else if (Stewadresses is IEnumerable<TEntity>)
            return Stewadresses as List<TEntity>;
        else if (Pilots is IEnumerable<TEntity>)
            return Pilots as List<TEntity>;
        else if (Planes is IEnumerable<TEntity>)
            return Planes as List<TEntity>;
        else if (Types is IEnumerable<TEntity>)
            return Types as List<TEntity>;
        else return Tickets as List<TEntity>;
    }
}