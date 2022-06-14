using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using SqlSugar.Service;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GrpcService1.API
{
    public class StudentAPI : Students.StudentsBase
    {
        private readonly ILogger<StudentAPI> _logger;
        private readonly StudentService _studentService;
        public StudentAPI(ILogger<StudentAPI> logger, StudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }
        public override Task<StudentList> GetList(Empty empty, ServerCallContext context)
        {
            var list = _studentService.GetList();
            var result = new StudentList { };
            list.ForEach(item =>
            {
                var stu = new Student { Id = item.Id, StuId = item.Id, Name = item.Name, CourseId = (int)item.CourseId };
                result.List.Add(stu);
            });

            return Task.FromResult(result);
        }
    }
}
