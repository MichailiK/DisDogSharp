using Newtonsoft.Json;

namespace DisCatSharp.Entities;

/// <summary>
/// Represents a Rich Presence application.
/// </summary>
public class DiscordMessageApplication : SnowflakeObject
{
	/// <summary>
	/// Gets the ID of this application's cover image.
	/// </summary>
	[JsonProperty("cover_image", NullValueHandling = NullValueHandling.Include)]
	public virtual string? CoverImageUrl { get; internal set; }

	/// <summary>
	/// Gets the application's description.
	/// </summary>
	[JsonProperty("description", NullValueHandling = NullValueHandling.Include)]
	public string? Description { get; internal set; }

	/// <summary>
	/// Gets the ID of the application's icon.
	/// </summary>
	[JsonProperty("icon", NullValueHandling = NullValueHandling.Include)]
	public virtual string? Icon { get; internal set; }

	/// <summary>
	/// Gets the application's name.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; internal set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="DiscordMessageApplication"/> class.
	/// </summary>
	internal DiscordMessageApplication()
	{
	}
}
