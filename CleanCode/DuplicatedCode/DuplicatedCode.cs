
using System;

namespace CleanCode.DuplicatedCode
{
    public class Time
    {
        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public int Hours { get; }
        public int Minutes { get; }

        public static Time Parse(string str)
        {
            int time;
            int hours = 0;
            int minutes = 0;
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (int.TryParse(str.Replace(":", ""), out time))
                {
                    hours = time / 100;
                    minutes = time % 100;
                }
                else
                {
                    throw new ArgumentException("str");
                }
            }
            else
                throw new ArgumentNullException("str");
            return new Time(hours, minutes);
        }
    }
    class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            var time = Time.Parse(admissionDateTime);

            // Some more logic 
            // ...
            if (time.Hours < 10)
            {

            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            Time time = Time.Parse(admissionDateTime);

            // Some more logic 
            // ...
            if (time.Hours < 10)
            {

            }
        }
    }
}
