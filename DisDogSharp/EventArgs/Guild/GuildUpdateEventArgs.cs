using System;

using DisDogSharp.Entities;

namespace DisDogSharp.EventArgs;

/// <summary>
/// Represents arguments for <see cref="DiscordClient.GuildUpdated"/> event.
/// </summary>
public class GuildUpdateEventArgs : DiscordEventArgs
{
	/// <summary>
	/// Gets the guild before it was updated.
	/// </summary>
	public DiscordGuild GuildBefore { get; internal set; }

	/// <summary>
	/// Gets the guild after it was updated.
	/// </summary>
	public DiscordGuild GuildAfter { get; internal set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="GuildUpdateEventArgs"/> class.
	/// </summary>
	internal GuildUpdateEventArgs(IServiceProvider provider)
		: base(provider)
	{ }
}
