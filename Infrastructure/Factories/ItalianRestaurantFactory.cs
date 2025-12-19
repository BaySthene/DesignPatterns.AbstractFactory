using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;
using DesignPatterns.AbstractFactory.Domain.Meals.Italian;
using DesignPatterns.AbstractFactory.Infrastructure.Factories.Abstractions;

namespace DesignPatterns.AbstractFactory.Infrastructure.Factories
{
    public sealed class ItalianRestaurantFactory : IRestaurantFactory
    {
        public IAppetizer CreateAppetizer()
        {
            return new ItalianPasta();
        }

        public IDessert CreateDessert()
        {
            return new ItalianTiramisu();
        }

        public IMainCourse CreateMainCourse()
        {
            return new ItalianPizza();
        }
    }
}
