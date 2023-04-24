﻿using Core.DataAccess.EntityFramework;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete.EntityFramework
{
    public class EfStaffDal : EFRepositoryBase<Staff, Context>, IStaffDal
    {
    }
}
