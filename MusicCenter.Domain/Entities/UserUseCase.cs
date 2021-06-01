using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Domain.Entities
{
    public class UserUseCase : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int UseCaseId { get; set; }
    }
}
