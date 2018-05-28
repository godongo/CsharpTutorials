using System.Collections.Generic;
using TutorialsTeachersLinq.Entities;

namespace TutorialsTeachersLinq.Repository
{
    class DataRepository
    {
        internal static Student[] GetStudents()
        {
            return new Student[]
                {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 },
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 },
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 },
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 },
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 },
                    new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 },
                    new Student() { StudentID = 7, StudentName = "Rob",Age = 19  },
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 18 }
                };
        }

        internal static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee
            {
                ID = 1,
                Name = "Kapil",
                Departments = new List<Department>()
                {
                    new Department { Name = "Marketing" },
                    new Department { Name = "Sales"}
                }
            });
            employees.Add(new Employee
            {
                ID = 2,
                Name = "Raj",
                Departments = new List<Department>()
                {
                    new Department { Name = "Advertisement" },
                    new Department { Name = "Production"}
                }
            });
            employees.Add(new Employee
            {
                ID = 3,
                Name = "Ramesh",
                Departments = new List<Department>()
                {
                    new Department { Name = "Production" },
                    new Department { Name = "Sales"}
                }
            });

            return employees;
        }
    }
}
