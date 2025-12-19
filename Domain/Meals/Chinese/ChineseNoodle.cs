using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;

namespace DesignPatterns.AbstractFactory.Domain.Meals.Chinese
{
    public sealed class ChineseNoodle : IMainCourse
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing delicious Chinese Noodles with soy sauce..");
        }
    }
}
