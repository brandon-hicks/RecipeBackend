using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RecipeBackend.Repositories;
using RecipeBackend.services;

namespace RecipeBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            var mongoDatabase =
                new MongoClient(
                        "mongodb://brandon:bpassword@testcluster-shard-00-00-k7nkp.mongodb.net:27017,testcluster-shard-00-01-k7nkp.mongodb.net:27017,testcluster-shard-00-02-k7nkp.mongodb.net:27017/test?ssl=true&replicaSet=testCluster-shard-0&authSource=admin&retryWrites=true&w=majority")
                    .GetDatabase("Recipes");
            
            services.AddSingleton(mongoDatabase);
            services.AddSingleton<IRecipeRepository, RecipeRepository>();
            services.AddSingleton<IRecipeServices, RecipeServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}