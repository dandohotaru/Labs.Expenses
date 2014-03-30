﻿using System;
using Labs.Expenses.Domain.Common;

namespace Labs.Expenses.Domain.Entities
{
    public class Tag : Entity
    {
        protected Tag()
        {
        }

        public Tag(Guid id, Guid tenantId) 
            : base(id, tenantId)
        {
        }

        public string Name { get; set; }
    }
}