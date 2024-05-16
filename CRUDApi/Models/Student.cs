using System;
using System.Collections.Generic;

namespace CRUDApi.Models
{
    public partial class Student
    {
        public int RollNo { get; set; }
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public string? Standard { get; set; }
    }
}
