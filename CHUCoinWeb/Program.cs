using CNUCoin.DAL.Data;

using CNUCoin.BLL.Interfaces;
using CNUCoin.BLL.Implementations;
using CNUCoin.BLL.Crypto.Interfaces;
using CNUCoin.BLL.Crypto.Implementations;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

// Add Dependencies
builder.Services.AddScoped<ICryptoService, CryptoService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IBlockService, BlockService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();

// TODO:
// Створюється тарнзакція. Конктатинувати: TransactionDate, FromId, ToId, Amount. Підписуємок приватним ключем - Yes
// Чекати поки прийде майнер і замайнить
// Дерево Меркля. Будуємо на основі хешів транзакцій, які не внесені до блокчейну - Yes
// Якщо немає блока, то створюю його - Yes
// Хеш з дерева Мрекля + хеш останнього блоку + Nonce - Yes
// Беру суму і обчислюю новий хеш, поки не досягну певної складності(хеш починається з 0) - Yes
// Створюю новий блок, з обисленим хешем