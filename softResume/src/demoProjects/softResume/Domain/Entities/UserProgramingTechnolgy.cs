using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserProgramingTechnolgy : Entity
    {
        public int UserId { get; set; }
        public int ProgrammingLanguageTechnologyId { get; set; }

        public virtual User? User { get; }
        public virtual ProgrammingLanguageTechnology? ProgrammingLanguageTechnology { get; set; }

        public UserProgramingTechnolgy()
        {
        }

        public UserProgramingTechnolgy(int id,int userId, int technologyId)
        {
            Id = id;
            UserId = userId;
            ProgrammingLanguageTechnologyId = technologyId;
        }
    }
}
