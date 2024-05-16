using System.Threading.Tasks;

using DisDogSharp.ApplicationCommands.Attributes;
using DisDogSharp.ApplicationCommands.Context;
using DisDogSharp.Entities;
using DisDogSharp.Enums;

namespace DisDogSharp.ApplicationCommands.Tests.SplitTest;

internal partial class TestCommand
{
	[SlashCommand("test_2", "test 2")]
	internal static async Task Test2Async(InteractionContext ctx, [Option("user", "User to tag")] DiscordUser? user = null)
	{
		user ??= ctx.User;
		await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
			new DiscordInteractionResponseBuilder().AsEphemeral().WithContent("Nya " + user.Mention));
	}
}
