using System;
using CreateAndUseTypes.Entities;
using System.Collections.Generic;

namespace CreateAndUseTypes.Demos
{
    /// <summary>
    /// Polymorphism, in C#, is the ability of objects of different types to 
    /// provide a unique interface for different implementations of methods. 
    /// It is usually used in the context of late binding, where the behavior 
    /// of an object to respond to a call to its method members is determined 
    /// based on object type at run time.
    /// </summary>
    class Polymorphism
    {
        internal static void Execute()
        {
            // Poly = Many
            // Morph = Changes with the situation

            AbilityToUseDerivedTypeAsIfIsABaseType_2();
        }

        // Common in Collections.
        private static void AbilityToUseDerivedTypeAsIfIsABaseType_1()
        {
            // Employee members.
            Employee employee = new Employee()
            {
                Name = "George",
                Age = 30,
                ID = "3574dfg5"
            };

            employee.IntroduceSelf();


            // This will only work with employees.
            List<Employee> emps = new List<Employee>() { };
            
            // Will only work with Students
            List<Student> stds = new List<Student>() { };

            List<Person1> people = new List<Person1>()
            {
                new Employee(),
                new Student()
            };

            // p cannot access Employee member unless we cass.
            Person1 p = new Employee();
            Employee e1 = p as Employee;

            if (e1 != null)
            {
                // Some logic... here.
            }
            
        }

        // Proper real world example of using polymorphism.
        private static void AbilityToUseDerivedTypeAsIfIsABaseType_2()
        {
            List<Person1> people = new List<Person1>();

            Student s = new Student()
            {
                Name = "George",
                Age = 30,
                GradeLevel = 8
            };

            Employee e = new Employee()
            {
                Name = "Bob",
                Age = 50,
                ID = "fjdkdj3539"
            };

            people.Add(s);
            people.Add(e);

            foreach (var p in people)
            {
                // p.ID or p.IntroduceSelf() or p.GradeLevel: - Will not be accessible

                if(p is Student)
                {
                    Student temp = p as Student;
                    Console.WriteLine($"{temp.GradeLevel}");
                }
                else if (p is Employee)
                {
                    Employee temp = p as Employee;
                    Console.WriteLine($"{temp.ID}");
                }

            }
        }
    }
}