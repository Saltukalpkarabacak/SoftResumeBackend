using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Constants
{
    /// <summary>
    /// Programlama Dili Mesajları
    /// </summary>
    public static class ProgrammingLanguageMessages
    {
        public const string ProgrammingLanguageDoesNotHaveAnyRecords = "Requested Programming Language does not have any records";
        public const string ProgrammingLanguageGreaterThanZero = "Programming Language Id must be greater than zero";
        public const string ProgrammingLanguageIdIsRequired = "Programming Language Id is required";
        public const string ProgrammingLanguageNameIsRequired = "Programming Language Name is required";
        public const string ProgrammingLanguageNameIsAlreadyExist = "Programming Language Name is already exist";
        public const string ProgrammingLanguageNotFound = "Programming Language not found";
    }
}
