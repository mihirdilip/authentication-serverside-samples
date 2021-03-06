using AspNetCore.Authentication.Basic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.ServerSide
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
			services.AddSharedServices();

			services.AddSingleton<IUserCache, UserCache>();

			services.AddAuthentication(BasicDefaults.AuthenticationScheme)
				.AddBasic<BasicUserValidationService>(options => { options.Realm = "Authentication.ServerSide.Basic"; });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app)
		{
			app.UseSharedPipeline();
		}
	}
}
