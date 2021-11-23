﻿using FrameworkLectionsCourse.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrameworkLectionsCourse.Models
{
    public class Good
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public int? MinCount { get; set; }
    }
}