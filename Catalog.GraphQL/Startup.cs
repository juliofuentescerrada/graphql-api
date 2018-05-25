﻿using System.Data;
using System.Data.SqlClient;
using Catalog.Application;
using Catalog.Application.Requests;
using Catalog.Infrastructure.DataAccess;
using GraphQL;
using GraphQL.Types;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.GraphQL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDbConnection>(x => new SqlConnection(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<CatalogDbContext>(o => o.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddMediatR(typeof(GraphQLRequest).Assembly, typeof(CatalogDbContext).Assembly);
            services.AddMvc();

            services.Scan(s => s.FromAssemblyOf<CatalogQuery>().AddClasses(c=>c.AssignableTo(typeof(ObjectGraphType))).AsSelf().WithScopedLifetime());
            services.Scan(s => s.FromAssemblyOf<CatalogQuery>().AddClasses(c => c.AssignableTo(typeof(ObjectGraphType<>))).AsSelf().WithScopedLifetime());
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<ISchema>(sp => new CatalogSchema(type => sp.GetService(type) as GraphType));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
