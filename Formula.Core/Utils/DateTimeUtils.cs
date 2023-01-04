using System;

namespace Formula.Core.Utils
{
	/// <summary>
	/// DateTimeUtils helper methods
	/// </summary>
	public static class DateTimeUtils
	{
		// NOTE: 
		// This is the ONLY place in the code where you assign the Empty value.
		// This value can be changed if there is a good reason to for example. This value in SQL Server 
		// will throw an error so this could be changed to '01/01/1753' using SqlDateTime.MinValue if there is good reason.
		// The good news is that is you use the Empty property to check equality in your app... you can safely 
		// change the default value of Empty with no side effects.


		/// <summary>
		/// Represents an empty DateTime. This is the ONLY place in the application where the concept of "Empty"
		/// resides.
		/// </summary>
		public static readonly DateTime Empty = DateTime.MinValue;

		/// <summary>
		/// Converts a nullable DataTime to a DateTime object. If the value is null it return the DateTime.Empty value
		/// </summary>
		/// <param name="nullableDateTime"></param>
		/// <returns></returns>
		public static DateTime ToDateTime(DateTime? nullableDateTime)
		{
			if (nullableDateTime == null)
			{
				return Empty;
			}
			return nullableDateTime.Value;
		}

		/// <summary>
		/// Coherces any .NET type into a DateTime object. This can take a string
		/// and will internally 'Parse' the input into a DateTime.
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
        public static DateTime ToDateTime(object input)
        {
			if(input == null) throw new ArgumentNullException(nameof(input));
			
			DateTime dt;
			try
			{
				dt = DateTime.Parse(input.ToString());
			}
			catch (Exception)
			{
				throw;
			}
			return dt;
        }

        /// <summary>
        /// Determines if the date time is an empty value
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsEmpty(DateTime dateTime)
		{
			////////////////////////
			// NOTE: Depending on the specific application you can add any 
			//		 conditionals here to represent a empty date time.
			///////////////////////////////////////////////////////////

			if (dateTime == Empty)
			{
				return true;
			}
			return false;
		}
	
		/// <summary>
		/// Return DateTime representing NOW in UTC time.
		/// </summary>
		/// <returns></returns>
		public static DateTime GetUtcNow()
		{
			return DateTime.UtcNow;
		}

		/// <summary>
		/// Strips the millisecond precision of the date time argument.
		/// 
		/// This can be very useful when you need to compare date times, especially since
		/// deserializing a date or reading from Sql Server will almost always have a ticks precision 
		/// error.
		/// </summary>
		/// <param name="dateTime"></param>
		public static DateTime StripMilliseconds(DateTime dateTime)
		{
			DateTime newDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
			return newDateTime;
		}

		public static bool IsDateTimeEqual(DateTime date1, DateTime date2, bool ignoreMilliseconds = true)
		{
            var dt1 = ignoreMilliseconds ? StripMilliseconds(date1) : date1;
            var dt2 = ignoreMilliseconds ? StripMilliseconds(date2) : date2;
            return dt1.Equals(dt2); 
		}
		public static bool IsDatePartEqual(DateTime date1, DateTime date2)
		{
			DateTime date1Only = new DateTime(date1.Year, date1.Month, date1.Day);
			DateTime date2Only = new DateTime(date2.Year, date2.Month, date2.Day);
			return IsDateTimeEqual(date1Only, date2Only);
		}
		public static bool IsTimePartEqual(DateTime time1, DateTime time2)
		{
			DateTime time1Only = new DateTime(1, 1, 1, time1.Hour, time1.Minute, time1.Second);
			DateTime time2Only = new DateTime(1, 1, 1, time2.Hour, time2.Minute, time2.Second);
			return IsDateTimeEqual(time1Only, time2Only);
		}
	}
}
