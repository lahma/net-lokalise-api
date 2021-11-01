﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class ProjectList
    {
        [JsonPropertyName("projects")]
        public IEnumerable<Project> Projects { get; set; }
    }
}
