using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;

namespace DesignPatterns.AbstractFactory.Domain.Meals.Italian
{
    public sealed class ItalianTiramisu : IDessert
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing traditional Italian Tiramisu with mascarpone..");
        }
    }
}
