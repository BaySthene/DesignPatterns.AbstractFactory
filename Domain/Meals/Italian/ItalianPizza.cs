using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;

namespace DesignPatterns.AbstractFactory.Domain.Meals.Italian
{
    public sealed class ItalianPizza : IMainCourse
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing authentic Italian Pizza with mozzarella..");
        }
    }
}
