﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class JobTitle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long userId { get; set; }
        public User user { get; set; }
    }
}
