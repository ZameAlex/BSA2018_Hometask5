using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using BSA2018_Hometask4.Shared.DTO;
using AutoMapper;

namespace BSA2018_Hometask4.BLL
{
    public class Mapping
    {
        public MapperConfiguration ConfigureMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Flight, FlightDto>();
                cfg.CreateMap<FlightDto, Flight>();

                cfg.CreateMap<Ticket, TicketDto>();
                cfg.CreateMap<TicketDto, Ticket>();

                cfg.CreateMap<Departure, DepartureDto>();
                cfg.CreateMap<DepartureDto, Departure>();

                cfg.CreateMap<Stewadress, StewadressDto>();
                cfg.CreateMap<StewadressDto, Stewadress>();

                cfg.CreateMap<Pilot, PilotDto>();
                cfg.CreateMap<PilotDto, Pilot>();

                cfg.CreateMap<Crew, CrewDto>();
                cfg.CreateMap<CrewDto, Crew>();

                cfg.CreateMap<Plane, PlaneDto>();
                cfg.CreateMap<PlaneDto, Plane>();

                cfg.CreateMap<PlaneType, TypeDto>();
                cfg.CreateMap<TypeDto, Plane>();
            }
            );
            return config;
        }
    }
}
