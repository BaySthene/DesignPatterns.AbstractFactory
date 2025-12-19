
using DesignPatterns.AbstractFactory.Application.Services;
using DesignPatterns.AbstractFactory.Infrastructure.Factories;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register factories
services.AddTransient<ItalianRestaurantFactory>();
services.AddTransient<ChineseRestaurantFactory>();
services.AddTransient<MexicanRestaurantFactory>();

// Register OrderService
services.AddTransient<OrderService>();

var provider = services.BuildServiceProvider();

// Test Italian
Console.WriteLine("=== Italian Restaurant Order ===");
var italianFactory = provider.GetRequiredService<ItalianRestaurantFactory>();
var italianService = new OrderService(italianFactory);
italianService.PlaceOrder();
Console.WriteLine();

// Test Chinese
Console.WriteLine("=== Chinese Restaurant Order ===");
var chineseFactory = provider.GetRequiredService<ChineseRestaurantFactory>();
var chineseService = new OrderService(chineseFactory);
chineseService.PlaceOrder();
Console.WriteLine();

// Test Mexican
Console.WriteLine("=== Mexican Restaurant Order ===");
var mexicanFactory = provider.GetRequiredService<MexicanRestaurantFactory>();
var mexicanService = new OrderService(mexicanFactory);
mexicanService.PlaceOrder();

Console.ReadLine();