namespace nVentive.Umbrella.Calendar
{
	/// <summary>
	/// Simple interface for a clock
	/// </summary>
	public interface IClock
	{
		/// <summary>
		/// the current local time
		/// </summary>
		global::System.DateTime Now { get; }

		/// <summary>
		/// The current UTC time
		/// </summary>
		global::System.DateTime UtcNow { get; }

		/// <summary>
		/// The current local date
		/// </summary>
		global::System.DateTime Today { get; }
	}
}
