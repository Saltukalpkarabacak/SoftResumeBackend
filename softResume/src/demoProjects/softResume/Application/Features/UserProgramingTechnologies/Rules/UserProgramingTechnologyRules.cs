using Application.Features.ProgrammingLanguageTechnologies.Constants;
using Application.Services;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProgramingTechnologies.Rules
{
    public class UserProgramingTechnologyRules
    {
        private readonly IUserProgramingTechnologyRepository _userProgramingTechnologyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

        public UserProgramingTechnologyRules(IUserProgramingTechnologyRepository userProgramingTechnologyRepository, IUserRepository userRepository, IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
        {
            _userProgramingTechnologyRepository = userProgramingTechnologyRepository;
            _userRepository = userRepository;
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
        }

        public async Task ProgrammingLanguageTechnologyMustExistAsync(int programmingLanguageTechnologyId)
        {
            var programmingLanguage = await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == programmingLanguageTechnologyId);
            if (programmingLanguage is null)
                throw new BusinessException(ProgrammingLanguageTechnologyMessages.ProgrammingLanguageNotFound);
        }

        
    }
}
