﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCoSample.Domain.Entities.Base;

namespace UnluCoSample.Domain.Entities
{
    public class NumberPlate : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
