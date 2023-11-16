using System;

namespace DisCatSharp.Caching.BuiltIn;

/// <summary>
/// Represents a ram cache provider for DisCatSharp.
/// </summary>
public sealed class DisCatSharpRamCacheProvider : IDisCatSharpCacheProvider
{
	/// <inheritdoc />
	public int TotalCacheSize { get; internal set; }

	/// <inheritdoc />
	public int GuildCacheSize { get; internal set; }

	/// <inheritdoc />
	public int ChannelCacheSize { get; internal set; }

	/// <inheritdoc />
	public int ThreadCacheSize { get; internal set; }

	/// <inheritdoc />
	public int MemberCacheSize { get; internal set; }

	/// <inheritdoc />
	public int UserCacheSize { get; internal set; }

	/// <inheritdoc />
	public int RoleCacheSize { get; internal set; }

	/// <inheritdoc />
	public int EmojiCacheSize { get; internal set; }

	/// <inheritdoc />
	public int MessageCacheSize { get; internal set; }

	/// <inheritdoc />
	public int PresenceCacheSize { get; internal set; }

	/// <inheritdoc />
	public int VoiceStateCacheSize { get; internal set; }

	/// <inheritdoc />
	public int InviteCacheSize { get; internal set; }

	/// <inheritdoc />
	public int StageInstanceCacheSize { get; internal set; }

	/// <inheritdoc />
	public int StickerCacheSize { get; internal set; }

	/// <inheritdoc />
	public int InteractionCacheSize { get; internal set; }

	/// <inheritdoc />
	public int ComponentInteractionCacheSize { get; internal set; }

	/// <inheritdoc />
	public int UserPresenceCacheSize { get; internal set; }

	/// <inheritdoc />
	public T Add<T>(CacheLocation location, T obj)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public T? Get<T>(CacheLocation location, ulong id)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public void Remove<T>(CacheLocation location, T obj)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public void Remove(CacheLocation location, ulong id)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public void RemoveAll<T>(CacheLocation location, Func<T, bool> predicate)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public void RemoveAll<T>(CacheLocation location)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public bool TryGet<T>(CacheLocation location, ulong id, out T obj)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public bool TryAddOrUpdate<T>(CacheLocation location, ulong id, T obj)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public bool TryRemove<T>(CacheLocation location, T obj)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public bool TryRemove(CacheLocation location, ulong id)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public int GetCacheSize(CacheLocation? location)
		=> throw new NotImplementedException();
}
