﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncAwait.Models
{
    public class StudentVisit
    {
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
        public byte Mark { get; set; }        
    }
}
