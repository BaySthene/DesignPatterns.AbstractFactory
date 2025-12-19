using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;

namespace DesignPatterns.AbstractFactory.Domain.Meals.Chinese
{
    public sealed class ChineseDimsum : IAppetizer
    {
        public void Prepare()
        {
            Console.WriteLine("Steaming Chinese Dimsum with pork (Harrraammmm) ...");
        }
    }
}
