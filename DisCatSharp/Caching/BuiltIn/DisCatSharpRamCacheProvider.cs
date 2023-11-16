using System;

using DisCatSharp.Entities;

namespace DisCatSharp.Caching.BuiltIn;

/// <summary>
/// Represents a ram cache provider for DisCatSharp.
/// </summary>
public sealed class DisCatSharpRamCacheProvider : IDisCatSharpCacheProvider
{
	/// <inheritdoc />
	public int TotalCacheSize { get; internal set; }

	/// <inheritdoc />
	public int GuildCacheSize
		=> this.GuildCache.Count;

	/// <summary>
	/// Gets the guild cache.
	/// </summary>
	public RingBuffer<DiscordGuild> GuildCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int ChannelCacheSize
		=> this.ChannelCache.Count;

	/// <summary>
	/// Gets the channel cache.
	/// </summary>
	public RingBuffer<DiscordChannel> ChannelCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int ThreadCacheSize
		=> this.ThreadCache.Count;

	/// <summary>
	/// Gets the thread cache.
	/// </summary>
	public RingBuffer<DiscordThreadChannel> ThreadCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int MemberCacheSize
		=> this.MemberCache.Count;

	/// <summary>
	/// Gets the member cache.
	/// </summary>
	public RingBuffer<DiscordMember> MemberCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int UserCacheSize
		=> this.UserCache.Count;

	/// <summary>
	/// Gets the user cache.
	/// </summary>
	public RingBuffer<DiscordUser> UserCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int RoleCacheSize
		=> this.RoleCache.Count;

	/// <summary>
	/// Gets the role cache.
	/// </summary>
	public RingBuffer<DiscordRole> RoleCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int EmojiCacheSize
		=> this.EmojiCache.Count;

	/// <summary>
	/// Gets the emoji cache.
	/// </summary>
	public RingBuffer<DiscordEmoji> EmojiCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int MessageCacheSize
		=> this.MessageCache.Count;

	/// <summary>
	/// Gets the message cache.
	/// </summary>
	public RingBuffer<DiscordMessage> MessageCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int PresenceCacheSize
		=> this.PresenceCache.Count;

	/// <summary>
	/// Gets the presence cache.
	/// </summary>
	public RingBuffer<DiscordPresence> PresenceCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int VoiceStateCacheSize
		=> this.VoiceStateCache.Count;

	/// <summary>
	/// Gets the voice state cache.
	/// </summary>
	public RingBuffer<DiscordVoiceState> VoiceStateCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int InviteCacheSize
		=> this.InviteCache.Count;

	/// <summary>
	/// Gets the invite cache.
	/// </summary>
	public RingBuffer<DiscordInvite> InviteCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int StageInstanceCacheSize
		=> this.StageInstanceCache.Count;

	/// <summary>
	/// Gets the stage instance cache.
	/// </summary>
	public RingBuffer<DiscordStageInstance> StageInstanceCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int StickerCacheSize
		=> this.StickerCache.Count;

	/// <summary>
	/// Gets the sticker cache.
	/// </summary>
	public RingBuffer<DiscordSticker> StickerCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc />
	public int InteractionCacheSize
		=> this.InteractionCache.Count;

	/// <summary>
	/// Gets the interaction cache.
	/// </summary>
	public RingBuffer<DiscordInteraction> InteractionCache { get; } = new(Configuration.CacheSize);

	/// <inheritdoc cref="IDisCatSharpCacheProvider.Configuration" />
	public static DiscordConfiguration Configuration { internal get; set; }

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

	/// <inheritdoc />
	public void Init(DiscordConfiguration config)
		=> Configuration = config ?? throw new ArgumentNullException(nameof(config), "The configuration cannot be null.");
}
