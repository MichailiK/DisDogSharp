using System;
using System.Linq;
using System.Threading.Tasks;

using DisDogSharp.ApplicationCommands.Context;

namespace DisDogSharp.ApplicationCommands.Attributes;

/// <summary>
/// Defines that this application command is restricted to the team members of the bot.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false)]
public sealed class ApplicationCommandRequireTeamMemberAttribute : ApplicationCommandCheckBaseAttribute
{
	/// <summary>
	/// Defines that this application command is restricted to the team members of the bot.
	/// </summary>
	public ApplicationCommandRequireTeamMemberAttribute()
	{ }

	/// <summary>
	/// Runs checks.
	/// </summary>
	public override Task<bool> ExecuteChecksAsync(BaseContext ctx)
	{
		var app = ctx.Client.CurrentApplication!;
		return app.Team is null ? Task.FromResult(app.Owner.Id == ctx.User.Id) : Task.FromResult(app.Members.Any(x => x.Id == ctx.User.Id));
	}
}
