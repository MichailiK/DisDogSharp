using System;

using DisDogSharp.Entities;
using DisDogSharp.Enums;

namespace DisDogSharp.EventArgs;

/// <summary>
/// The context menu interaction create event args.
/// </summary>
public sealed class ContextMenuInteractionCreateEventArgs : InteractionCreateEventArgs
{
	/// <summary>
	/// The type of context menu that was used. This is never <see cref="ApplicationCommandType.ChatInput"/>.
	/// </summary>
	public ApplicationCommandType Type { get; internal set; }

	/// <summary>
	/// The user that invoked this interaction. Can be cast to a member if this was on a guild.
	/// </summary>
	public DiscordUser User => this.Interaction.User;

	/// <summary>
	/// The user this interaction targets, if applicable.
	/// </summary>
	public DiscordUser TargetUser { get; internal set; }

	/// <summary>
	/// The message this interaction targets, if applicable.
	/// </summary>
	public DiscordMessage TargetMessage { get; internal set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="ContextMenuInteractionCreateEventArgs"/> class.
	/// </summary>
	/// <param name="provider">The provider.</param>
	public ContextMenuInteractionCreateEventArgs(IServiceProvider provider)
		: base(provider)
	{ }
}
