using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TutorialsTeachersLinq.Entities;
using TutorialsTeachersLinq.Helpers.Contains;
using TutorialsTeachersLinq.Repository;

namespace TutorialsTeachersLinq.Demos
{
    /*
     * 
     *  QUERY SYNTAX:
     *  1. from <range variable> in <IEnumerable<T> or IQueryable<T> Collection>
     *  2. <Standard Query Operators> <lambda expression>
     *  3. <select or groupBy operator> <result formation>
     */

    class LinqOperators
    {
        #region 1. Delegates
        // Remember a Delegate is a TYPE that references a method.
        // Allows to pass method around as data.
        // Remember Lambdas are expression syntax for anonymous methods.
        internal static void Lambda_Action_Delegate()
        {
            // Declare and implement method
            // Anything after => is the body of the method
            Action<string, string> method = (string firstname, string lastname) =>
                                                {
                                                    var description = "My full name is";
                                                    Console.WriteLine($"{description} {firstname} {lastname}");
                                                };

            // Invoke method with defined parameter
            method("George", "Odongo");
        }

        // Remember the last parameter type in a Func<> is the return type and rest are input parameters.
        internal static void Lambda_Func_Delegate()
        {
            Func<Student, bool> isStudentTeenAger = s => s.Age > 12 && s.Age < 20;

            Student std = new Student() { Age = 21 };

            // Invoke method to get returned value.
            bool isTeen = isStudentTeenAger(std);// returns false

            Console.WriteLine($"isTeen is {isTeen}");
        }
        #endregion

        #region 2. Filter Operators
        internal static void Where_1()
        {
            // Good practice for code readability.
            Student[] students = DataRepository.GetStudents();

            var teenagers = students.Where(s => s.Age > 12 && s.Age < 20).ToList<Student>();

            // Where second overload
            //var teenagers = students.Where((s,i) => s.Age > 12 && s.Age < 20 && i == 6).ToList<Student>();

            foreach (var student in teenagers)
            {
                Console.WriteLine($"{student.StudentName}");
            }
        }

        internal static void Where_2()
        {
            // Good practice for code readability.
            Student[] students = DataRepository.GetStudents();

            var result = students.Where(s => s.StudentName.StartsWith("R")).OrderByDescending(n => n.StudentName);

            foreach (var s in result)
            {
                Console.WriteLine($"Name {s.StudentName}");
            }
        }

        internal static void Where_3()
        {
            Student[] students = DataRepository.GetStudents();

            var filteredStudents = students.Where((s, i) =>
                                                            {
                                                                if (i % 2 == 0)
                                                                    return true;

                                                                return false;
                                                            });

            // Remember that collections are indexed from zero(0)
            PrintCollection(filteredStudents);
        }

        /*
         * The OfType operator filters the collection based on the ability to cast an 
         * element in a collection to a specified type.
         */
        internal static void OfType()
        {
            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill", Age = 25 });

            var stingResult = from s in mixedList.OfType<string>()
                              select s;

            var studentResult = from s in mixedList.OfType<Student>()
                                select s;

            // Method syntax.
            var stdResult = mixedList.OfType<Student>();
            PrintCollection(stdResult);
        }
        #endregion

        #region 3. Sorting Operators
        // Sorts the collection in ASCENDING by default.
        internal static void OrderBy_Ascending_And_Descending()
        {
            Student[] students = DataRepository.GetStudents();

            var orderByResult1 = from s in students
                                 orderby s.StudentName
                                 select s;

            var orderByDescendingResult = from s in students
                                          orderby s.StudentName descending
                                          select s;

            var orderByResult2 = students.OrderBy(s => s.StudentName);
            //var orderByResult2 = students.Where(s => s.Age < 15).OrderBy(s => s.StudentName);

            // OrderByDescending: This is only available in method syntax.
            var studentsInDescOrder = students.OrderByDescending(s => s.StudentName);

            PrintCollection(studentsInDescOrder);
        }

        private static void PrintCollection(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($" {student.StudentName} {student.Age}");
            }
        }

        /*
         * Method Syntax: Use ThenBy or ThenByDecending extension methods for secondary sorting.
         */
        internal static void OrderBy_With_Multiple_Sorting()
        {
            Student[] students = DataRepository.GetStudents();

            var orderByResult = from s in students
                                orderby s.StudentName, s.Age
                                select new { s.StudentName, s.Age };

            foreach (var student in orderByResult)
            {
                Console.WriteLine($" {student.StudentName} {student.Age}");
            }

        }

        internal static void OrderBy_ThenBy_And_ThenByDescending()
        {
            Student[] students = DataRepository.GetStudents();

            var thenByResult = students.OrderBy(s => s.StudentName).ThenBy(s => s.Age);

            var thenByDescResult = students.OrderBy(s => s.StudentName).ThenByDescending(s => s.Age);
        }
        #endregion

