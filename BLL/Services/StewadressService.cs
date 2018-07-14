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
    public class StewadressService : IStewadressService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<StewadressDto> validator;

        public StewadressService(IUnitOfWork uow, IMapper map, AbstractValidator<StewadressDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public void Create(StewadressDto Stewadress)
        {
            var validationResult = validator.Validate(Stewadress);
            if (validationResult.IsValid)
                unit.Stewadresses.Create(mapper.Map<StewadressDto, Stewadress>(Stewadress));
            else
                throw new ValidationException(validationResult.Errors);

        }

        public void Delete(int id)
        {
            unit.Stewadresses.Delete(id);
        }

        public void Delete(StewadressDto Stewadress)
        {
            unit.Stewadresses.Delete(mapper.Map<StewadressDto, Stewadress>(Stewadress));
        }

        public StewadressDto Get(int id)
        {
            return mapper.Map<Stewadress, StewadressDto>(unit.Stewadresses.Get(id));
        }

        public List<StewadressDto> Get()
        {
            return mapper.Map<List<Stewadress>, List<StewadressDto>>(unit.Stewadresses.Get());
        }

        public void Update(StewadressDto Stewadress, int id)
        {
            var validationResult = validator.Validate(Stewadress);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                unit.Stewadresses.Update(mapper.Map<StewadressDto, Stewadress>(Stewadress), id);
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
