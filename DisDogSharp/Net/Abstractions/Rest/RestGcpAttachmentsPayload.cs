using System.Collections.Generic;

using DisDogSharp.Entities;

using Newtonsoft.Json;

namespace DisDogSharp.Net.Abstractions.Rest;

internal sealed class RestGcpAttachmentsPayload
{
	[JsonProperty("files")]
	public List<GcpAttachment> GcpAttachments { get; set; } = [];
}
