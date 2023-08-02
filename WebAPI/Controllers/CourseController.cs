using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataRepository.Models;
using DataRepository.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("course")]
    public class CourseController : ControllerBase
    {
        private readonly ICmsRepository cmsRepository;

        public IMapper mapper { get; }

        public CourseController(ICmsRepository cmsRepository, IMapper mapper)
        {
            this.cmsRepository = cmsRepository;
            this.mapper = mapper;
        }

        // This method would give you the model info. It's not advisable.

        // [HttpGet]
        // public IEnumerable<Course> GetAll()
        // {
        //     return cmsRepository.GetAllCourses();
        // }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses()
        {
            try{
                IEnumerable<Course> courses = await cmsRepository.GetAllCourses();
                var result = MapCourseToCourseDto(courses);
                return result.ToList();
            }
            catch(System.Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<CourseDTO> AddCourse([FromBody]CourseDTO course)
        {
             try{
                var newCourse = mapper.Map<Course>(course);
                newCourse = cmsRepository.AddCourse(newCourse);

                return mapper.Map<CourseDTO>(newCourse);

            }
            catch(System.Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    
        [HttpGet("{courseId}")]
        public ActionResult<CourseDTO> GetCourse(int courseId)
        {
            try{
                if(!cmsRepository.IsCourseExists(courseId))
                    return NotFound();
                
                Course? course = cmsRepository.GetCourse(courseId);
                var result = mapper.Map<CourseDTO>(course);
                return result;
               

            }
            catch(System.Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    #region Manual Mapping
        private CourseDTO MapCourseToCourseDto(Course course) //Individual mapping
        {
            return new CourseDTO()
            {
                CourseId = course.CourseId,
                CourseDuration = course.CourseDuration,
                CourseName = course.CourseName,
                CourseType = (CourseDTO.COURSE_TYPE)course.CourseType
            };
        }

        private IEnumerable<CourseDTO> MapCourseToCourseDto(IEnumerable<Course> courses) //List mapping
        {
            IEnumerable<CourseDTO> result;

            result = courses.Select(c => new CourseDTO()
            {
                CourseId = c.CourseId + 1,
                CourseName = c.CourseName,
                CourseDuration = c.CourseDuration,
                CourseType = (CourseDTO.COURSE_TYPE)c.CourseType
            });

            return result;
        }
    #endregion
    }
}