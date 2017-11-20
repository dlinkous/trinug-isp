using System;

namespace Extraction
{
    public class DateTimeUtility : IDateTimeUtility
	{
		public DateTime GetCurrentDateTime() => DateTime.UtcNow;
    }
}
