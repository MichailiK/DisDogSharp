using System;
using System.Collections.Generic;

using DisDogSharp.ApplicationCommands.Attributes;

namespace DisDogSharp.ApplicationCommands.Exceptions;

/// <summary>
/// Thrown when a pre-execution check for a context menu command fails.
/// </summary>
public sealed class ContextMenuExecutionChecksFailedException : Exception
{
	/// <summary>
	/// The list of failed checks.
	/// </summary>
	public IReadOnlyList<ApplicationCommandCheckBaseAttribute> FailedChecks;
}
