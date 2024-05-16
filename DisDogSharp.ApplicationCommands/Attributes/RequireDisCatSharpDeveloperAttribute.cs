using System;
using System.Threading.Tasks;

using DisDogSharp.ApplicationCommands.Context;

namespace DisDogSharp.ApplicationCommands.Attributes;

/// <summary>
/// Defines that this application command is restricted to DisDogSharp Developers.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false)]
public sealed class ApplicationCommandRequireDisCatSharpDeveloperAttribute : ApplicationCommandCheckBaseAttribute
{
	/// <summary>
	/// Defines that this application command is restricted to DisDogSharp Developers.
	/// </summary>
	public ApplicationCommandRequireDisCatSharpDeveloperAttribute()
	{ }

	/// <summary>
	/// Runs checks.
	/// </summary>
	public override Task<bool> ExecuteChecksAsync(BaseContext ctx)
		=> Task.FromResult(false);
}
