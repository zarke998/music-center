using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Domain.Entities
{  
    // Klasa ne nasledjuje Entity jer nije neophodno da sadrzi sve informacije koje Entity sadrzi, tj. nije neophodno obeleziti stavku u korpi kao obrisanu (soft delete), kao ni da se prati kad je dodata, itd...
    public class UserCartProduct
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
