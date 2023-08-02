using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataRepository.Models;

namespace DataRepository.Repositories
{
    public class InMemoryCmsRepository : ICmsRepository
    {
        List<Course> courses;
        public InMemoryCmsRepository()
        {
            courses = new List<Course>();
            courses.Add(
                new Course()
                {
                    CourseId = 1,
                    CourseName = "Computer Science",
                    CourseDuration = 60,
                    CourseType = Course.COURSE_TYPE.ENGINEERING
                }
            );
             courses.Add(
                new Course()
                {
                    CourseId = 2,
                    CourseName = "Programming Skills",
                    CourseDuration = 90,
                    CourseType = Course.COURSE_TYPE.ENGINEERING
                }
            );

        }

        public Course AddCourse(Course newCourse)
        {
            //Check max current ID to add 1.
            var maxCourseId = courses.Max(c => c.CourseId);
            newCourse.CourseId = maxCourseId + 1;
            courses.Add(newCourse);

            return newCourse;
        }

        public bool IsCourseExists(int courseId)
        {
            return courses.Any(c => c.CourseId == courseId);
        }

        public Course? GetCourse(int courseId) //The ? means it can return null if necessary
        {
            var result = courses.Where(c => c.CourseId == courseId)
                    .SingleOrDefault();
            return result;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await Task.Run(() => courses.ToList());
        }

        
    }
}