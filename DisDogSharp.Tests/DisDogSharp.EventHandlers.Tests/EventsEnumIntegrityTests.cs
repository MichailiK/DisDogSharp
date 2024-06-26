using System.Linq;

using DisDogSharp.Enums;

using Xunit;

namespace DisDogSharp.EventHandlers.Tests;

public class EventsEnumIntegrityTests
{
	[Fact]
	private void TestEnumToEvent()
	{
		foreach (var value in typeof(DiscordEvent).GetEnumValues())
			Assert.NotNull(typeof(DiscordClient).GetEvent(value.ToString()!));
	}

	[Fact]
	private void TestEventToEnum()
	{
		var enumNames = typeof(DiscordEvent).GetEnumNames().ToHashSet();
		foreach (var evtn in typeof(DiscordClient).GetEvents())
			Assert.Contains(evtn.Name, enumNames);
	}
}
