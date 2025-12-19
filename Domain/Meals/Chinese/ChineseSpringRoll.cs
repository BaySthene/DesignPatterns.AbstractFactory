using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;

namespace DesignPatterns.AbstractFactory.Domain.Meals.Chinese
{
    public sealed class ChineseSpringRoll : IDessert
    {
        public void Prepare()
        {
           Console.WriteLine("Frying Chinese Spring Rolls..");
        }
    }
}
