using System;

using DisDogSharp.Entities;

namespace DisDogSharp.EventArgs;

/// <summary>
/// Represents arguments for <see cref="DiscordClient.GuildCreated"/> event.
/// </summary>
public class GuildCreateEventArgs : DiscordEventArgs
{
	/// <summary>
	/// Gets the guild that was created.
	/// </summary>
	public DiscordGuild Guild { get; internal set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="GuildCreateEventArgs"/> class.
	/// </summary>
	internal GuildCreateEventArgs(IServiceProvider provider)
		: base(provider)
	{ }
}
