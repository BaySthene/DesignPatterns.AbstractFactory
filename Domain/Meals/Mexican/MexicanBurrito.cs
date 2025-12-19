using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;

namespace DesignPatterns.AbstractFactory.Domain.Meals.Mexican
{
    public sealed class MexicanBurrito : IAppetizer
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing Mexican Burrito with beans and cheese...");
        }
    }
}
