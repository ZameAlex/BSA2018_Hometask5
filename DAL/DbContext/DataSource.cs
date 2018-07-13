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
        //Implement all sets
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