using arbovirose.Infra.Ioc;
using FluentValidation;
using arbovirose.WebApi.Validators.User;
using arbovirose.WebApi.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
//Extension methods
builder.Services.AddCustomSwagger();
builder.Services.AddCustomCors();
builder.Services.AddCustomDbContext(builder.Configuration);

TokenDependency.Register(builder.Services, builder.Configuration);
BcryptDependency.Register(builder.Services);
UserDependency.Register(builder.Services);
ProfileDependency.Register(builder.Services);
AuthDependency.Register(builder.Services);
InfoHomeDependency.Register(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
