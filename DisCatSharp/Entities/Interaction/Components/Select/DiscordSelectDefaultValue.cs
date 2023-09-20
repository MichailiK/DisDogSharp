// This file is part of the DisCatSharp project, based off DSharpPlus.
//
// Copyright (c) 2021-2023 AITSYS
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using DisCatSharp.Enums;

using Newtonsoft.Json;

namespace DisCatSharp.Entities;

/// <summary>
/// A select default value for use with <see cref="ComponentType.UserSelect"/>, <see cref="ComponentType.RoleSelect"/>, <see cref="ComponentType.ChannelSelect"/> or <see cref="ComponentType.MentionableSelect"/>.
/// </summary>
public sealed class DiscordSelectDefaultValue
{
	/// <summary>
	/// The id of a user, role, or channel.
	/// </summary>
	[JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
	public ulong Id { get; internal set; }

	/// <summary>
	/// The type of value that <see cref="Id"/> represents.
	/// </summary>
	[JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
	public string Type { get; internal set; }

	/// <summary>
	/// Constructs a new <see cref="DiscordSelectDefaultValue"/> for an <paramref name="id"/> with corrosponding <paramref name="type"/>.
	/// </summary>
	/// <param name="id">The id to set.</param>
	/// <param name="type">The type of the <paramref name="id"/>. Can be <c>user</c>, <c>role</c> or <c>channel</c></param>
	public DiscordSelectDefaultValue(ulong id, string type)
	{
		this.Id = id;
		this.Type = type;
	}

	/// <summary>
	/// Constructs a new <see cref="DiscordSelectDefaultValue"/> for a role.
	/// </summary>
	/// <param name="role">The role to set.</param>
	public DiscordSelectDefaultValue(DiscordRole role)
	{
		this.Id = role.Id;
		this.Type = "role";
	}

	/// <summary>
	/// Constructs a new <see cref="DiscordSelectDefaultValue"/> for a user.
	/// </summary>
	/// <param name="user">The user to set.</param>
	public DiscordSelectDefaultValue(DiscordUser user)
	{
		this.Id = user.Id;
		this.Type = "user";
	}

	/// <summary>
	/// Constructs a new <see cref="DiscordSelectDefaultValue"/> for a channel.
	/// </summary>
	/// <param name="channel">The channel to set.</param>
	public DiscordSelectDefaultValue(DiscordChannel channel)
	{
		this.Id = channel.Id;
		this.Type = "channel";
	}
}
