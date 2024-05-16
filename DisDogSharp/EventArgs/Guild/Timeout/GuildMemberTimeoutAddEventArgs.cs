using System;

using DisDogSharp.Entities;

namespace DisDogSharp.EventArgs;

/// <summary>
/// Represents arguments for <see cref="DiscordClient.GuildMemberTimeoutAdded"/> event.
/// </summary>
public class GuildMemberTimeoutAddEventArgs : DiscordEventArgs
{
	/// <summary>
	/// Gets the member that was timed out.
	/// </summary>
	public DiscordMember Target { get; internal set; }

	/// <summary>
	/// Gets the guild this member was timed out.
	/// </summary>
	public DiscordGuild Guild { get; internal set; }

	/// <summary>
	/// Gets the timeout time.
	/// </summary>
	public DateTimeOffset Timeout { get; internal set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="GuildMemberTimeoutAddEventArgs"/> class.
	/// </summary>
	internal GuildMemberTimeoutAddEventArgs(IServiceProvider provider)
		: base(provider)
	{ }
}
