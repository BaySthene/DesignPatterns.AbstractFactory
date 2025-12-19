using DesignPatterns.AbstractFactory.Domain.Meals.Abstractions;

namespace DesignPatterns.AbstractFactory.Infrastructure.Factories.Abstractions
{
    public interface IRestaurantFactory
    {
        IAppetizer CreateAppetizer();
        IMainCourse CreateMainCourse();
        IDessert CreateDessert();
    }
}
