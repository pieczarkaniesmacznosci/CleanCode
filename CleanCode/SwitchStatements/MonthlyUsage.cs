using System;

namespace CleanCode.SwitchStatements
{
    public class MonthlyUsage
    {
        public Customer Customer { get; set; }
        public int CallMinutes { get; set; }
        public int SmsCount { get; set; }

        public MonthlyStatement GenerateStatement()
        {
            var statement = new MonthlyStatement();
            switch (Customer.Type)
            {
                case CustomerType.PayAsYouGo:
                    statement.CallCost = 0.12f * CallMinutes;
                    statement.SmsCost = 0.12f * SmsCount;
                    statement.TotalCost = statement.CallCost + statement.SmsCost;
                    break;

                case CustomerType.Unlimited:
                    statement.TotalCost = 54.90f;
                    break;

                default:
                    throw new NotSupportedException("The current customer type is not supported");
            }
            return statement;
        }
    }
}