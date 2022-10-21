using System.Text;
using kyniusBETAPI.Builder;
using kyniusBETAPI.Data;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;
using kyniusBETAPI.Model;
using kyniusBETAPI.Repo;
using kyniusBETAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using IAuthorizationService = kyniusBETAPI.Interface.Service.IAuthorizationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
};
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAuthenticationService,AuthenticationService>();
builder.Services.AddTransient<IRequestRepo,RequestRepo>();
builder.Services.AddTransient<AdminBuilder>();
builder.Services.AddTransient<IMatchRepo,MatchRepo>();
builder.Services.AddTransient<IFootballLeagueRepo,FootballLeagueRepo>();
builder.Services.AddTransient<IGoalsRepo,GoalsRepo>();
builder.Services.AddTransient<IScoreRepo,ScoreRepo>();
builder.Services.AddTransient<IStatusRepo,StatusRepo>();
builder.Services.AddTransient<ITeamRepo,TeamRepo>();
builder.Services.AddTransient<IMatchService,MatchService>();
builder.Services.AddTransient<IScoreService,ScoreService>();
builder.Services.AddTransient<ILeagueRepo,LeagueRepo>();
builder.Services.AddTransient<ILeagueService,LeagueService>();
builder.Services.AddTransient<IUserRepo,UserRepo>();
builder.Services.AddTransient<IInviteRepo,InviteRepo>();
builder.Services.AddTransient<IInviteService,InviteService>();
builder.Services.AddTransient<IAuthorizationService,AuthorizationService>();
builder.Services.AddTransient<IBetRepo,BetRepo>();
builder.Services.AddTransient<IBetService,BetService>();
builder.Services.AddDbContext<BetDB>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("betDB")));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<BetDB>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();