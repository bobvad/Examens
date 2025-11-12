using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Авторизация и регистрация пользователей",
        Description = "Вход в систему пользователем и работа информационной системы мебельной продукции",
    });
    c.SwaggerDoc("v2", new OpenApiInfo()
    {
        Version = "v2",
        Title = "Авторизация и регистрация пользователей",
        Description = "Вход в систему пользователем и работа информационной системы мебельной продукции",
    });
    c.SwaggerDoc("v3", new OpenApiInfo()
    {
        Version = "v3",
        Title = "Авторизация и регистрация пользователей",
        Description = "Вход в систему пользователем и работа информационной системы мебельной продукции",
    });
    c.SwaggerDoc("v4", new OpenApiInfo()
    {
        Version = "v4",
        Title = "Авторизация и регистрация пользователей",
        Description = "Вход в систему пользователем и работа информационной системы мебельной продукции",
    });
    var xml = Path.Combine(System.AppContext.BaseDirectory, "Examenss.xml");
    c.IncludeXmlComments(xml);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
    app.UseMvc();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Get");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Post");
        c.SwaggerEndpoint("/swagger/v3/swagger.json", "Put");
        c.SwaggerEndpoint("/swagger/v4/swagger.json", "Delete");
    });
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
