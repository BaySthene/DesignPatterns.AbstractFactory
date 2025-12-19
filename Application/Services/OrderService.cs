using DesignPatterns.AbstractFactory.Infrastructure.Factories.Abstractions;

namespace DesignPatterns.AbstractFactory.Application.Services
{
    public class OrderService(IRestaurantFactory restaurantFactory)
    {
        public void PlaceOrder()
        {
            var appetizer = restaurantFactory.CreateAppetizer();
            appetizer.Prepare();
            var mainCourse = restaurantFactory.CreateMainCourse();
            mainCourse.Prepare();
            var dessert = restaurantFactory.CreateDessert();
            dessert.Prepare();
        }

    }
}
