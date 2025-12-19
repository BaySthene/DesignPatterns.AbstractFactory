using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;

namespace DesignPatterns.AbstractFactory.Domain.Meals.Mexican
{
    public sealed class MexicanTaco : IMainCourse
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing spicy Mexican Tacos with salsa..");
        }
    }
}
