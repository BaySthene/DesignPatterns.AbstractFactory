using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;

namespace DesignPatterns.AbstractFactory.Domain.Meals.Mexican
{
    public sealed class MexicanChurros : IDessert
    {
        public void Prepare()
        {
            Console.WriteLine("Making Mexican Churros with cinnamon...");
        }
    }
}
