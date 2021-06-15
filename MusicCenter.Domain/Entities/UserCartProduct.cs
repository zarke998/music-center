using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Domain.Entities
{  
    // Klasa ne nasledjuje Entity jer sam odlucio da nije od preterane vaznosti da cuvam kad je dodata stavka u korpu, da se obelezi kao soft delete stavka itd.
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
