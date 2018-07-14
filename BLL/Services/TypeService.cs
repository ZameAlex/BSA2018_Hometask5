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
    public class TypeService : ITypeService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<TypeDto> validator;

        public TypeService(IUnitOfWork uow, IMapper map, AbstractValidator<TypeDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public void Create(TypeDto Type)
        {
            var validationResult = validator.Validate(Type);
            if (validationResult.IsValid)
                unit.Types.Create(mapper.Map<TypeDto, PlaneType>(Type));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Delete(int id)
        {
            unit.Types.Delete(id);
        }

        public void Delete(TypeDto Type)
        {
            unit.Types.Delete(mapper.Map<TypeDto, PlaneType>(Type));
        }

        public TypeDto Get(int id)
        {
            return mapper.Map<PlaneType, TypeDto>(unit.Types.Get(id));
        }

        public List<TypeDto> Get()
        {
            return mapper.Map<List<PlaneType>, List<TypeDto>>(unit.Types.Get());
        }

        public void Update(TypeDto Type, int id)
        {
            var validationResult = validator.Validate(Type);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                unit.Types.Update(mapper.Map<TypeDto, PlaneType>(Type), id);
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
