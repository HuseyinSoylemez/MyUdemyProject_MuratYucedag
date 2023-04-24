using Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public DateTime? Cdate { get; set; }

        public string Image { get; set; }
        public string Name { get; set; }
        public string KurumKodu { get; set; }
        public string Gorev { get; set; }
        public string Tcno { get; set; }
        public string Adres { get; set; }

        public string Cep { get; set; }

        public string Aciklama { get; set; }
        public bool? Durum { get; set; }
    }
}
