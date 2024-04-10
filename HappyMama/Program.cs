using HappyMama.CustomModelBinders;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBinderProviders.Insert(0,new DateTimeCustomBinderProvider());
        options.ModelBinderProviders.Insert(1, new DecimalCustomBinderProvider());
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });

builder.Services.AddApplicationService();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "PayEvent",
        pattern: "/Event/PayEvent/{id}/{information}",
        defaults: new { Controller = "Event", Action = "PayEvent" });

    endpoints.MapControllerRoute(
        name: "PayEvent",
        pattern: "/Event/EditEvent/{id}/{information}",
        defaults: new { Controller = "Event", Action = "EditEvent" });

    endpoints.MapControllerRoute(
        name: "PayEvent",
        pattern: "/Event/DeleteEvent/{id}/{information}",
        defaults: new { Controller = "Event", Action = "DeleteEvent" });

    app.MapDefaultControllerRoute();
    app.MapRazorPages();

});

await app.AddAdminRoleAsync();

await app.RunAsync();


