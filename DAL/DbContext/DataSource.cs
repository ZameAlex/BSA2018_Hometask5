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