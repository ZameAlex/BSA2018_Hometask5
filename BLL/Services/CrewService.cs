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
    public class CrewService : ICrewService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<CrewDto> validator;

        public CrewService(IUnitOfWork uow, IMapper map, AbstractValidator<CrewDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public void Create(CrewDto Crew)
        {
            var validationResult = validator.Validate(Crew);
            if (validationResult.IsValid)
                unit.Crew.Create(mapper.Map<CrewDto, Crew>(Crew));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Delete(int id)
        {
            unit.Crew.Delete(id);
        }

        public void Delete(CrewDto Crew)
        {
            unit.Crew.Delete(mapper.Map<CrewDto, Crew>(Crew));
        }

        public CrewDto Get(int id)
        {
            return mapper.Map<Crew, CrewDto>(unit.Crew.Get(id));
        }

        public List<CrewDto> Get()
        {
            return mapper.Map<List<Crew>, List<CrewDto>>(unit.Crew.Get());
        }

        public void Update(CrewDto Crew, int id)
        {
            var validationResult = validator.Validate(Crew);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                unit.Crew.Update(mapper.Map<CrewDto, Crew>(Crew), id);
            }
            catch(ArgumentNullException)
            {
                throw new NotFoundException();
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
