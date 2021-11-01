﻿using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class UploadedFile : LocationResult
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("process")]
        public QueuedProcess Process { get; set; }
    }
}