using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using ClearArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArch.Infra.Data.Repository
{
    public class CourseRepository :ICourseRepository
    {
        private UniversityDBContext _ctx;

        public CourseRepository(UniversityDBContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Course course)
        {
            _ctx.Courses.Add(course);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _ctx.Courses;
        }
    }
}
