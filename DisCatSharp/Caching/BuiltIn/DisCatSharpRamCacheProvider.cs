using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

using DisCatSharp.Entities;

namespace DisCatSharp.Caching.BuiltIn;

/// <summary>
/// Represents a ram cache provider for DisCatSharp.
/// </summary>
public sealed class DisCatSharpRamCacheProvider : IDisCatSharpCacheProvider
{
	/// <inheritdoc />
	public int CurrentCacheSize
		=> this.GuildCacheSize + this.ChannelCacheSize + this.ThreadCacheSize + this.MemberCacheSize + this.UserCacheSize + this.RoleCacheSize + this.EmojiCacheSize + this.MessageCacheSize + this.PresenceCacheSize + this.VoiceStateCacheSize + this.InviteCacheSize + this.StageInstanceCacheSize + this.StickerCacheSize + this.InteractionCacheSize + this.ScheduledEventCacheSize;

	/// <inheritdoc />
	public int TotalCacheSize
		=> Configuration.CacheSize * Enum.GetValues<CacheLocation>().Length;

	/// <inheritdoc />
	public int GuildCacheSize
		=> this.GuildCache.Count;

	/// <summary>
	/// Gets the guild cache.
	/// </summary>
	public ConcurrentDictionary<ulong, DiscordGuild> GuildCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int ChannelCacheSize
		=> this.ChannelCache.Count;

	/// <summary>
	/// Gets the channel cache.
	/// </summary>
	public ConcurrentDictionary<ulong?, ConcurrentDictionary<ulong, DiscordChannel>> ChannelCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int ThreadCacheSize
		=> this.ThreadCache.Count;

	/// <summary>
	/// Gets the thread cache.
	/// </summary>
	public  ConcurrentDictionary<ulong, ConcurrentDictionary<ulong, DiscordThreadChannel>> ThreadCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int MemberCacheSize
		=> this.MemberCache.Count;

	/// <summary>
	/// Gets the member cache.
	/// </summary>
	public ConcurrentDictionary<ulong, ConcurrentDictionary<ulong, DiscordMember>> MemberCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int UserCacheSize
		=> this.UserCache.Count;

	/// <summary>
	/// Gets the user cache.
	/// </summary>
	public ConcurrentDictionary<ulong, DiscordUser> UserCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int RoleCacheSize
		=> this.RoleCache.Count;

	/// <summary>
	/// Gets the role cache.
	/// </summary>
	public ConcurrentDictionary<ulong, ConcurrentDictionary<ulong, DiscordRole>> RoleCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int EmojiCacheSize
		=> this.EmojiCache.Count;

	/// <summary>
	/// Gets the emoji cache.
	/// </summary>
	public ConcurrentDictionary<ulong, ConcurrentDictionary<ulong, DiscordGuildEmoji>> EmojiCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int MessageCacheSize
		=> this.MessageCache.Count;

	/// <summary>
	/// Gets the message cache.
	/// </summary>
	public ConcurrentDictionary<ulong, DiscordMessage> MessageCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int PresenceCacheSize
		=> this.PresenceCache.Count;

	/// <summary>
	/// Gets the presence cache.
	/// </summary>
	public ConcurrentDictionary<ulong, ConcurrentDictionary<ulong, DiscordPresence>> PresenceCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int ScheduledEventCacheSize
		=> this.ScheduledEventCache.Count;

	/// <summary>
	/// Gets the scheduled event cache.
	/// </summary>
	public ConcurrentDictionary<ulong, ConcurrentDictionary<ulong, DiscordScheduledEvent>> ScheduledEventCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int VoiceStateCacheSize
		=> this.VoiceStateCache.Count;

	/// <summary>
	/// Gets the voice state cache.
	/// </summary>
	public ConcurrentDictionary<ulong, ConcurrentDictionary<ulong, DiscordVoiceState>> VoiceStateCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int InviteCacheSize
		=> this.InviteCache.Count;

	/// <summary>
	/// Gets the invite cache.
	/// </summary>
	public ConcurrentDictionary<ulong, ConcurrentDictionary<ulong, DiscordInvite>> InviteCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int StageInstanceCacheSize
		=> this.StageInstanceCache.Count;

	/// <summary>
	/// Gets the stage instance cache.
	/// </summary>
	public ConcurrentDictionary<ulong, ConcurrentDictionary<ulong, DiscordStageInstance>> StageInstanceCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int StickerCacheSize
		=> this.StickerCache.Count;

	/// <summary>
	/// Gets the sticker cache.
	/// </summary>
	public ConcurrentDictionary<ulong, ConcurrentDictionary<ulong, DiscordSticker>> StickerCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc />
	public int InteractionCacheSize
		=> this.InteractionCache.Count;

	/// <summary>
	/// Gets the interaction cache.
	/// </summary>
	public ConcurrentDictionary<ulong?, ConcurrentDictionary<ulong, DiscordInteraction>> InteractionCache { get; } = new(Configuration.CacheSize, Configuration.CacheSize);

	/// <inheritdoc cref="IDisCatSharpCacheProvider.Configuration" />
	public static DiscordConfiguration Configuration { internal get; set; }

