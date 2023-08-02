using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CourseDTO
    {

        public int CourseId { get; set; }
        public required string CourseName { get; set; } //This property is required (not nullable)
        public int CourseDuration { get; set; }
        [JsonConverter(typeof (JsonStringEnumConverter))]
        public COURSE_TYPE CourseType { get; set; } //This is an enum. A list of options to choose from.

        public enum COURSE_TYPE
        {
            ENGINEERING,
            MEDICAL,
            MANAGEMENT
        }
    }
}
