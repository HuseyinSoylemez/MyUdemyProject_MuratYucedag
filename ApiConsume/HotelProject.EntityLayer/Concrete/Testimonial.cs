﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Testimonial : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Cdate { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool? Durum { get; set; }
    }
}
