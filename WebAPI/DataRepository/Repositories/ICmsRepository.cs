using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataRepository.Models;

namespace DataRepository.Repositories
{
    public interface ICmsRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Course AddCourse(Course newCourse);

        bool IsCourseExists(int courseId);

        Course? GetCourse(int courseId);
    }
}