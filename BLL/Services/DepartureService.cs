using AutoMapper;
using BSA2018_Hometask4.BLL.Interfaces;
using BSA2018_Hometask4.Shared.DTO;
using DAL.Models;
using DAL.Repository;
using DAL.UnitOfWork;
using FluentValidation;
using System;
using System.Collections.Generic;
using BSA2018_Hometask4.Shared.Exceptions;
using System.Text;


namespace BSA2018_Hometask4.BLL.Services
{
    public class DepartureService : IDepartureService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<DepartureDto> validator;

        public DepartureService(IUnitOfWork uow, IMapper map, AbstractValidator<DepartureDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public void Create(DepartureDto departure)
        {
            var validationResult = validator.Validate(departure);
            if (validationResult.IsValid)
                unit.Departures.Create(mapper.Map<DepartureDto, Departure>(departure));
            else
                throw new ValidationException(validationResult.Errors);
            
        }

        public void Delete(int id)
        {
            unit.Departures.Delete(id);
        }

        public void Delete(DepartureDto departure)
        {
            unit.Departures.Delete(mapper.Map<DepartureDto, Departure>(departure));
        }

        public DepartureDto Get(int id)
        {
            return mapper.Map<Departure, DepartureDto>(unit.Departures.Get(id));
        }

        public List<DepartureDto> Get()
        {
            return mapper.Map<List<Departure>, List<DepartureDto>>(unit.Departures.Get());
        }

        public void Update(DepartureDto departure, int id)
        {
            var validationResult = validator.Validate(departure);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                unit.Departures.Update(mapper.Map<DepartureDto, Departure>(departure), id);
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

        public void Update(DateTime date, int id)
        {
            var validationResult = validator.Validate(new DepartureDto() { Date = date }, "Date");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                (unit.Departures as DepartureRepository).Update(date, id);
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
