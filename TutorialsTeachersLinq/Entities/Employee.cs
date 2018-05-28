using System.Collections.Generic;

namespace TutorialsTeachersLinq.Entities
{
    public class Employee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Department> Departments { get; set; }
    }
}
