
using System;
using System.Collections.Generic;

namespace CleanCode.LongParameterList
{
    /*
     
        -less than 3 input parameters

     */
    public class DateRange
    {
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }

        public DateRange( DateTime fromDate, DateTime toDate )
        {
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
    public class ReservationsQuery
    {
        public ReservationsQuery(DateRange dateRange,
           User user, int locationId,
           LocationType locationType, int? customerId = null)
        {
            DateRange = dateRange;
            User = user;
            LocationId = locationId;
            LocationType = locationType;
            CustomerId = customerId;
        }

        public DateRange DateRange { get; }
        public User User { get; }
        public int LocationId { get; }
        public LocationType LocationType { get; }
        public int? CustomerId { get; }
    }

    public class LongParameterList
    {
        public IEnumerable<Reservation> GetReservations(
           ReservationsQuery query)
        {
            if (query.DateRange.FromDate >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (query.DateRange.ToDate <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetUpcomingReservations(ReservationsQuery query)
        {
            if (query.DateRange.FromDate >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (query.DateRange.ToDate <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        private static Tuple<DateTime, DateTime> GetReservationDateRange(
           DateRange dateRange, ReservationDefinition sd)
        {
            if (dateRange.FromDate >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.ToDate <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public void CreateReservation(
           DateRange dateRange, int locationId)
        {
            if (dateRange.FromDate >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.ToDate <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }
    }

    internal class ReservationDefinition
    {
    }

    public class LocationType
    {
    }

    public class User
    {
        public object Id { get; set; }
    }

    public class Reservation
    {
    }
}
