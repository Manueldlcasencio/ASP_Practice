using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public required string CourseName { get; set; } //This property is required (not nullable)
        public int CourseDuration { get; set; }
        public COURSE_TYPE CourseType { get; set; } //This is an enum. A list of options to choose from.

        public enum COURSE_TYPE
        {
                ENGINEERING,
                MEDICAL,
                MANAGEMENT
        }
    }
}