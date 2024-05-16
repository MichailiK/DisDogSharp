using System;

using DisDogSharp.Entities;

namespace DisDogSharp.EventArgs;

/// <summary>
/// Represents arguments for <see cref="DiscordClient.UserSettingsUpdated"/> event.
/// </summary>
public class UserSettingsUpdateEventArgs : DiscordEventArgs
{
	/// <summary>
	/// Gets the user whose settings were updated.
	/// </summary>
	public DiscordUser User { get; internal set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="UserSettingsUpdateEventArgs"/> class.
	/// </summary>
	internal UserSettingsUpdateEventArgs(IServiceProvider provider)
		: base(provider)
	{ }
}
