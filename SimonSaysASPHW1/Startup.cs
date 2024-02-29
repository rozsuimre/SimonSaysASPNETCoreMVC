using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SimonMondjaEgybeFuzveASPNETCore.Empty
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISimonMondjaService, SimonMondjaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                    var barmiService = context.RequestServices.GetRequiredService<ISimonMondjaService>();
          var miazelso = barmiService.Restart();
                    await context.Response.WriteAsync($"Please memorize this number: <b><span style='color:red'> {miazelso} </span></b>!  <br><br>");
                    await context.Response.WriteAsync($"If you have memorized it, put a 'guess' word in the url after 'localhost:.../' (e.g. in the form localhost:44378/guess) ! <br><br>");
                    await context.Response.WriteAsync($"<b><span style='color:red'>Please don't cheat, be sure to use 'localhost:.../guess' in the url, because the sequence of numbers will only be deleted from the url ! </span></b><br><br>");
                    await context.Response.WriteAsync($"Then delete 'guess' word from the url and enter the memorized sequence of numbers after localhost:.../! <br><br> Be careful that your browser tries to complete the entry, do not allow this, just enter the memorized sequence of numbers after localhost:.../! ");

                });
                
                bool kitorolve=false;

                endpoints.MapGet("/{xStr}", async context =>
                {
                    var found = context.Request.RouteValues.TryGetValue("xStr", out var xValue);
                    string xStr = xValue.ToString();
                   
                    if (xStr == "guess") { kitorolve = false; } else { kitorolve = true; }
                
                    if (xStr != "guess" && kitorolve)
                    {                                                
                        int xInt = int.Parse(xStr); 

                        

                        if (found)
                        {
                            //Az AddScope-al csak 1 szervizt regisztráltunk be az IMatchService a mi barátunk és ezt a MatchService valósítja meg
                    var keresettService = context.RequestServices.GetRequiredService<ISimonMondjaService>();

                            string eredmeny = new(keresettService.Tipp(xStr));
                            List<int> computerLista = new(keresettService.Lekerdez());

                     //result = new (keresettService.Egyezes(xStr).Item1, keresettService.Egyezes(xStr).Item2); //a játékostól jön az xStr oké,
                                                                        //A HTML-be kiküldött context kicsi formázása:
                            context.Response.ContentType = "text/html; charset=utf-8";
                            if (eredmeny != "Vége")
                            {
                                await context.Response.WriteAsync($"Your guess was correct!<br><br> The next number you need to remember: <b><span style='color:red'>{computerLista.Last().ToString()}</span></b> ! <br><br>");
                                await context.Response.WriteAsync($"If you have memorized it, put a 'guess' word in the url after 'localhost:.../' (e.g. in the form localhost:44378/guess) ! <br><br>");
                                await context.Response.WriteAsync($"<b><span style='color:red'>Please don't cheat, be sure to use 'localhost:.../guess' in the url, because the sequence of numbers will only be deleted from the url ! </span></b><br><br>");
                                await context.Response.WriteAsync($"Then delete 'guess' word from the url and enter the memorized sequence of numbers after localhost:.../! <br><br> Be careful that your browser tries to complete the entry, do not allow this, just enter the memorized sequence of numbers after localhost:.../! ");

                            }
                            else
                            {
                                await context.Response.WriteAsync($"Oh no ! The correct answer was for the last guess: {computerLista.Last().ToString()}. <br><br>");
                                await context.Response.WriteAsync("Game over, you messed up the sequence of numbers !<br><br> You Lost !! <br><br> To start again, delete everything in the url up to the slash like: 'localhost:.../' and press Enter !");
                                keresettService.Restart();
                            }
                        }
                        else//ha nem találtuk meg az értelmes értéket
                        {
                            context.Response.ContentType = "text/html; charset=utf-8";
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;


                        }


                    }
                }
                );
            });
        }
    }
}
