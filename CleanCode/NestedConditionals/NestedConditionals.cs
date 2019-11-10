using System;

namespace CleanCode.NestedConditionals
{
    public class Customer
    {
        public int LoyaltyPoints { get; set; }
    }

    public class Reservation
    {
        public Reservation(Customer customer, DateTime dateTime)
        {
            From = dateTime;
            Customer = customer;
        }

        public DateTime From { get; set; }
        public Customer Customer { get; set; }
        public bool IsCanceled { get; set; }

        public void Cancel()
        {
            if (DateTime.Now > From)
            {
                throw new InvalidOperationException("It's too late to cancel.");
            }
            else
            {
                if (Customer.LoyaltyPoints > 100)
                {
                    if (LessThan(24))
                    {
                        throw new InvalidOperationException("It's too late to cancel.");
                    }
                    IsCanceled = true;
                }
                else
                {
                    if (LessThan(48))
                    {
                        throw new InvalidOperationException("It's too late to cancel.");
                    }
                    IsCanceled = true;
                }
            }
        }

        private bool LessThan(int hours)
        {
            return (From - DateTime.Now).TotalHours < hours;
        }
    }
}