        #region 4. Grouping Operators
        // GroupBy: Deffered execution.
        // ToLookup: Immediate execution. 
        // They both work the same, the difference in exec
        internal static void GroupBy_And_ToLook()
        {
            // GeeNote: IT'S EASIER TO SEE DATA AND RESULTS IN HERE....!!... Later move to Repository 

            IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Abram" , Age = 21 }
            };

            // This is deferred.
            var groupedResult = from s in studentList
                                    // xxxxxxxx // Remember standard operators here...
                                group s by s.Age; // Remember Syntax here....select or group by

            //var groupedResult = studentList.GroupBy(s => s.Age);

            // This will execute immediately.
            //var lookupResult = studentList.ToLookup(s => s.age);

            foreach (var agedGroup in groupedResult)
            {
                Console.WriteLine($"Age Group: {agedGroup.Key}");

                foreach (var s in agedGroup)
                {
                    Console.WriteLine($"Student Name: {s.StudentName}");
                }
            }
        }
        #endregion

        #region 5. Join Operators
        /*
         * The Join operator joins two sequences (collections) based on a key and 
         * returns a resulted sequence.
         */
        internal static void Join_1()
        {
            /*
             * Joins two string collection and return new collection that INCLUDES 
             * MATCHING STRINGS IN BOTH THE COLLECTION.
             */
            IList<string> strList1 = new List<string>()
            {
                "One",
                "Two",
                "Three",
                "Four"
            };

            IList<string> strList2 = new List<string>() {
                "One",
                "Two",
                "Five",
                "Six"
            };

            var innerJoinResult = strList1.Join(strList2,
                str1 => str1,
                str2 => str2,
                (str1, str2) => str1
                );

            foreach (var item in innerJoinResult)
            {
                Console.WriteLine($"{item}");
            }
        }

        internal static void Join_2()
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
                new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
                new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
                new Student() { StudentID = 4, StudentName = "Ram" , StandardID =2 },
                new Student() { StudentID = 5, StudentName = "Ron"  }
            };

            IList<Standard> standardList = new List<Standard>()
            {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            var innerJoinResult = studentList.Join(// outer sequence 
                      standardList,  // inner sequence 
                      student => student.StandardID,    // outerKeySelector
                      standard => standard.StandardID,  // innerKeySelector
                      (student, standard) => new  // result selector
                      {
                          StudentNameL = student.StudentName,
                          StandardNameL = standard.StandardName
                      });

            foreach (var std in innerJoinResult)
            {
                Console.WriteLine($"{std.StudentNameL} {std.StandardNameL}");
            }
        }

        /*
         * SYNTAX
         *  1. from ... in outerSequence
         *  2. join ... in innerSequence  
         *  3. on outerKey equals innerKey
         *  4. select ...
         */
        internal static void Join_3_Query_Syntax()
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

            IList<Standard> standardList = new List<Standard>()
            {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            var innerJoin = from s in studentList
                            join st in standardList
                            on s.StandardID equals st.StandardID
                            select new
                            {
                                StudentNameL = s.StudentName,
                                StandardNameL = st.StandardName
                            };

            foreach (var std in innerJoin)
            {
                Console.WriteLine($"{std.StudentNameL} {std.StandardNameL}");
            }
        }

        /*
         * The GroupJoin operator performs the same task as Join operator except that GroupJoin 
         * returns a result in group based on specified group key. The GroupJoin operator joins 
         * two sequences based on key and groups the result by matching key and then returns the 
         * collection of grouped result and key.
         */
        internal static void Join_3_GroupJoin()
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
                new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
                new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
                new Student() { StudentID = 4, StudentName = "Ram",  StandardID =2 },
                new Student() { StudentID = 5, StudentName = "Ron" }
            };

            IList<Standard> standardList = new List<Standard>()
            {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            // standardList is the outer seqeuence.
            var groupJoin = standardList.GroupJoin(studentList,
                                                std => std.StandardID,
                                                s => s.StandardID,
                                                (std, studentsGroup) => new
                                                {
                                                    StandarFulldName = std.StandardName,
                                                    Students = studentsGroup,
                                                });

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.StandarFulldName);

                foreach (var stud in item.Students)
                    Console.WriteLine(stud.StudentName);
            }
        }

        /*
       * SYNTAX
       *  1. from ... in outerSequence
       *  2. join ... in innerSequence  
       *  3. on outerKey equals innerKey
       *  4.          into groupedCollection   
       *  5. select ...
       */
        internal static void Join_3_GroupJoin_Query_Syntax()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13, StandardID =1 },
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21, StandardID =1 },
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID =2 },
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID =2 },
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            var groupJoin = from std in standardList
                            join s in studentList
                            on std.StandardID equals s.StandardID  // Remember == is not allowed. 
                                into studentGroup
                            select new
                            {
                                StandarFulldName = std.StandardName,
                                Students = studentGroup

                            };

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.StandarFulldName);

                foreach (var stud in item.Students)
                    Console.WriteLine(stud.StudentName);
            }
        }
        #endregion

        #region 6. Projection Operators
        /* The Select operator always returns an IEnumerable collection which contains 
         * elements based on a transformation function. */
        internal static void Select()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            var selectResult1 = from s in studentList
                                select s.StudentName;

            // Returns collection of anonymous objects with Name and Age property.
            var selectResult2 = from s in studentList
                                select new {
                                    Name = "Mr. " + s.StudentName,
                                    // Age = s.Age
                                    s.Age
                                };

            // Method syntax.
            var selectResult3 = studentList.Select(s => new
            {
                Name = "Mr. " + s.StudentName,
                // Age = s.Age
                s.Age
            });

            foreach (var std in selectResult3)
            {
                Console.WriteLine($"Student Name: {std.Name}, Age: {std.Age}");
            }
        }

        /*
         * SelectMany operator is used when we have a sequence of objects which has a 
         * collection property and we need to enumerate each item of child collection one by one.
         */
        internal static void SelectMany()
        {
            List<Employee> employees = DataRepository.GetEmployees();

            var selectManyResult = employees.SelectMany(e => e.Departments);

            foreach (var dept in selectManyResult)
            {
                Console.WriteLine($"Department Name: {dept.Name}");
            }
        }
        #endregion

        #region 7. Quantifier Operators
        /* The quantifier operators evaluate elements of the sequence on some condition and return 
         * a boolean value to indicate that some or all elements satisfy the condition.*/

        /* Checks if all the elements in a sequence satisfies the specified condition */
        // QUANTIFIER OPERATORS ARE NOT SUPPORTED WITH C# QUERY SYNTAX.
        internal static void All_And_Any()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            bool areAllStudentsTeenager = studentList.All(s => s.Age > 12 && s.Age < 20);// Returns false.


            bool isAnyStudentTeenAger = studentList.Any(s => s.Age > 12 && s.Age < 20); // Returns true

            Console.WriteLine($"True if ALL students are teenagers otherwise false: {areAllStudentsTeenager}");
            Console.WriteLine($"True if ANY students are teenagers otherwise false: {isAnyStudentTeenAger}");
        }

        /* The Contains operator checks whether a specified element exists in the collection or not and 
         * returns a boolean. */
        // REMEMBER CONTAINS WILL NOT WORK WITH CUSTOM TYPES, YOU NEED TO CREATE A COMPARER FIRST 
        internal static void Contains()
        {
            IList<int> intList = new List<int>() { 1, 2, 3, 4, 5 };

            bool result = intList.Contains(10);  // returns false

            Console.WriteLine($"Returns true if element found otherwise false: {result}");
        }

        // WORKING WITH CUSTOM TYPES
        internal static void Contains_Using_CustomComparer()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            Student std = new Student() { StudentID = 3, StudentName = "Bill" };

            // WITH A COMPARER CONTAINS WILL NOT WORK FOR CUSTOM TYPES.
            bool result = studentList.Contains(std, new StudentComparer()); //returns true

            Console.WriteLine($"Returns true if element found otherwise false: {result}");
        }
        #endregion

        #region 8. Aggregation Operators : Needs more understanding!!!
        /*
         * The aggregation operators perform mathematical operations like Average, Aggregate, Count, Max, Min 
         * and Sum, ON THE NUMERIC PROPERTY OF THE ELEMENTS IN THE COLLECTION.
         */

        /* The Aggregate method performs an accumulate operation. */
        internal static void Aggregate()
        {
            IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };

            // Aggregates from a list to commma sperated string.
            var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + ", " + s2);

            Console.WriteLine(commaSeperatedString);
        }

        internal static void Aggregate_With_Seed_Value()
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 },
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 },
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 },
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
            };

            string commaSeparatedStudentNames = studentList.Aggregate<Student, string>(
                                                       "Student Names: ",
                                                        (str, s) => str += s.StudentName + ",");

            Console.WriteLine(commaSeparatedStudentNames);
        }

        internal static void Aggregate_With_Result_Selector()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 },
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 },
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 },
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
             };

            string commaSeparatedStudentNames = studentList.Aggregate<Student, string, string>(
                                            String.Empty, // seed value
                                            (str, s) => str += s.StudentName + ",", // returns result using seed value, String.Empty goes to lambda expression as str
                                            str => str.Substring(0, str.Length - 1)); // result selector that removes last comma

            Console.WriteLine(commaSeparatedStudentNames);
        }

        // Aerage method that returns average value of all the integers in the collection.
        // Average method returns nullable or non-nullable decimal, double or float value.
        internal static void Average()
        {
            IList<int> intList = new List<int> { 10, 20, 30 };

            var avg = intList.Average();

            Console.WriteLine($"Average: {avg}");
        }

        internal static void Average_With_Complex_Type()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
             };

            var avgAge = studentList.Average(s => s.Age);

            Console.WriteLine($"Average Age of Student: {avgAge}");

        }

        /* The Count operator returns the number of elements in the collection or number of elements 
         * that have satisfied the given condition. */
        internal static void Count()
        {
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50 };

            // First overload.
            var totalElements = intList.Count();

            Console.WriteLine($"Total Elements: {totalElements}");

            // Second overload
            var evenElements = intList.Count(i => i % 2 == 0);

            Console.WriteLine($"Even Elements: {evenElements}");
        }

        // Also show example in query syntax.
        internal static void Count_With_Complex_Type()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Mathew", Age = 15 }
             };

            var totalStudents = studentList.Count();

            Console.WriteLine($"Total Students: {totalStudents}");

            var adultStudents = studentList.Count(s => s.Age >= 18);

            Console.WriteLine($"Number of Adult Students: {adultStudents}");


            // Query syntax. 
            var totalAge = (from s in studentList
                            select s.Age).Count();

            Console.WriteLine($"Total Age: {totalAge}");
        }

        /* The Max operator returns the largest numeric element from a collection. */
        internal static void Max()
        {
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };

            var largest = intList.Max();

            Console.WriteLine($"Largest Element: {largest}");

            var largestEvenElements = intList.Max(i =>
                                                {
                                                    if (i % 2 == 0)
                                                        return i;

                                                    return 0;
                                                });

            Console.WriteLine($"Largest Even Element: {largestEvenElements}");
        }

        internal static void Max_With_Complex_Type()
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
             };

            var oldest = studentList.Max(s => s.Age);

            Console.WriteLine($"Oldest Student Age: {oldest}");
        }

        internal static void Max_With_Complex_Type_studentWithLongName()
        {
            // Type implements IComparable on StudentName property.
            IList<Entities.Max.Student> studentList = new List<Entities.Max.Student>()
            {
                new Entities.Max.Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Entities.Max.Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Entities.Max.Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Entities.Max.Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Entities.Max.Student() { StudentID = 5, StudentName = "Steve", Age = 15 }
            };

            var studentWithLongName = studentList.Max();

            Console.WriteLine($"Student ID: {studentWithLongName.StudentID}, Student Name: {studentWithLongName.StudentName}");
        }

        /* The Sum method calculates the sum of numeric items in the collection. */
        internal static void Sum()
        {
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };

            var total = intList.Sum();

            Console.WriteLine($"Sum: {total}");

            // Second overload.
            var sumOfEvenElements = intList.Sum(i =>
                                            {
                                                if (i % 2 == 0)
                                                    return i;

                                                return 0;
                                            });

            Console.WriteLine($"Sum of Even Elements: {sumOfEvenElements}");
        }

        internal static void Sum_With_Complex_Type()
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
            };

            var sumOfAge = studentList.Sum(s => s.Age);

            Console.WriteLine($"Sum of all student's age: {sumOfAge}");

            var numberOfAdults = studentList.Sum(s =>
                                                {
                                                    if (s.Age >= 18)
                                                        return 1;
                                                    else
                                                        return 0;
                                                });

            Console.WriteLine($"Total number of adult students: {numberOfAdults}");

        }
        #endregion

        #region 9. Element Operators

        /* Element operators return a particular element from a sequence (collection). 
         * 1. Use First, Last, Single, ElementAt WHEN YOU AT LEAST EXPECT A VALUE, otherwise 
         *    an exception will be thrown.
         * 2. FirstOrDefault, LastOrDefault, SingleOrDefault, ElementAtOrDefault will return 
         *    DEFAULTS for the type if there is no value*/

        internal static void ElementAt_And_ElementAtOrDefault()
        {
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { "One", "Two", null, "Four", "Five" };

            Console.WriteLine($"1st Element in intList: {intList.ElementAt(0)}");
            Console.WriteLine($"1st Element in strList: {strList.ElementAt(0)}");

            Console.WriteLine($"2nd Element in intList: {intList.ElementAt(1)}");
            Console.WriteLine($"2nd Element in strList: {strList.ElementAt(1)}");

            Console.WriteLine($"3rd Element in intList: {intList.ElementAt(2)}");
            Console.WriteLine($"3rd Element in strList: {strList.ElementAt(2)}");

            Console.WriteLine($"10th Element in intList: {intList.ElementAtOrDefault(9)} - default int value.");
            Console.WriteLine($"10th Element in strList: {strList.ElementAtOrDefault(9)} - default string value (null)");

            Console.WriteLine("intList.ElementAt(9) throws an exception: Index out of range");
            Console.WriteLine("-------------------------------------------------------------");
            //Console.WriteLine(intList.ElementAt(9));
        }

        internal static void First()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine($"1st Element in intList: {intList.First()}");
            Console.WriteLine($"1st Even Element in intList: {intList.First(i => i % 2 == 0)}");


            Console.WriteLine($"1st Element in strList: {strList.First()}");

            Console.WriteLine($"emptyList.First() throws an InvalidOperationException");
            Console.WriteLine($"-------------------------------------------------------------");
            //Console.WriteLine($"{emptyList.First()}");
        }

        internal static void FirstOrDefault()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine($"1st Element in intList: {intList.FirstOrDefault()}");
            Console.WriteLine($"1st Even Element in intList: {intList.FirstOrDefault(i => i % 2 == 0)}");

            Console.WriteLine($"1st Element in strList: {strList.FirstOrDefault()}");
            Console.WriteLine("1st Element in emptyList: {0}", emptyList.FirstOrDefault());
        }

        /* Be careful while specifying condition in First() or FirstOrDefault(). 
         * 1. First() will throw an exception if a collection does not include any element that satisfies 
         *    the specified condition or includes null element. 
         * 2. If a collection includes null element then FirstOrDefault() throws an exception while 
         *    evaluting the specified condition. The following example demonstrates this.
         */
        internal static void First_And_FirstOrDefault_Watchout_For_Exceptions()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };

            /* FirstOrDefault - Exception will not be thrown, NULL appears after lambda expression 
             * condition has already been met.*/
            //IList<string> strList = new List<string>() { "Two", "Three", "Four", null, "Five" };

            //Console.WriteLine($"1st Element which is greater than 250 in intList: {intList.First(i => i > 250)}");

            // This really depends where NULL appears in the collection.
            Console.WriteLine($"Will throw an exception if collection contains null: {strList.FirstOrDefault(s => s.Contains("T"))}");
        }

        internal static void Last()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine($"Last Element in intList: {intList.Last()}");
            Console.WriteLine($"Last Even Element in intList: {intList.Last(i => i % 2 == 0)}");

            Console.WriteLine($"Last Element in strList: {strList.Last()}");

            Console.WriteLine($"emptyList.Last() throws an InvalidOperationException");
            Console.WriteLine($"-------------------------------------------------------------");
            //Console.WriteLine(emptyList.Last());
        }

        internal static void LastOrDefault()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine($"Last Element in intList: {intList.LastOrDefault()}");
            Console.WriteLine($"Last Even Element in intList: {intList.LastOrDefault(i => i % 2 == 0)}");

            Console.WriteLine($"Last Element in strList: {strList.LastOrDefault()}");

            Console.WriteLine($"Last Element in emptyList: {emptyList.LastOrDefault()}");
        }

        internal static void Last_And_LastOrDefault_Watchout_For_Exceptions()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };

            Console.WriteLine($"Last Element which is greater than 250 in intList: {intList.Last(i => i > 250)}");

            Console.WriteLine($"Last Even Element in intList: {strList.LastOrDefault(s => s.Contains("T"))}");
        }

        /* Returns the only element from a collection, or the only element that satisfies a condition. 
         * If Single() found no elements or more than one elements in the collection then throws InvalidOperationException. */
        internal static void Single_And_SingleOrDefault()
        {
            IList<int> oneElementList = new List<int>() { 7 };
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine($"The only element in oneElementList: {oneElementList.Single()}");
            Console.WriteLine($"The only element in oneElementList: {oneElementList.SingleOrDefault()}");

            Console.WriteLine($"Element in emptyList: {emptyList.SingleOrDefault()}");

            Console.WriteLine($"The only element which is less than 10 in intList: {intList.Single(i => i < 10)}");

            //Followings throw an exception
            //Console.WriteLine($"The only Element in intList: {intList.Single()}");
            //Console.WriteLine($"The only Element in intList: {intList.SingleOrDefault()}");
            //Console.WriteLine($"The only Element in emptyList: {emptyList.Single()}");
        }

        internal static void Single_And_SingleOrDefault_Exceptions_Thrown_For_None_Or_Multiple_Elements_Returned()
        {
            IList<int> oneElementList = new List<int>() { 7 };
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            // Following throws error because list contains more than one element which is less than 100
            Console.WriteLine($"Element less than 100 in intList: {intList.Single(i => i < 100)}");

            // Following throws error because list contains more than one element which is less than 100
            Console.WriteLine($"Element less than 100 in intList: {intList.SingleOrDefault(i => i < 100)}");

            // Following throws error because list contains more than one elements
            Console.WriteLine($"The only Element in intList: {intList.Single()}");

            // Following throws error because list contains more than one elements
            Console.WriteLine($"The only Element in intList: {intList.SingleOrDefault()}");

            // Following throws error because list does not contains any element
            Console.WriteLine($"The only Element in emptyList: {emptyList.Single()}");
        }
        #endregion

        #region 10. Equality Operator
        /* There is only one equality operator: SequenceEqual. The SequenceEqual method checks whether 
         * the number of elements, value of each element and order of elements in two collections are 
         * equal or not. */

        /* If the collection contains elements of primitive data types then it compares the values and 
         * number of elements, whereas collection with complex type elements, checks the references of 
         * the objects. So, if the objects have the same reference then they considered as equal otherwise 
         * they are considered not equal. */

        internal static void SequenceEqual_1()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Three" };

            IList<string> strList2 = new List<string>() { "One", "Two", "Three", "Four", "Three" };

            bool isEqual = strList1.SequenceEqual(strList2); // returns true
            Console.WriteLine($"{isEqual}");
        }

        internal static void SequenceEqual_2()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Three" };

            IList<string> strList2 = new List<string>() { "Two", "One", "Three", "Four", "Three" };

            // Notice the order of the elements are not the same - "One" and "Two".
            bool isEqual = strList1.SequenceEqual(strList2); // returns false
            Console.WriteLine($"{isEqual}");
        }

        internal static void SequenceEqual_3_Complex_Types()
        {
            Student std = new Student() { StudentID = 1, StudentName = "Bill" };

            IList<Student> studentList1 = new List<Student>() { std };

            IList<Student> studentList2 = new List<Student>() { std };

            bool isEqual = studentList1.SequenceEqual(studentList2); // returns true
            Console.WriteLine($"{isEqual}");

            Student std1 = new Student() { StudentID = 1, StudentName = "Bill" };
            Student std2 = new Student() { StudentID = 1, StudentName = "Bill" };

            IList<Student> studentList3 = new List<Student>() { std1 };

            IList<Student> studentList4 = new List<Student>() { std2 };

            isEqual = studentList3.SequenceEqual(studentList4);// returns false
            Console.WriteLine($"{isEqual}");
        }

        /* To compare the values of two collection of complex type (reference type or object), you need 
         * to implement IEqualityComperar<T> interface as shown below. */
        internal static void SequenceEqual_3_Collection_Of_Complex_Types()
        {
            IList<Student> studentList1 = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            IList<Student> studentList2 = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };
            // following returns true
            bool isEqual = studentList1.SequenceEqual(studentList2, new StudentComparer());
            Console.WriteLine($"{isEqual}");
        }
        #endregion

        #region 11. Concatenation Operator.

        /* The Concat() method appends two sequences of the same type and returns a new sequence (collection). */
        internal static void Concat()
        {
            IList<string> collection1 = new List<string>() { "One", "Two", "Three" };
            IList<string> collection2 = new List<string>() { "Five", "Six" };

            var collection3 = collection1.Concat(collection2);

            foreach (string str in collection3)
            {
                Console.WriteLine($"{str}");
            }
        }
        #endregion

        #region 12. Generation Operator

        /* The DefaultIfEmpty() method returns a new collection with the default value if the given 
         * collection on which DefaultIfEmpty() is invoked is empty. */
        internal static void DefaultIfEmpty()
        {
            IList<string> emptyList = new List<string>();

            var newList1 = emptyList.DefaultIfEmpty();
            var newList2 = emptyList.DefaultIfEmpty("None");

            Console.WriteLine($"Count: {newList1.Count()}");
            Console.WriteLine($"Value: {newList1.ElementAt(0)}");

            Console.WriteLine($"Count: {newList2.Count()}");
            Console.WriteLine($"Value: {newList2.ElementAt(0)}");
        }

        internal static void DefaultIfEmpty_Int_Collection()
        {
            IList<int> emptyList = new List<int>();

            var newList1 = emptyList.DefaultIfEmpty();
            var newList2 = emptyList.DefaultIfEmpty(100);

            Console.WriteLine($"Count: {newList1.Count()}");
            Console.WriteLine($"Value: {newList1.ElementAt(0)}");

            Console.WriteLine($"Count: {newList2.Count()}");
            Console.WriteLine($"Value: {newList2.ElementAt(0)}");
        }

        internal static void DefaultIfEmpty_Complex_Type_Collection()
        {
            IList<Student> emptyStudentList = new List<Student>();

            var newStudentList1 = emptyStudentList.DefaultIfEmpty(new Student());

            var newStudentList2 = emptyStudentList.DefaultIfEmpty(new Student()
            {
                StudentID = 0,
                StudentName = ""
            });

            Console.WriteLine($"Count: {newStudentList1.Count()}");
            Console.WriteLine($"Student ID: {newStudentList1.ElementAt(0).StudentID}");

            Console.WriteLine($"Count: {newStudentList2.Count()}");
            Console.WriteLine($"Student ID: {newStudentList2.ElementAt(0).StudentID}");
        }

        /* 
         * The Empty() method is not an extension method of IEnumerable or IQueryable like other LINQ methods. 
         * IT IS A STATIC METHOD INCLUDED IN ENUMERABLE STATIC CLASS.
         * */
        // The Empty() method returns an empty collection of a specified type as shown below.
        internal static void Empty()
        {
            var emptyCollection1 = Enumerable.Empty<string>();
            var emptyCollection2 = Enumerable.Empty<Student>();

            Console.WriteLine($"Count: {emptyCollection1.Count()}");
            Console.WriteLine($"Type: {emptyCollection1.GetType().Name}");

            Console.WriteLine($"Count: {emptyCollection2.Count()}");
            Console.WriteLine($"Type: {emptyCollection2.GetType().Name}");
        }

        /* The Range() method returns a collection of IEnumerable<T> type with specified number of 
         * elements and sequential values starting from the first element. */
        internal static void Range()
        {
            var intCollection = Enumerable.Range(10, 10);
            Console.WriteLine($"Total Count: {intCollection.Count()}");

            for (int i = 0; i < intCollection.Count(); i++)
            {
                Console.WriteLine($"Value at index {i} : {intCollection.ElementAt(i)}");
            }
        }

        /* The Repeat() method generates a collection of IEnumerable<T> type with specified number 
         * of elements and each element contains same specified value. */
        internal static void Repeat()
        {
            var intCollection = Enumerable.Repeat<int>(10, 10);
            Console.WriteLine($"Total Count: {intCollection.Count()}");

            for (int i = 0; i < intCollection.Count(); i++)
            {
                Console.WriteLine($"Value at index {i} : {intCollection.ElementAt(i)}");
            }
        }
        #endregion

        #region 13. Set Operators

        /* The Distinct extension method returns a new collection of unique elements from the given collection. */
        internal static void Distinct()
        {
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Two", "Three" };

            IList<int> intList = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };

            var distinctList1 = strList.Distinct();

            foreach (var str in distinctList1)
            {
                Console.WriteLine($"{str}");
            }

            var distinctList2 = intList.Distinct();

            foreach (var i in distinctList2)
            {
                Console.WriteLine($"{i}");
            }
        }

        /* The Distinct extension method doesn't compare values of complex type objects. You need to 
         * implement IEqualityComparer<T> interface in order to compare the values of complex types. */
        internal static void Distinct_With_Complex_Type()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            // GeeNote: StudentComparer - obj.StudentID.GetHashCode();
            var distinctStudents = studentList.Distinct(new Helpers.Distinct.StudentComparer());

            foreach (Student std in distinctStudents)
            {
                Console.WriteLine($"{std.StudentName}");
            }
        }

        /* The Except() method requires two collections. It returns a new collection with elements from 
         * the first collection which do not exist in the second collection (parameter collection). */
        internal static void Except()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result = strList1.Except(strList2);

            foreach (string str in result)
            {
                Console.WriteLine($"{str}");
            }
        }

        /* Except extension method doesn't return the correct result for the collection of complex types. You 
         * need to implement IEqualityComparer interface in order to get the correct result from Except method. */
        internal static void Except_With_Complex_Type()
        {
            IList<Student> studentList1 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            IList<Student> studentList2 = new List<Student>() {
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var resultedCol = studentList1.Except(studentList2, new Helpers.Distinct.StudentComparer());

            foreach (Student std in resultedCol)
            {
                Console.WriteLine($"{std.StudentName}");
            }
        }

        /* The Intersect extension method requires two collections. It returns a new collection that includes 
         * common elements that exists in both the collection. Consider the following example. */
        internal static void Intersect()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result = strList1.Intersect(strList2);

            foreach (string str in result)
            {
                Console.WriteLine($"{str}");
            }
        }

        /* The Intersect extension method doesn't return the correct result for the collection of complex types. 
         * You need to implement IEqualityComparer interface in order to get the correct result from Intersect method. */
        internal static void Intersect_With_Complex_Type()
        {
            IList<Student> studentList1 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            IList<Student> studentList2 = new List<Student>() {
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var resultedCol = studentList1.Intersect(studentList2, new Helpers.Distinct.StudentComparer());

            foreach (Student std in resultedCol)
            {
                Console.WriteLine($"{std.StudentName}");

            }
        }

        /* The Union extension method requires two collections and returns a new collection that includes 
         * distinct elements from both the collections. Consider the following example. */
        internal static void Union()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "three", "Four" };
            IList<string> strList2 = new List<string>() { "Two", "THREE", "Four", "Five" };

            var result = strList1.Union(strList2);

            foreach (string str in result)
            {
                Console.WriteLine($"{str}");
            }
        }

        /* The Union extension method doesn't return the correct result for the collection of complex types. 
         * You need to implement IEqualityComparer interface in order to get the correct result from Union method. */
        internal static void Union_With_Complex_Type()
        {
            IList<Student> studentList1 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            IList<Student> studentList2 = new List<Student>() {
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var resultedCol = studentList1.Union(studentList2, new Helpers.Union.StudentComparer());

            foreach (Student std in resultedCol)
            {
                Console.WriteLine($"{std.StudentName}");
            }                
        }
        #endregion

        #region 14. Partitioning Operators 

        /* The Skip() method skips the specified number of element starting from first element and returns 
         * rest of the elements. */
        internal static void Skip()
        {
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var newList = strList.Skip(2);

            foreach (var str in newList)
            {
                Console.WriteLine($"{str}");
            } 
        }

        /* The SkipWhile() extension method in LINQ skip elements in the collection till the specified condition 
         * is true. It returns a new collection that includes all the remaining elements once the specified condition 
         * becomes false for any element. */
        internal static void SkipWhile_1()
        {
            // First two are true for the lambda condition.
            IList<string> strList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Six"  };

            var resultList = strList.SkipWhile(s => s.Length < 4);

            foreach (string str in resultList)
            {
                Console.WriteLine($"{str}");
            }
        }

        internal static void SkipWhile_2()
        {
            // The first elements are false for the lambda expression.
            // Observe the returned result.
            IList<string> strList = new List<string>() {
                                            "Three",
                                            "One",
                                            "Two",                                          
                                            "Four",
                                            "Five",
                                            "Six"  };

            var result = strList.SkipWhile((s) => s.Length < 4);

            foreach (string str in result)
            {
                Console.WriteLine($"{str}");
            }
        }

        // The second overload of SkipWhile passes an index of each elements.
        internal static void SkipWhile_3()
        {
            IList<string> strList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Six"  };

            var result = strList.SkipWhile((s, i) => s.Length > i);

            foreach (string str in result)
            {
                Console.WriteLine($"{str}");
            }
        }

        /* The Take() extension method returns the specified number of elements starting from the first element. */
        internal static void Take()
        {
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var newList = strList.Take(2);

            foreach (var str in newList)
            {
                Console.WriteLine($"{str}");
            }                
        }

        /* The TakeWhile() extension method returns elements from the given collection until the specified 
         * condition is false. If the first element itself doesn't satisfy the condition then returns an empty 
         * collection. */
        internal static void TakeWhile_1()
        {
            IList<string> strList = new List<string>() {
                                            "Three",
                                            "Four",// From this elment will be ingored because condition is false.
                                            "Five",
                                            "Hundred"  };

            var result = strList.TakeWhile(s => s.Length > 4);

            foreach (string str in result)
            {
                Console.WriteLine($"{str}");
            }
        }

        internal static void TakeWhile_2()
        {
            IList<string> strList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Six"  };

            var resultList = strList.TakeWhile((s, i) => s.Length > i);

            foreach (string str in resultList)
            {
                Console.WriteLine($"{str}");
            }
        }
        #endregion

        #region 15. Conversion Operators

        static void ReportTypeProperties<T>(T obj)
        {
            Console.WriteLine($"Compile-time type: {typeof(T).Name}");
            Console.WriteLine($"Actual type: {obj.GetType().Name}");
        }

        /* The AsEnumerable and AsQueryable methods cast or convert a source object to IEnumerable<T> or 
         * IQueryable<T> respectively. */
        internal static void AsEnumerable_And_AsQueryable()
        {
            Student[] studentArray = 
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
            };

            ReportTypeProperties(studentArray);
            ReportTypeProperties(studentArray.AsEnumerable());
            ReportTypeProperties(studentArray.AsQueryable());
        }

        /* Cast does the same thing as AsEnumerable<T>. It cast the source object into IEnumerable<T>. */
        internal static void Cast()
        {
            Student[] studentArray = {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
            };

            ReportTypeProperties(studentArray);
            ReportTypeProperties(studentArray.Cast<Student>());
        }

        /*  As the name suggests, ToArray(), ToList(), ToDictionary() method converts a source object into an array, 
         *  List or Dictionary respectively. */

        internal static void ToArray_And_ToList()
        {
            IList<string> strList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Three"
                                            };

            string[] strArray = strList.ToArray<string>();// converts List to Array

            IList<string> list = strArray.ToList<string>(); // converts array into list
        }

        // ToDictionary - Converts a Generic list to a generic dictionary:
        internal static void ToDictionary()
        {
            IList<Entities.ToDictionary.Student> studentList = new List<Entities.ToDictionary.Student>()
            {
                new Entities.ToDictionary.Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Entities.ToDictionary.Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Entities.ToDictionary.Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Entities.ToDictionary.Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Entities.ToDictionary.Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

            //following converts list into dictionary where StudentId is a key
            IDictionary<int, Entities.ToDictionary.Student> studentDict =
                                            studentList.ToDictionary(s => s.StudentID);

            foreach (var key in studentDict.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {(studentDict[key] as Entities.ToDictionary.Student).StudentName}");
            }               
        }
        #endregion
    }
}
 