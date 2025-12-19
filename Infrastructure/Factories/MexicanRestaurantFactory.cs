using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;
using DesignPatterns.AbstractFactory.Domain.Meals.Mexican;
using DesignPatterns.AbstractFactory.Infrastructure.Factories.Abstractions;

namespace DesignPatterns.AbstractFactory.Infrastructure.Factories
{
    public sealed class MexicanRestaurantFactory : IRestaurantFactory
    {
        public IAppetizer CreateAppetizer()
        {
            return new MexicanBurrito();
        }

        public IDessert CreateDessert()
        {
            return new MexicanChurros();
        }

        public IMainCourse CreateMainCourse()
        {
            return new MexicanTaco();
        }
    }
}
