using Microsoft.AspNetCore.HttpOverrides;
using PaymentSolution.API.Filters;
using PaymentSolution.API.MIddlewares;
using PaymentSolution.Application.IoC;
using PaymentSolution.GerenciaNet;
using PaymentSolution.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

builder.Services.AddPaymentSolutionInfrastructure(builder.Configuration);
builder.Services.AddPaymentSolutionServices();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<CustomAuthorizeFilter>();
    options.Filters.Add<HttpResponseExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGerenciaNet();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseItToSeed();
}

app.UseHttpsRedirection();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseMiddleware<AuthenticationMiddleware>();

app.MapControllers();

app.Run();
