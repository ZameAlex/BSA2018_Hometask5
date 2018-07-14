using AutoMapper;
using BSA2018_Hometask4.BLL.Interfaces;
using BSA2018_Hometask4.Shared.DTO;
using BSA2018_Hometask4.Shared.Exceptions;
using DAL.Models;
using DAL.Repository;
using DAL.UnitOfWork;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.BLL.Services
{
    public class FlightService : IFlightService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<FlightDto> validator;

        public FlightService(IUnitOfWork uow, IMapper map, AbstractValidator<FlightDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public void Create(FlightDto flight)
        {
            var validationResult = validator.Validate(flight);
            if (validationResult.IsValid)
                unit.Flights.Create(mapper.Map<FlightDto, Flight>(flight));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Delete(int id)
        {
            unit.Flights.Delete(id);
        }

        public void Delete(FlightDto flight)
        {
            unit.Flights.Delete(mapper.Map<FlightDto, Flight>(flight));
        }

        public FlightDto Get(int id)
        {
            return mapper.Map<Flight, FlightDto>(unit.Flights.Get(id));
        }

        public List<FlightDto> Get()
        {
            return mapper.Map<List<Flight>, List<FlightDto>>(unit.Flights.Get());
        }

        public void Update(FlightDto flight, int id)
        {
            var validationResult = validator.Validate(flight);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                unit.Flights.Update(mapper.Map<FlightDto, Flight>(flight), id);
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundException();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void Update(DateTime departureTime, DateTime destinationTime, int id)
        {
            var validationResult = validator.Validate(new FlightDto()
            {
                DepartureTime = departureTime,
                DestinationTime = destinationTime
            },
            "DepartureTime", "DestinationTime");

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                (unit.Flights as FlightRepository).Update(departureTime, destinationTime, id);
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundException();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
