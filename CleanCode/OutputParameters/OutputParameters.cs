using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class GetCustomersResult
    {
        public IEnumerable<Customer> Customers { get; set; }
        public int TotalCount { get; set; }
    }

    public class OutputParameters
    {
        public void DisplayCustomers()
        {
            int totalCount = 0;
            var obtainedCustoemrs = GetCustomers(pageIndex:1);
            var customers = obtainedCustoemrs.Customers;
            totalCount = obtainedCustoemrs.TotalCount;

            Console.WriteLine("Total customers: " + totalCount);
            foreach (var c in customers)
                Console.WriteLine(c);
        }

        public GetCustomersResult GetCustomers(int pageIndex)
        {
            var totalCount = 100;
            return new GetCustomersResult { Customers= new List<Customer>(), TotalCount = totalCount };
        }
    }
}
