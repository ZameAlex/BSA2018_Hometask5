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
    public class PlaneService : IPlaneService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<PlaneDto> validator;

        public PlaneService(IUnitOfWork uow, IMapper map, AbstractValidator<PlaneDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public void Create(PlaneDto Plane)
        {
            var validationResult = validator.Validate(Plane);
            if (validationResult.IsValid)
                unit.Planes.Create(mapper.Map<PlaneDto, Plane>(Plane));
            else
                throw new ValidationException(validationResult.Errors);
            
        }

        public void Delete(int id)
        {
            unit.Planes.Delete(id);
        }

        public void Delete(PlaneDto Plane)
        {
            unit.Planes.Delete(mapper.Map<PlaneDto, Plane>(Plane));
        }

        public PlaneDto Get(int id)
        {
            return mapper.Map<Plane, PlaneDto>(unit.Planes.Get(id));
        }

        public List<PlaneDto> Get()
        {
            return mapper.Map<List<Plane>, List<PlaneDto>>(unit.Planes.Get());
        }

        public void Update(PlaneDto Plane, int id)
        {
            var validationResult = validator.Validate(Plane);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                unit.Planes.Update(mapper.Map<PlaneDto, Plane>(Plane), id);
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

        public void Update(TimeSpan expires, int id)
        {
            var validationResult = validator.Validate(new PlaneDto() { Expires = expires }, "Expires");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                (unit.Planes as PlaneRepository).Update(expires, id);
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
