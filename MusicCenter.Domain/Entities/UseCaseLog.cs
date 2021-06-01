using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Domain.Entities
{

    // Isti razlog za ne nasledjivanje Entity-a kao i u slucaju UserCartProduct
    public class UseCaseLog
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UseCaseId { get; set; }
        public string UseCaseName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
