//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================



using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using majumi.MechanicApp.Controller;
using majumi.MechanicApp.Model;
using majumi.MechanicApp.Utilities;
using Radzen;

namespace majumi.MechanicApp.BlazorServer;

public class Startup
{
	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddRazorPages();
		services.AddServerSideBlazor();
        services.AddScoped<DialogService>();
        services.AddScoped<IEventDispatcher, EmptyEventDispatcher>();
		services.AddScoped<IModel, Model.Model>();
		services.AddScoped<IController, Controller.Controller>();
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		else
		{
			app.UseExceptionHandler("/Error");
			app.UseHsts();
		}

		app.UseStaticFiles();

		/* AT
		app.UseHttpsRedirection( );
		*/
		app.UseStaticFiles();

		app.UseRouting();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapBlazorHub();
			endpoints.MapFallbackToPage("/_Host");
		});
	}
}
