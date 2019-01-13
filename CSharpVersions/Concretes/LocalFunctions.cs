using CSharpVersions.Entities;
using static System.Console;

namespace CSharpVersions.Concretes
{
    internal class LocalFunctions
    {
        internal static void Execute()
        {
            //Local_Functions_Example_1();
            Local_Functions_Example_2();
        }

        /* Using nested functions inside a function is called local function. */
        internal static void Local_Functions_Example_1()
        {
            void Add(int x, int y)
            {
                WriteLine($"Sum of {x} and {y} is : {x + y}");
            }

            void Multiply(int x, int y)
            {
                WriteLine($"Product of {x} and {y} is : {x * y}");
                Add(30, 10);
            }

            Add(20, 50);
            Multiply(20, 50);
        }

        // Shows local function that returns a value.
        internal static void Local_Functions_Example_2()
        {
            Subject maths = new Subject
            {
                SubjectName = "Math",
                Marks = 96
            };

            Subject physics = new Subject
            {
                SubjectName = "Physics",
                Marks = 88
            };

            Subject chem = new Subject
            {
                SubjectName = "Chem",
                Marks = 91
            };

            PrintStudentMarks(101, maths, physics, chem);

        }

        public static void PrintStudentMarks(int studentId, params Subject[] subjects)
        {
            WriteLine($"Student Id {studentId} Total Marks: {CalculateTotalMarks()}");
            WriteLine($"Subject wise marks");

            // Params parameter becomes a temporary array.
            foreach (var subject in subjects)
            {
                WriteLine($"Subject Name: {subject.SubjectName} \t Marks: {subject.Marks}");
            }

            decimal CalculateTotalMarks()
            {
                decimal totalMarks = 0;
                foreach (var subject in subjects)
                {
                    totalMarks += subject.Marks;
                }
                return totalMarks;
            }
        }
    }
}
