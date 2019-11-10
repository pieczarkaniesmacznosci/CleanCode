using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class OutputParameters
    {
        public void DisplayCustomers()
        {
            int totalCount = 0;
            var tuple = GetCustomers(1);
            var customers = tuple.Item1;
            totalCount = tuple.Item2;

            Console.WriteLine("Total customers: " + totalCount);
            foreach (var c in customers)
                Console.WriteLine(c);
        }

        public Tuple<IEnumerable<Customer>, int> GetCustomers(int pageIndex)
        {
            var totalCount = 100;
            return Tuple.Create((IEnumerable<Customer>) new List<Customer>(), totalCount);
        }
    }
}
