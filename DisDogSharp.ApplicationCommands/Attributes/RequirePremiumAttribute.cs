using System;
using System.Threading.Tasks;

using DisDogSharp.ApplicationCommands.Context;
using DisDogSharp.Attributes;
using DisDogSharp.Enums;

namespace DisDogSharp.ApplicationCommands.Attributes;

/// <summary>
/// Defines that usage of this application command is restricted to users with a specified entitlement.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false), RequiresFeature(Features.MonetizedApplication)]
public sealed class ApplicationCommandRequirePremiumAttribute : ApplicationCommandCheckBaseAttribute
{
	/// <summary>
	/// Gets the entitlement id required by this attribute.
	/// </summary>
	public ulong? EntitlementId { get; } = null;

	/// <summary>
	/// Defines that usage of this command is restricted to users with a specified entitlement.
	/// </summary>
	/// <param name="entitlementId">Entitlement id required to execute this command.</param>
	[RequiresFeature(Features.MonetizedApplication)]
	public ApplicationCommandRequirePremiumAttribute(ulong entitlementId)
	{
		this.EntitlementId = entitlementId;
	}

	/// <summary>
	/// Defines that usage of this command is restricted to users with a specified entitlement.
	/// <para>Use this attribute if you set <see cref="DiscordConfiguration.SkuId"/> or <see cref="DiscordConfiguration.AutoFetchSkuIds"/> in your &lt;see cref="DiscordConfiguration"/&gt;.</para>
	/// </summary>
	[RequiresFeature(Features.MonetizedApplication)]
	public ApplicationCommandRequirePremiumAttribute()
	{ }

	/// <summary>
	/// Runs checks.
	/// </summary>
	public override async Task<bool> ExecuteChecksAsync(BaseContext ctx)
	{
		var targetSkuId = this.EntitlementId ?? ctx.Client.Configuration.SkuId ?? throw new("Missing SKU ID");

		if (ctx.Interaction.EntitlementSkuIds.Contains(targetSkuId))
			return await Task.FromResult(true).ConfigureAwait(false);

		await ctx.CreateResponseAsync(InteractionResponseType.PremiumRequired).ConfigureAwait(false);
		return await Task.FromResult(false).ConfigureAwait(false);
	}
}
