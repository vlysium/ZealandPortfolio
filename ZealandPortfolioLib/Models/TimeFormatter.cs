using System;

namespace ZealandPortfolioLib.Models;

public static class TimeFormatter
{
	/// <summary>
	/// Formats the given <paramref name="dateTime"/> into a human-readable string representing the relative time elapsed since that date and time.
	/// </summary>
	/// <param name="dateTime">The date and time to calculate the relative time for. </param>
	/// <returns>A string representing the relative time elapsed. </returns>
	public static string FormatRelativeTime(DateTime dateTime)
	{
		DateTime curentDateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Central European Standard Time");

		TimeSpan elapsed = curentDateTime - dateTime;

		if (elapsed.TotalSeconds < 60)
		{
			int seconds = (int)elapsed.TotalSeconds;
			return $"{seconds} {(seconds == 1 ? "sekund" : "sekunder")} siden";
		}

		if (elapsed.TotalMinutes < 60)
		{
			int minutes = (int)elapsed.TotalMinutes;
			return $"{minutes} {(minutes == 1 ? "minut" : "minutter")} siden";
		}

		if (elapsed.TotalHours < 24)
		{
			int hours = (int)elapsed.TotalHours;
			return $"{hours} {(hours == 1 ? "time" : "timer")} siden";
		}

		if (elapsed.TotalDays < 7)
		{
			int days = (int)elapsed.TotalDays;
			return $"{days} {(days == 1 ? "dag" : "dage")} siden";
		}

		if (elapsed.TotalDays < 30)
		{
			int weeks = (int)(elapsed.TotalDays / 7);
			return $"{weeks} {(weeks == 1 ? "uge" : "uger")} siden";
		}

		if (elapsed.TotalDays < 365)
		{
			int months = (int)(elapsed.TotalDays / 30);
			return $"{months} {(months == 1 ? "måned" : "måneder")} siden";
		}

		int years = (int)(elapsed.TotalDays / 365);
		return $"{years} {(years == 1 ? "år" : "år")} siden";
	}
}
