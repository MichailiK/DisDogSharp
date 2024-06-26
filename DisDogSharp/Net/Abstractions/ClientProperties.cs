using System.Reflection;
using System.Runtime.InteropServices;

using DisDogSharp.Entities;

using Newtonsoft.Json;

namespace DisDogSharp.Net.Abstractions;

/// <summary>
/// Represents data for identify payload's client properties.
/// </summary>
internal sealed class ClientProperties : ObservableApiObject
{
	/// <summary>
	/// Gets the client's operating system.
	/// </summary>
	[JsonProperty("os")]
	public string OperatingSystem
	{
		get
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				return "windows";
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				return "linux";
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
				return "osx";

			var plat = RuntimeInformation.OSDescription.ToLowerInvariant();
			if (plat.Contains("freebsd"))
				return "freebsd";
			else if (plat.Contains("openbsd"))
				return "openbsd";
			else if (plat.Contains("netbsd"))
				return "netbsd";
			else if (plat.Contains("dragonfly"))
				return "dragonflybsd";
			else if (plat.Contains("miros bsd") || plat.Contains("mirbsd"))
				return "miros bsd";
			else if (plat.Contains("desktopbsd"))
				return "desktopbsd";
			else
				return plat.Contains("darwin")
					? "osx"
					: plat.Contains("unix")
						? "unix"
						: "toaster (unknown)";
		}
	}

	/// <summary>
	/// Gets the client's browser.
	/// </summary>
	[JsonProperty("browser")]
	public string Browser
	{
		get
		{
			if (this.Discord.Configuration.MobileStatus)
				return "Discord Android";

			else
			{
				var a = typeof(DiscordClient).GetTypeInfo().Assembly;
				var an = a.GetName();
				return $"DisDogSharp {an.Version.ToString(4)}";
			}
		}
	}

	/// <summary>
	/// Gets the client's device.
	/// </summary>
	[JsonProperty("device")]
	public string Device
		=> this.Browser;

	/// <summary>
	/// Gets the client's referrer.
	/// </summary>
	[JsonProperty("referrer")]
	public string Referrer
		=> "";

	/// <summary>
	/// Gets the client's referring domain.
	/// </summary>
	[JsonProperty("referring_domain")]
	public string ReferringDomain
		=> "";
}
