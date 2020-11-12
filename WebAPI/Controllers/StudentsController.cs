﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student(){Id = 1,Name="Tom"},
            new Student(){Id = 2,Name="Sam"},
            new Student(){Id = 3,Name="John"}
        };

        [Route("~/api/teachers")] //override route prefix
        public IEnumerable<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher(){Id = 1,Name="Rob"},
                new Teacher(){Id = 2,Name="Mike"},
                new Teacher(){Id = 3,Name="Mary"}
            };
            return teachers;
        }


        //[Route("api/students")]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        //[Route("api/students/{id}")]
        [Route("{id}")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        // [Route("api/students/{id}/courses")]
        [Route("{id}/courses")]
        public IEnumerable<string> GetStudentCourses(int id)
        {
            if (id == 1)
                return new List<string>() { "C#", "ASP.NET", "SQL SERVER" };
            else if (id == 2)
                return new List<string>() { "ASP.NET Web API", "C#", "SQL Server" };
            else
                return new List<string>() { "Bootstrap", "Jquery", "AngularJs" };
        }
    }
}