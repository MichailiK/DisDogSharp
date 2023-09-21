using System;
using System.Collections.Generic;

using DisCatSharp.Net.Serialization;

using Newtonsoft.Json;

namespace DisCatSharp.Entities;

/// <summary>
/// Represents an object in the Discord API where the id could be <see langword="null"/>.
/// </summary>
public abstract class NullableSnowflakeObject : ObservableApiObject, IEquatable<NullableSnowflakeObject>, ICloneable
{
	/// <summary>
	/// Gets the ID of this object.
	/// </summary>
	[JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
	public ulong? Id { get; internal set; }

	/// <summary>
	/// Gets the date and time this object was created.
	/// </summary>
	[JsonIgnore]
	public DateTimeOffset? CreationTimestamp
		=> this.Id.GetSnowflakeTime();

	/// <summary>
	/// Initializes a new instance of the <see cref="NullableSnowflakeObject"/> class.
	/// </summary>
	/// <param name="ignored">List of property names to ignore during JSON serialization.</param>
	internal NullableSnowflakeObject(List<string>? ignored = null)
		: base(ignored)
	{
	}

	/// <inheritdoc />
	public override bool Equals(object? obj)
		=> this.Equals(obj as NullableSnowflakeObject);

	/// <inheritdoc />
	public bool Equals(NullableSnowflakeObject? other)
		=> other is not null && this.GetHashCode() == other.GetHashCode();

	/// <inheritdoc />
	public override int GetHashCode()
		=> this.Id.GetHashCode();

	/// <summary>
	/// Determines whether two <see cref="NullableSnowflakeObject"/> instances are equal.
	/// </summary>
	/// <param name="left">The first <see cref="NullableSnowflakeObject"/>.</param>
	/// <param name="right">The second <see cref="NullableSnowflakeObject"/>.</param>
	/// <returns><see langword="true"/> if the instances are equal; otherwise, <see langword="false"/>.</returns>
	public static bool operator ==(NullableSnowflakeObject? left, NullableSnowflakeObject? right)
		=> left is not null && left.Equals(right);

	/// <summary>
	/// Determines whether two <see cref="NullableSnowflakeObject"/> instances are not equal.
	/// </summary>
	/// <param name="left">The first <see cref="NullableSnowflakeObject"/>.</param>
	/// <param name="right">The second <see cref="NullableSnowflakeObject"/>.</param>
	/// <returns><see langword="true"/> if the instances are not equal; otherwise, <see langword="false"/>.</returns>
	public static bool operator !=(NullableSnowflakeObject? left, NullableSnowflakeObject? right)
		=> !(left == right);

	/// <summary>
	/// Determines whether a <see cref="NullableSnowflakeObject"/> is null.
	/// </summary>
	/// <param name="target">The <see cref="NullableSnowflakeObject"/>.</param>
	/// <returns>Returns whether the current <see cref="NullableSnowflakeObject"/> is null.</returns>
	public static bool operator !(NullableSnowflakeObject? target)
		=> target is null;

	/// <summary>
	/// Returns a <see langword="string"/> which represents the <see cref="NullableSnowflakeObject"/>.
	/// </summary>
	/// <returns>A <see langword="string"/> which represents the current <see cref="NullableSnowflakeObject"/>.</returns>
	public override string ToString()
		=> $"{this.GetType().Name} (ID: {this.Id})";

	/// <inheritdoc />
	public object Clone()
		=> this.MemberwiseClone();

	/// <summary>
	/// Serializes the <see cref="NullableSnowflakeObject"/> to a JSON string.
	/// </summary>
	/// <returns>A JSON string representation of the object.</returns>
	public virtual string ToJson()
		=> DiscordJson.SerializeObject(this);

	/// <summary>
	/// Deserializes a JSON string to a <typeparamref name="T"/> instance of <see cref="NullableSnowflakeObject"/>.
	/// </summary>
	/// <typeparam name="T">The type of the object to deserialize.</typeparam>
	/// <param name="json">The JSON string to deserialize from.</param>
	/// <returns>An instance of type <typeparamref name="T"/>.</returns>
	public virtual T FromJson<T>(string json) where T : NullableSnowflakeObject
		=> DiscordJson.DeserializeObject<T>(json, this.Discord);
}
