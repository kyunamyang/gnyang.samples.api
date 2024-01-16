﻿using gnyang.samples.domain.Common;
using gnyang.samples.domain.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gnyang.samples.domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        //public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        //public required Contact Creator { get; set; }
        //public List<Contact> Modifier { get; } = [];
    }
}
