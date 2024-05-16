using System.Threading.Tasks;

using DisDogSharp.ApplicationCommands.Attributes;
using DisDogSharp.ApplicationCommands.Context;
using DisDogSharp.Entities;
using DisDogSharp.Enums;

namespace DisDogSharp.ApplicationCommands.Tests.SplitTest;

[SlashCommandGroup("test", "test")]
internal partial class TestCommand : ApplicationCommandsModule
{
	[SlashCommand("test_1", "test 1")]
	internal static async Task Test1Async(InteractionContext ctx)
	{
		await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
			new DiscordInteractionResponseBuilder().AsEphemeral().WithContent("Meow"));
	}
}
