using System;

using DisDogSharp.Entities;

namespace DisDogSharp.EventArgs;

/// <summary>
/// Represents arguments for <see cref="DiscordClient.InteractionCreated"/>
/// </summary>
public class InteractionCreateEventArgs : DiscordEventArgs
{
	/// <summary>
	/// Gets the interaction data that was invoked.
	/// </summary>
	public DiscordInteraction Interaction { get; internal set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="InteractionCreateEventArgs"/> class.
	/// </summary>
	/// <param name="provider">The provider.</param>
	public InteractionCreateEventArgs(IServiceProvider provider)
		: base(provider)
	{ }
}
