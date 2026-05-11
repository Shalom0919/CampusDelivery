var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// 配置跨域策略以允许前端 Vue 应用访问 (默认开放所有，你可以按需限制)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

// 启用跨域中间件
app.UseCors("AllowVueApp");

app.UseAuthorization();

app.MapControllers();

app.Run();