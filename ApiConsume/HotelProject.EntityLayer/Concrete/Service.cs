using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Service : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Cdate { get; set; }
        public string ServiceIcon { get; set; }
       
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? Durum { get; set; }
    }
}