	/// <inheritdoc />
	public T Add<T>(CacheLocation location, T obj)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public T? Get<T>(CacheLocation location, ulong id)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public List<T> GetAll<T>(CacheLocation location) where T : ObservableApiObject
		=> location switch
		{
			CacheLocation.Guilds => this.GuildCache.Values.OfType<T>().ToList(),
			CacheLocation.Users => this.UserCache.Values.OfType<T>().ToList(),
			CacheLocation.Messages => this.MessageCache.Values.OfType<T>().ToList(),
			CacheLocation.Channels => this.ChannelCache.Where(x => x.Key is null).ToDictionary(x => x.Value.Keys, x => x.Value.Values).Values.OfType<T>().ToList(),
			CacheLocation.Threads => throw new NotSupportedException("Filtering is needed for this type of cache."),
			CacheLocation.Members => throw new NotSupportedException("Filtering is needed for this type of cache."),
			CacheLocation.Roles => throw new NotSupportedException("Filtering is needed for this type of cache."),
			CacheLocation.Emojis => throw new NotSupportedException("Filtering is needed for this type of cache."),
			CacheLocation.Presences => throw new NotSupportedException("Filtering is needed for this type of cache."),
			CacheLocation.VoiceStates => throw new NotSupportedException("Filtering is needed for this type of cache."),
			CacheLocation.Invites => throw new NotSupportedException("Filtering is needed for this type of cache."),
			CacheLocation.StageInstances => throw new NotSupportedException("Filtering is needed for this type of cache."),
			CacheLocation.Stickers => throw new NotSupportedException("Filtering is needed for this type of cache."),
			CacheLocation.Interactions => throw new NotSupportedException("Filtering is needed for this type of cache."),
			CacheLocation.ScheduledEvents => throw new NotSupportedException("Filtering is needed for this type of cache."),
			_ => throw new ArgumentOutOfRangeException(nameof(location), "Unknown cache location.")
		};

	/// <inheritdoc />
	public List<T> GetAllFiltered<T>(CacheLocation location, ulong guildId) where T : ObservableApiObject
		=> location switch
		{
			CacheLocation.Channels => this.ChannelCache.First(x => x.Key is not null && x.Key == guildId).Value.OfType<T>().ToList(),
			CacheLocation.Threads => this.ThreadCache.First(x => x.Key == guildId).Value.Values.OfType<T>().ToList(),
			CacheLocation.Members => this.MemberCache.First(x => x.Key == guildId).Value.Values.OfType<T>().ToList(),
			CacheLocation.Roles => this.RoleCache.First(x => x.Key == guildId).Value.Values.OfType<T>().ToList(),
			CacheLocation.Emojis => this.EmojiCache.First(x => x.Key == guildId).Value.Values.OfType<T>().ToList(),
			CacheLocation.Messages => this.MessageCache.Values.Where(x => x.GuildId is not null && x.GuildId == guildId).OfType<T>().ToList(),
			CacheLocation.Presences => this.PresenceCache.First(x => x.Key == guildId).Value.Values.OfType<T>().ToList(),
			CacheLocation.VoiceStates => this.VoiceStateCache.First(x => x.Key == guildId).Value.Values.OfType<T>().ToList(),
			CacheLocation.StageInstances => this.StageInstanceCache.First(x => x.Key == guildId).Value.Values.OfType<T>().ToList(),
			CacheLocation.Stickers => this.StickerCache.First(x => x.Key == guildId).Value.Values.OfType<T>().ToList(),
			CacheLocation.Interactions => this.InteractionCache.First(x => x.Key is not null && x.Key == guildId).Value.Values.OfType<T>().ToList(),
			CacheLocation.Invites => this.InviteCache.First(x => x.Key == guildId).Value.Values.OfType<T>().ToList(),
			CacheLocation.ScheduledEvents => this.ScheduledEventCache.First(x => x.Key == guildId).Value.Values.OfType<T>().ToList(),
			CacheLocation.Guilds => throw new NotSupportedException("Filtering not supported for this type of cache."),
			CacheLocation.Users => throw new NotSupportedException("Filtering not supported for this type of cache."),
			_ => throw new ArgumentOutOfRangeException(nameof(location), "Unknown cache location.")
		};

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
	public bool TryAddOrUpdate<T>(CacheLocation location, ulong id, T obj, out T updatedObject)
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

	/// <inheritdoc />
	public bool HasKey(CacheLocation location, ulong id)
		=> location switch
		{
			CacheLocation.Guilds => this.GuildCache.ContainsKey(id),
			CacheLocation.Users => this.UserCache.ContainsKey(id),
			CacheLocation.Channels => this.ChannelCache.ContainsKey(id),
			CacheLocation.Threads => this.ThreadCache.ContainsKey(id),
			CacheLocation.Members => this.MemberCache.ContainsKey(id),
			CacheLocation.Roles => this.RoleCache.ContainsKey(id),
			CacheLocation.Emojis => this.EmojiCache.ContainsKey(id),
			CacheLocation.Messages => this.MessageCache.ContainsKey(id),
			CacheLocation.Presences => this.PresenceCache.ContainsKey(id),
			CacheLocation.VoiceStates => this.VoiceStateCache.ContainsKey(id),
			CacheLocation.Invites => this.InviteCache.ContainsKey(id),
			CacheLocation.StageInstances => this.StageInstanceCache.ContainsKey(id),
			CacheLocation.Stickers => this.StickerCache.ContainsKey(id),
			CacheLocation.Interactions => this.InteractionCache.ContainsKey(id),
			CacheLocation.ScheduledEvents => this.ScheduledEventCache.ContainsKey(id),
			_ => throw new ArgumentOutOfRangeException(nameof(location), "Unknown cache location.")
		};
}
