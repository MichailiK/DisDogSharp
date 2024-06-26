using System;

using DisDogSharp.Entities;

namespace DisDogSharp.EventArgs;

/// <summary>
/// Represents arguments for <see cref="DiscordClient.AutomodRuleUpdated"/> event.
/// </summary>
public class AutomodRuleUpdateEventArgs : DiscordEventArgs
{
	/// <summary>
	/// Gets the rule that has been updated.
	/// </summary>
	public AutomodRule Rule { get; internal set; }

	public AutomodRuleUpdateEventArgs(IServiceProvider provider)
		: base(provider)
	{ }
}
