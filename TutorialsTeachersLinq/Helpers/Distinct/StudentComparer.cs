using System.Collections.Generic;
using TutorialsTeachersLinq.Entities;

namespace TutorialsTeachersLinq.Helpers.Distinct
{
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID
                    && x.StudentName.ToLower() == y.StudentName.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(Student obj)
        {
            // Hashing the studentId
            return obj.StudentID.GetHashCode();
        }
    }
}
