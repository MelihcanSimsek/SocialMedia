﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Chat:IEntity
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
    }
}
