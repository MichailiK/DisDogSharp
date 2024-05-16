using System;

using DisDogSharp.Entities;

namespace DisDogSharp.EventArgs;

/// <summary>
/// Represents arguments for <see cref="DiscordClient.GuildScheduledEventUpdated"/> event.
/// </summary>
public class GuildScheduledEventUpdateEventArgs : DiscordEventArgs
{
	/// <summary>
	/// Gets the scheduled event that was updated.
	/// </summary>
	public DiscordScheduledEvent ScheduledEventAfter { get; internal set; }

	/// <summary>
	/// Gets the old scheduled event that was updated.
	/// </summary>
	public DiscordScheduledEvent ScheduledEventBefore { get; internal set; }

	/// <summary>
	/// Gets the guild in which the scheduled event was updated.
	/// </summary>
	public DiscordGuild Guild { get; internal set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="GuildScheduledEventUpdateEventArgs"/> class.
	/// </summary>
	internal GuildScheduledEventUpdateEventArgs(IServiceProvider provider)
		: base(provider)
	{ }
}
