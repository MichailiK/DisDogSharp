using System;

namespace DisDogSharp.CommandsNext.Attributes;

/// <summary>
/// Defines a lifespan for this command module.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ModuleLifespanAttribute : Attribute
{
	/// <summary>
	/// Gets the lifespan defined for this module.
	/// </summary>
	public ModuleLifespan Lifespan { get; }

	/// <summary>
	/// Defines a lifespan for this command module.
	/// </summary>
	/// <param name="lifespan">Lifespan for this module.</param>
	public ModuleLifespanAttribute(ModuleLifespan lifespan)
	{
		this.Lifespan = lifespan;
	}
}

/// <summary>
/// Defines lifespan of a command module.
/// </summary>
public enum ModuleLifespan
{
	/// <summary>
	/// Defines that this module will be instantiated once.
	/// </summary>
	Singleton = 0,

	/// <summary>
	/// Defines that this module will be instantiated every time a containing command is called.
	/// </summary>
	Transient = 1
}
