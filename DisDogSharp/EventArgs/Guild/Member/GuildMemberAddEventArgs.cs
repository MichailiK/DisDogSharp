using System;

using DisDogSharp.Entities;

namespace DisDogSharp.EventArgs;

/// <summary>
/// Represents arguments for <see cref="DiscordClient.GuildMemberAdded"/> event.
/// </summary>
public class GuildMemberAddEventArgs : DiscordEventArgs
{
	/// <summary>
	/// Gets the member that was added.
	/// </summary>
	public DiscordMember Member { get; internal set; }

	/// <summary>
	/// Gets the guild the member was added to.
	/// </summary>
	public DiscordGuild Guild { get; internal set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="GuildMemberAddEventArgs"/> class.
	/// </summary>
	internal GuildMemberAddEventArgs(IServiceProvider provider)
		: base(provider)
	{ }
}
