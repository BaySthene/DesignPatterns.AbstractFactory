using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;

namespace DesignPatterns.AbstractFactory.Domain.Meals.Italian
{
    public sealed class ItalianPasta : IAppetizer
    {
        public void Prepare()
        {
           Console.WriteLine("Preparing classic Italian Pasta with tomato sauce..");
        }
    }
}
