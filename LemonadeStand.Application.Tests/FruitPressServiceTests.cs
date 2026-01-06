using LemonadeStand.Domain.Interfaces;
using LemonadeStand.Domain.Models;
using LemonadeStand.Application.Services;
using LemonadeStand.Application.Interfaces;
public class FruitPressServiceTests
{
    [Fact]
    public void Produce_ShouldFail_WhenPaymentIsInsufficient()
    {

        IFruitPressService service = new FruitPressService();

        var recipe = new Recipe(
            name: "Apple Juice",
            allowedFruit: typeof(Apple),
            consumptionPerGlass: 1,
            pricePerGlass: 10
        );

        var fruits = new List<IFruit>
        {
            new Apple(),
            new Apple(),
            new Apple()
        };

        int moneyPaid = 5;              
        int orderedGlassQuantity = 1;   

        var result = service.Produce(
            recipe,
            fruits,
            moneyPaid,
            orderedGlassQuantity
        );

        Assert.False(result.Success);
        Assert.Equal(moneyPaid, result.Change);
    }


    [Fact]
    public void Produce_ShouldFail_WhenInsufficientFruit()
    {
        IFruitPressService service = new FruitPressService();
        var recipe = new Recipe(
            name: "Orange Juice",
            allowedFruit: typeof(Orange),
            consumptionPerGlass: 2,
            pricePerGlass: 15
            );

        var fruits = new List<IFruit>
        {
            new Orange()
        };


        var result = service.Produce(
            recipe,
            fruits,
            moneyPaid: 30,
            orderedGlassQuantity: 1
        );

        Assert.False(result.Success);
        Assert.Equal(fruits.Count, result.RemainingFruits.Count);
        Assert.Contains(fruits.OfType<Orange>().First(), result.RemainingFruits);
    }


    }
