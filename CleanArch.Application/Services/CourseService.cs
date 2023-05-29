using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepository;
        private IMediatorHandler _mediatorHandler;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler mediatorHandler)
        {
            _courseRepository = courseRepository;
            _mediatorHandler = mediatorHandler;
        }

        public void Create(CourseViewModel course)
        {
            var createCourseCommand = new CreateCourseCommand(
                   course.Name,
                   course.Description,
                   course.ImageUrl
                 );

            _mediatorHandler.SendCommand(createCourseCommand);
        }

        public CourseViewModel GetCourses()
        {
            return new CourseViewModel()
            {
                Courses = _courseRepository.GetCourses()
            };
        }
    }
}
