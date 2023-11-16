using System;

namespace DisCatSharp.Caching;

/// <summary>
/// Represents a cache for DisCatSharp.
/// </summary>
public interface IDisCatSharpCache
{
	/// <summary>
	/// Gets the current size of the cache.
	/// </summary>
	int TotalCacheSize { get; }

	/// <summary>
	/// Gets the current size of the guild cache.
	/// </summary>
	int GuildCacheSize { get; }

	/// <summary>
	/// Gets the current size of the channel cache.
	/// </summary>
	int ChannelCacheSize { get; }

	/// <summary>
	/// Gets the current size of the thread cache.
	/// </summary>
	int ThreadCacheSize { get; }

	/// <summary>
	/// Gets the current size of the member cache.
	/// </summary>
	int MemberCacheSize { get; }

	/// <summary>
	/// Gets the current size of the user cache.
	/// </summary>
	int UserCacheSize { get; }

	/// <summary>
	/// Gets the current size of the role cache.
	/// </summary>
	int RoleCacheSize { get; }

	/// <summary>
	/// Gets the current size of the emoji cache.
	/// </summary>
	int EmojiCacheSize { get; }

	/// <summary>
	/// Gets the current size of the message cache.
	/// </summary>
	int MessageCacheSize { get; }

	/// <summary>
	/// Gets the current size of the presence cache.
	/// </summary>
	int PresenceCacheSize { get; }

	/// <summary>
	/// Gets the current size of the voice state cache.
	/// </summary>
	int VoiceStateCacheSize { get; }

	/// <summary>
	/// Gets the current size of the invite cache.
	/// </summary>
	int InviteCacheSize { get; }

	/// <summary>
	/// Gets the current size of the stage instance cache.
	/// </summary>
	int StageInstanceCacheSize { get; }

	/// <summary>
	/// Gets the current size of the sticker cache.
	/// </summary>
	int StickerCacheSize { get; }

	/// <summary>
	/// Gets the current size of the interaction cache.
	/// </summary>
	int InteractionCacheSize { get; }

	/// <summary>
	/// Gets the current size of the component interaction cache.
	/// </summary>
	int ComponentInteractionCacheSize { get; }

	/// <summary>
	/// Gets the current size of the user presence cache.
	/// </summary>
	int UserPresenceCacheSize { get; }

	/// <summary>
	/// Gets whether this cache is an official cache extension.
	/// </summary>
	bool OfficialCacheExtension { get; internal set; }

	/// <summary>
	/// Adds an object to the cache.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	/// <param name="location">The target cache.</param>
	/// <param name="obj">The object to add.</param>
	/// <returns>The added object.</returns>
	T Add<T>(CacheLocation location, T obj);

	/// <summary>
	/// Gets an object from the cache.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	/// <param name="location">The target cache.</param>
	/// <param name="id">The objects id.</param>
	/// <returns>The found object.</returns>
	T? Get<T>(CacheLocation location, ulong id);

	/// <summary>
	/// Removes an object from the cache.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	/// <param name="location">The target cache.</param>
	/// <param name="obj">The object to remove.</param>
	void Remove<T>(CacheLocation location, T obj);

	/// <summary>
	/// Removes an object from the cache.
	/// </summary>
	/// <param name="location">The target cache.</param>
	/// <param name="id">The objects id.</param>
	void Remove(CacheLocation location, ulong id);

	/// <summary>
	/// Removes all objects from the cache matching the predicate.
	/// </summary>
	/// <typeparam name="T">The type of the to be removed object.</typeparam>
	/// <param name="location">The target cache.</param>
	/// <param name="predicate">The predicate.</param>
	void RemoveAll<T>(CacheLocation location, Func<T, bool> predicate);

	/// <summary>
	/// Removes all objects from the cache.
	/// </summary>
	/// <typeparam name="T">The type of the to be removed objects.</typeparam>
	/// <param name="location">The target cache.</param>
	void RemoveAll<T>(CacheLocation location);

	/// <summary>
	/// Tries to get an object from the cache.
	/// </summary>
	/// <typeparam name="T">The target object type.</typeparam>
	/// <param name="location">The target cache.</param>
	/// <param name="id">The objects id.</param>
	/// <param name="obj">The found object, if any.</param>
	/// <returns>Whether an object was found.</returns>
	bool TryGet<T>(CacheLocation location, ulong id, out T obj);

	/// <summary>
	/// Try to add or update an object in the cache.
	/// </summary>
	/// <typeparam name="T">The target object type.</typeparam>
	/// <param name="location">The target cache.</param>
	/// <param name="id">The objects id.</param>
	/// <param name="obj">The object to add or update.</param>
	/// <returns>Whether an object was found and added or updated.</returns>
	bool TryAddOrUpdate<T>(CacheLocation location, ulong id, T obj);

	/// <summary>
	/// Tries to remove an object from the cache.
	/// </summary>
	/// <typeparam name="T">The target object type.</typeparam>
	/// <param name="location">The target cache.</param>
	/// <param name="obj">The object to remove.</param>
	/// <returns>Whether the object was successfully removed.</returns>
	bool TryRemove<T>(CacheLocation location, T obj);

	/// <summary>
	/// Tries to remove an object from the cache.
	/// </summary>
	/// <typeparam name="T">The target object type.</typeparam>
	/// <param name="location">The target cache.</param>
	/// <param name="id">The objects id.</param>
	/// <returns>Whether the object was successfully removed.</returns>
	bool TryRemove(CacheLocation location, ulong id);

	/// <summary>
	/// Gets the current size of the cache.
	/// </summary>
	/// <param name="location">The target cache. Will return the total size if <see langword="null"/>.</param>
	/// <returns>The cache size.</returns>
	int GetCacheSize(CacheLocation? location);
}
