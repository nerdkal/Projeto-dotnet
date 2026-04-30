using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MEUSITE
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração de serviços
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                  context.Response.ContentType = "text/html; charset=utf-8";

    var html = @"
        <html>
            <head>
                <style>
                    body {
                        background-color: #2d3436; /* Cor de fundo (cinza escuro) */
                        color: yellow;           /* Cor do texto (salmão claro) */
                        display: flex;
                        justify-content: center;
                        align-items: center;
                        height: 100vh;
                        margin: 0;
                        font-family: Arial, sans-serif;
                    }
                    h1 {
                        font-size: 4rem;          /* Texto bem grande */
                        text-shadow: 2px 2px 10px rgba(0,0,0,0.5);
                    }
                </style>
            </head>
            <body>
                <h1>Bem-vindo ao MeuSite: Projeto 2!!!</h1>
            </body>
        </html>";

    await context.Response.WriteAsync(html);
                });
            });
        }
    }
}
