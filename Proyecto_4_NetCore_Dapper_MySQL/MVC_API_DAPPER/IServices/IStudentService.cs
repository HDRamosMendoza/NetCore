using MVC_API_DAPPER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_API_DAPPER.IServices
{
    public interface IStudentService
    {
        Student Save(Student oStudent);
        List<Student> Gets();
        Student Get(int studentId);
        string Delete(int studentId);
    }

}
