using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;
using DesignPatterns.AbstractFactory.Domain.Meals.Chinese;
using DesignPatterns.AbstractFactory.Infrastructure.Factories.Abstractions;

namespace DesignPatterns.AbstractFactory.Infrastructure.Factories
{
    public sealed class ChineseRestaurantFactory : IRestaurantFactory
    {
        public IAppetizer CreateAppetizer()
        {
            return new ChineseDimsum();
        }

        public IDessert CreateDessert()
        {
            return new ChineseSpringRoll();
        }

        public IMainCourse CreateMainCourse()
        {
            return new ChineseNoodle();
        }
    }
}
