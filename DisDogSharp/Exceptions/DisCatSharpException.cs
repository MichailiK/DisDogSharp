using System;

namespace DisDogSharp.Exceptions;

/// <summary>
/// Represents a generic exception thrown by DisDogSharp.
/// </summary>
public class DisCatSharpException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="DisCatSharpException"/> class.
	/// </summary>
	/// <param name="message">The error message.</param>
	internal DisCatSharpException(string message)
		: base(message)
	{ }
}
