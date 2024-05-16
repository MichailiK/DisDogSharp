using System.Collections.Generic;
using System.Threading.Tasks;

using DisDogSharp.ApplicationCommands.Context;
using DisDogSharp.Entities;

namespace DisDogSharp.ApplicationCommands.Attributes;

/// <summary>
/// The autocomplete provider.
/// </summary>
public interface IAutocompleteProvider
{
	/// <summary>
	/// Provider the autocompletion.
	/// </summary>
	/// <param name="context">The context.</param>
	Task<IEnumerable<DiscordApplicationCommandAutocompleteChoice>> Provider(AutocompleteContext context);
}
