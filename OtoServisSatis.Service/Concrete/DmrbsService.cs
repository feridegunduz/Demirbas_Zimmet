﻿using OtoServisSatis.Data;
using OtoServisSatis.Data.Abstract;
using OtoServisSatis.Data.Concrete;
using OtoServisSatis.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Service.Concrete
{
    public class DmrbsService : DmrbsRepository, IDmrbsService
    {
        public DmrbsService(DatabaseContext context) : base(context)
        {


        }
    }
}
