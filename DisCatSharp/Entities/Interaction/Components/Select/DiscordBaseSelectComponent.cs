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

using System;
using System.Collections.Generic;
using System.Linq;

using DisCatSharp.Enums;

using Newtonsoft.Json;

namespace DisCatSharp.Entities;

/// <summary>
/// A select menu with multiple options to choose from.
/// </summary>
public class DiscordBaseSelectComponent : DiscordComponent
{
	/// <summary>
	/// The text to show when no option is selected.
	/// </summary>
	[JsonProperty("placeholder", NullValueHandling = NullValueHandling.Ignore)]
	public string Placeholder { get; internal set; }

	/// <summary>
	/// The minimum amount of options that can be selected. Must be less than or equal to <see cref="MaximumSelectedValues"/>. Defaults to one.
	/// </summary>
	[JsonProperty("min_values", NullValueHandling = NullValueHandling.Ignore)]
	public int? MinimumSelectedValues { get; internal set; } = 1;

	/// <summary>
	/// The maximum amount of options that can be selected. Must be greater than or equal to zero or <see cref="MinimumSelectedValues"/>. Defaults to one.
	/// </summary>
	[JsonProperty("max_values", NullValueHandling = NullValueHandling.Ignore)]
	public int? MaximumSelectedValues { get; internal set; } = 1;

	/// <summary>
	/// Whether this select can be used.
	/// </summary>
	[JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
	public bool Disabled { get; internal set; }

	/// <summary>
	/// Label of component, if used in modal.
	/// </summary>
	[JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
	public string Label { get; internal set; } = null;

	/// <summary>
	/// The default values of this select menu.
	/// </summary>
	[JsonProperty("default_values", NullValueHandling = NullValueHandling.Ignore)]
	public List<DiscordSelectDefaultValue>? DefaultValues { get; internal set; } = null;

	/// <summary>
	/// Constructs a new <see cref="DiscordBaseSelectComponent"/>.
	/// </summary>
	/// <param name="type">The type of select.</param>
	/// <param name="placeholder">Text to show if no option is selected.</param>
	/// <param name="customId">The Id to assign to the select component.</param>
	/// <param name="minOptions">Minimum count of selectable options.</param>
	/// <param name="maxOptions">Maximum count of selectable options.</param>
	/// <param name="disabled">Whether this select component should be initialized as being disabled. User sees a greyed out select component that cannot be interacted with.</param>
	/// <param name="defaultValues">The default values of this select menu. Not valid for <see cref="ComponentType.StringSelect"/>.</param>
	internal DiscordBaseSelectComponent(ComponentType type, string placeholder, string customId = null, int minOptions = 1, int maxOptions = 1, bool disabled = false, IEnumerable<DiscordSelectDefaultValue>? defaultValues = null)
	{
		this.Type = type;
		this.CustomId = customId ?? Guid.NewGuid().ToString(); ;
		this.Disabled = disabled;
		this.Placeholder = placeholder;
		this.MinimumSelectedValues = minOptions;
		this.MaximumSelectedValues = maxOptions;
		if (defaultValues is not null)
		{
			if (defaultValues.Count() > maxOptions)
				throw new OverflowException("The amount of default values cannot exceed the maximum amount of selectable options.");
			if (type == ComponentType.MentionableSelect && defaultValues.Any(x => x.Type == "channel"))
				throw new ArgumentException("The default values for a mentionable select must be of type user or role.", nameof(defaultValues));
			if (type == ComponentType.ChannelSelect && defaultValues.Any(x => x.Type == "channel"))
				throw new ArgumentException("The default values for a channel select menus must be of type channel.", nameof(defaultValues));
			if (type == ComponentType.UserSelect && defaultValues.Any(x => x.Type != "user"))
				throw new ArgumentException("The default values for a user select menus must be of type user.", nameof(defaultValues));
			if (type == ComponentType.RoleSelect && defaultValues.Any(x => x.Type != "role"))
				throw new ArgumentException("The default values for a role select menus must be of type role.", nameof(defaultValues));
		}
		this.DefaultValues = defaultValues?.ToList();
	}

	/// <summary>
	/// Constructs a new <see cref="DiscordBaseSelectComponent"/> for modals.
	/// </summary>
	/// <param name="type">The type of select.</param>
	/// <param name="label">Maximum count of selectable options.</param>
	/// <param name="placeholder">Text to show if no option is selected.</param>
	/// <param name="customId">The Id to assign to the select component.</param>
	/// <param name="minOptions">Minimum count of selectable options.</param>
	/// <param name="maxOptions">Maximum count of selectable options.</param>
	/// <param name="disabled">Whether this select component should be initialized as being disabled. User sees a greyed out select component that cannot be interacted with.</param>
	/// <param name="defaultValues">The default values of this select menu. Not valid for <see cref="ComponentType.StringSelect"/>.</param>
	internal DiscordBaseSelectComponent(ComponentType type, string label, string placeholder, string customId = null, int minOptions = 1, int maxOptions = 1, bool disabled = false, IEnumerable<DiscordSelectDefaultValue>? defaultValues = null)
	{
		this.Type = type;
		this.Label = label;
		this.CustomId = customId ?? Guid.NewGuid().ToString(); ;
		this.Disabled = disabled;
		this.Placeholder = placeholder;
		this.MinimumSelectedValues = minOptions;
		this.MaximumSelectedValues = maxOptions;
		if (defaultValues is not null)
		{
			if (defaultValues.Count() > maxOptions)
				throw new OverflowException("The amount of default values cannot exceed the maximum amount of selectable options.");
			if (type == ComponentType.MentionableSelect && defaultValues.Any(x => x.Type == "channel"))
				throw new ArgumentException("The default values for a mentionable select must be of type user or role.", nameof(defaultValues));
			if (type == ComponentType.ChannelSelect && defaultValues.Any(x => x.Type == "channel"))
				throw new ArgumentException("The default values for a channel select menus must be of type channel.", nameof(defaultValues));
			if (type == ComponentType.UserSelect && defaultValues.Any(x => x.Type != "user"))
				throw new ArgumentException("The default values for a user select menus must be of type user.", nameof(defaultValues));
			if (type == ComponentType.RoleSelect && defaultValues.Any(x => x.Type != "role"))
				throw new ArgumentException("The default values for a role select menus must be of type role.", nameof(defaultValues));
		}
		this.DefaultValues = defaultValues?.ToList();
	}

	internal DiscordBaseSelectComponent()
	{

	}
}
