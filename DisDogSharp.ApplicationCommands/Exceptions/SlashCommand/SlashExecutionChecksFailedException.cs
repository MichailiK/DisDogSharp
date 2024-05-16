using System;
using System.Collections.Generic;

using DisDogSharp.ApplicationCommands.Attributes;

namespace DisDogSharp.ApplicationCommands.Exceptions;

/// <summary>
/// Thrown when a pre-execution check for a slash command fails.
/// </summary>
public class SlashExecutionChecksFailedException : Exception
{
	/// <summary>
	/// The list of failed checks.
	/// </summary>
	public IReadOnlyList<ApplicationCommandCheckBaseAttribute> FailedChecks;
}
