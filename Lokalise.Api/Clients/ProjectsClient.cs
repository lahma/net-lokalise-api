﻿using Lokalise.Api.Clients.Requests;
using Lokalise.Api.Extensions;
using Lokalise.Api.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lokalise.Api.Clients
{
    public class ProjectsClient : BaseClient, IProjectsClient
    {
        internal ProjectsClient(
            HttpClient httpClient,
            JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        {
        }

        /// <inheritdoc/>
        public Task<Project> CreateAsync(string name, Action<CreateProjectOptions> options = null)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required to call CreateAsync");

            var cfg = new CreateProjectOptions();
            options?.Invoke(cfg);

            return PostAsync<CreateProjectRequest, Project>($"projects", new CreateProjectRequest(name, cfg));
        }

        /// <inheritdoc/>
        public Task<DeletedProject> DeleteAsync(string projectId)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project Identifier is required to call CreateAsync");

            return DeleteAsync($"projects/{projectId}");
        }

        /// <inheritdoc/>
        public Task<ProjectList> ListAsync(Action<ListProjectsOptions> options = null)
        {
            var cfg = new ListProjectsOptions();
            options?.Invoke(cfg);

            return GetListAsync<ProjectList>($"projects{cfg.ToQueryString()}");
        }

        /// <inheritdoc/>
        public Task<Project> RetrieveAsync(string projectId)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project Identifier is required to call RetrieveAsync");

            return GetAsync<Project>($"projects/{projectId}");
        }

        /// <inheritdoc/>
        public Task<EmptiedProject> EmptyAsync(string projectId, string branch = null)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project Identifier is required to call EmptyAsync");

            return PutAsync<EmptiedProject>($"projects/{projectId.IncludeBranchName(branch)}/empty");
        }

        /// <inheritdoc/>
        public Task<Project> UpdateAsync(string projectId, string name, Action<UpdateProjectOptions> options = null)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project Identifier is required to call UpdateAsync");

            if (name is null)
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required to call UpdateAsync");

            var cfg = new UpdateProjectOptions();
            options?.Invoke(cfg);

            return PutAsync<UpdateProjectRequest, Project>($"projects/{projectId}", new UpdateProjectRequest(name, cfg));
        }
    }
}
