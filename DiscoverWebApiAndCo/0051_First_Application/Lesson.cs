using System;
using System.Collections.Generic;

namespace _0041_First_Application
{
    public partial class Lesson
    {
        public decimal Id { get; set; }
        public decimal PadawannId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LessonDate { get; set; }
        public decimal Value { get; set; }
        public string LessonLabel { get; set; }

        public virtual Padawann Padawann { get; set; }
    }
}
