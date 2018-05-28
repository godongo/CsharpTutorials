using System;
using TutorialsTeachersLinq.Demos;

namespace TutorialsTeachersLinq
{
    class ExecuteTutorialsTeachersLinq
    {
        static void Main(string[] args)
        {
            ExecuteLinqOperators();
            //ExecuteLinqQueries();

            Console.ReadKey();
        }

        static void ExecuteLinqOperators()
        {
            // 1. Delegates.
            //LinqOperators.Lambda_Action_Delegate();
            //LinqOperators.Lambda_Func_Delegate();

            // 2. Filtering Operators.
            //LinqOperators.Where_1();
            //LinqOperators.Where_2();
            //LinqOperators.Where_3();
            //LinqOperators.OfType();

            // 3. Sorting Operators.
            //LinqOperators.OrderBy_Ascending_And_Descending();
            //LinqOperators.OrderBy_With_Multiple_Sorting();
            //LinqOperators.OrderBy_ThenBy_And_ThenByDescending();

            // 4. Grouping Operators.
            //LinqOperators.GroupBy_And_ToLook();

            // 5. Join Operators.
            //LinqOperators.Join_1();
            //LinqOperators.Join_2();
            //LinqOperators.Join_3_Query_Syntax();
            //LinqOperators.Join_3_GroupJoin();
            //LinqOperators.Join_3_GroupJoin_Query_Syntax();

            // 6. Projection Operators.
            //LinqOperators.Select();
            //LinqOperators.SelectMany();

            // 7. Quantifier Operators.
            //LinqOperators.All_And_Any();
            //LinqOperators.Contains();
            //LinqOperators.Contains_Using_CustomComparer();

            // 8. Aggregation Operators.
            //LinqOperators.Aggregate();
            //LinqOperators.Aggregate_With_Seed_Value();
            //LinqOperators.Aggregate_With_Result_Selector();
            //LinqOperators.Average();
            //LinqOperators.Average_With_Complex_Type();
            //LinqOperators.Count();
            //LinqOperators.Count_With_Complex_Type();
            //LinqOperators.Max();
            //LinqOperators.Max_With_Complex_Type();
            //LinqOperators.Max_With_Complex_Type_studentWithLongName();
            //LinqOperators.Sum();
            //LinqOperators.Sum_With_Complex_Type();

            // 9. Element Operators.
            //LinqOperators.ElementAt_And_ElementAtOrDefault();
            //LinqOperators.First();
            //LinqOperators.FirstOrDefault();
            //LinqOperators.First_And_FirstOrDefault_Watchout_For_Exceptions();
            //LinqOperators.Last();
            //LinqOperators.LastOrDefault();
            //LinqOperators.Last_And_LastOrDefault_Watchout_For_Exceptions();
            //LinqOperators.Single_And_SingleOrDefault();
            //LinqOperators.Single_And_SingleOrDefault_Exceptions_Thrown_For_None_Or_Multiple_Elements_Returned();

            // 10. Equality Operator.
            //LinqOperators.SequenceEqual_1();
            //LinqOperators.SequenceEqual_2();
            //LinqOperators.SequenceEqual_3_Complex_Types();
            //LinqOperators.SequenceEqual_3_Collection_Of_Complex_Types();

            // 11. Concatenation Operator.
            //LinqOperators.Concat();

            // 12. Generation Operatos.
            //LinqOperators.DefaultIfEmpty();
            //LinqOperators.DefaultIfEmpty_Int_Collection();
            //LinqOperators.DefaultIfEmpty_Complex_Type_Collection();
            //LinqOperators.Empty();
            //LinqOperators.Range();
            //LinqOperators.Repeat(); 

            // 13. Set Operators.
            //LinqOperators.Distinct();
            //LinqOperators.Distinct_With_Complex_Type();
            //LinqOperators.Except();
            //LinqOperators.Except_With_Complex_Type();
            //LinqOperators.Intersect();
            //LinqOperators.Intersect_With_Complex_Type();
            LinqOperators.Union();
            //LinqOperators.Union_With_Complex_Type();

            // 14. Partitioning Operators 
            //LinqOperators.Skip();
            //LinqOperators.SkipWhile_1();
            //LinqOperators.SkipWhile_2();
            //LinqOperators.SkipWhile_3();
            //LinqOperators.Take();
            //LinqOperators.TakeWhile_1();
            //LinqOperators.TakeWhile_2();

            // 15. Conversion Operators
            //LinqOperators.AsEnumerable_And_AsQueryable();
            //LinqOperators.Cast();
            //LinqOperators.ToArray_And_ToList();
            //LinqOperators.ToDictionary();

        }

        static void ExecuteLinqQueries()
        {
            // Linq queries.
            //LinqQueries.GetCustomerOrders();
        }
    }

    
}
