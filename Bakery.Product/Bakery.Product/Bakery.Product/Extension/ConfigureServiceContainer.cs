using Bakery.Commons.Bakery.Commons.Domain.Port;
using Bakery.Commons.Bakery.Commons.Domain.Service;
using Bakery.Product.DomainApi.Services;
using Bakery.Product.Persistence.Adapter.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace Bakery.Product.Extension
{
    public static class ConfigureServiceContainer
    {
        [ExcludeFromCodeCoverage]
        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection, AppSettings appSettings)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "OpenAPISpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = appSettings.ApplicationDetail.ApplicationName,
                        Version = "1",
                        Description = appSettings.ApplicationDetail.Description,
                    });
                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                });
                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });
        }

        [ExcludeFromCodeCoverage]
        public static void AddApiVersion(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }

        [ExcludeFromCodeCoverage]
        public static void AddHealthCheck(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHealthChecks()
               .AddDbContextCheck<ApplicationDbContext>(name: "Application DB Context", failureStatus: HealthStatus.Degraded)
               .AddUrlGroup(new Uri("https://amitpnk.github.io/"), name: "My personal website", failureStatus: HealthStatus.Degraded);

            serviceCollection.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("Basic Health Check", $"/healthz");
            });
        }

        [ExcludeFromCodeCoverage]
        public static void AddCustomServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IStorageAccountHelper), typeof(StorageAccountHelper));
        }
    }
}
