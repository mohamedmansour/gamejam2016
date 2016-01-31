using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using UnityStandardAssets.Network;

namespace Assets
{
    class OrderManager
    {
        private Dictionary<string ,Func<FufilledDrink>> drinks;
        private Dictionary<string, Func<FufilledIngredient>> ingredients;

        private readonly Random rng = new Random();

        public readonly List<Barista> players;
        
        public OrderManager(List<Barista> players)
        {
            InitIngredients();
            InitDrinks();

            this.players = players;

            var orderAssignmentTimer = new Timer(AssignNewOrders, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }

        private void AssignNewOrders(object state)
        {
            foreach (var player in players)
            {
                player.AssignOrder(GetNewOrder(100));
            }
        }
        
        public FufilledOrder GetNewOrder(int difficultyLevel)
        {
            var orderDrinks = new List<FufilledDrink>();
            var currentOrderDifficulty = 0;

            while (currentOrderDifficulty < difficultyLevel)
            {
                var drinkSelection = drinks.Keys.ElementAt(rng.Next(0, drinks.Keys.Count));
                var newDrink = drinks[drinkSelection].Invoke();

                currentOrderDifficulty += newDrink.difficulty;
                orderDrinks.Add(newDrink);
            }

            return new FufilledOrder(orderDrinks);
        }

        private void InitIngredients()
        {
            ingredients["clean"] = () => new FufilledIngredient("clean", 1);

            ingredients["single_espresso"] = () => new FufilledIngredient("single_espresso", 1);
            ingredients["double_espresso"] = () => new FufilledIngredient("double_espresso", 2);
            ingredients["triple_espresso"] = () => new FufilledIngredient("triple_espresso", 3);

            ingredients["light_roast"] = () => new FufilledIngredient("light_roast", 1);
            ingredients["medium_roast"] = () => new FufilledIngredient("medium_roast", 2);
            ingredients["dark_roast"] = () => new FufilledIngredient("dark_roast", 3);

            ingredients["fine_grind"] = () => new FufilledIngredient("fine_grind", 1);
            ingredients["medium_grind"] = () => new FufilledIngredient("medium_grind", 2);
            ingredients["coarse_grind"] = () => new FufilledIngredient("coarse_grind", 3);

            ingredients["skim_milk"] = () => new FufilledIngredient("skim_milk", 1);
            ingredients["two_percent_milk"] = () => new FufilledIngredient("two_percent_milk", 2);
            ingredients["whole_milk"] = () => new FufilledIngredient("whole_milk", 3);

            ingredients["no_sugar"] = () => new FufilledIngredient("one_sugar", 0);
            ingredients["one_sugar"] = () => new FufilledIngredient("one_sugar", 1);
            ingredients["two_sugar"] = () => new FufilledIngredient("two_sugar", 2);
            ingredients["three_sugar"] = () => new FufilledIngredient("three_sugar", 3);

            ingredients["one_scoop_ice"] = () => new FufilledIngredient("one_scoop_ice", 1);
            ingredients["two_scoop_ice"] = () => new FufilledIngredient("two_scoop_ice", 2);
            ingredients["three_scoop_ice"] = () => new FufilledIngredient("three_scoop_ice", 3);

            ingredients["steam_milk_on"] = () => new FufilledIngredient("steam_milk_on", 1);
            ingredients["steam_milk_off"] = () => new FufilledIngredient("steam_milk_off", 2);

            ingredients["small_water"] = () => new FufilledIngredient("small_water", 1);
            ingredients["medium_water"] = () => new FufilledIngredient("medium_water", 2);
            ingredients["large_water"] = () => new FufilledIngredient("large_water", 3);

            ingredients["green_tea"] = () => new FufilledIngredient("green_tea", 1);
            ingredients["black_tea"] = () => new FufilledIngredient("black_tea", 2);
            ingredients["herbal_tea"] = () => new FufilledIngredient("herbal_tea", 3);

            ingredients["whipped_cream"] = () => new FufilledIngredient("whipped_cream", 1);

            ingredients["one_scoop_cocoa"] = () => new FufilledIngredient("one_scoop_cocoa", 1);
            ingredients["two_scoop_cocoa"] = () => new FufilledIngredient("two_scoop_cocoa", 2);
            ingredients["three_scoop_cocoa"] = () => new FufilledIngredient("three_scoop_cocoa", 3);

            ingredients["one_scoop_ice_cream"] = () => new FufilledIngredient("one_scoop_ice_cream", 1);
            ingredients["two_scoop_ice_cream"] = () => new FufilledIngredient("two_scoop_ice_cream", 2);
            ingredients["three_scoop_ice_cream"] = () => new FufilledIngredient("three_scoop_ice_cream", 3);

            foreach (var syrupType in new List<string> {"vanilla", "raspberry", "chocolate", "cinnamon", "hazelnut"})
            {
                ingredients[syrupType + "_syrup_one_pump"] = () => new FufilledIngredient(syrupType + "_syrup_one_pump", 1);
                ingredients[syrupType + "_syrup_two_pump"] = () => new FufilledIngredient(syrupType + "_syrup_two_pump", 2);
                ingredients[syrupType + "_syrup_three_pump"] = () => new FufilledIngredient(syrupType + "_syrup_three_pump", 3);
            }

            ingredients["finalize"] = () => new FufilledIngredient("finalize", 1);
        }

        private void InitDrinks()
        {
            foreach (var drinkSize in new List<string> {"small", "medium", "large"})
            {
                drinks[drinkSize + "_tea"] = () => new FufilledDrink(new List<FufilledIngredient>()
                {
                    ingredients.Where(i => i.Key.EndsWith("tea")).ElementAt(rng.Next(0,3)).Value.Invoke(),
                    ingredients.First(i => i.Key.EndsWith(drinkSize + "_water")).Value.Invoke()
                }, 1);

                drinks[drinkSize + "_espresso"] = () => new FufilledDrink(new List<FufilledIngredient>()
                {
                    ingredients.Where(i => i.Key.EndsWith("roast")).ElementAt(rng.Next(0,3)).Value.Invoke(),
                    ingredients.Where(i => i.Key.EndsWith("grind")).ElementAt(rng.Next(0,3)).Value.Invoke(),
                    ingredients.First(
                        i =>
                            i.Key.EndsWith(drinkSize == "small"
                                ? "single_espresso"
                                : drinkSize == "medium"
                                    ? "double_espresso"
                                    : "triple_espresso"))
                        .Value.Invoke(),
                    ingredients.Where(i => i.Key.EndsWith("sugar")).ElementAt(rng.Next(0,4)).Value.Invoke(),
                }, 2);

                drinks[drinkSize + "_coffee"] = () => new FufilledDrink(new List<FufilledIngredient>()
                {
                    ingredients.Where(i => i.Key.EndsWith("roast")).ElementAt(rng.Next(0,3)).Value.Invoke(),
                    ingredients.Where(i => i.Key.EndsWith("grind")).ElementAt(rng.Next(0,3)).Value.Invoke(),
                    ingredients.Where(i => i.Key.EndsWith("sugar")).ElementAt(rng.Next(0,4)).Value.Invoke(),
                    ingredients.First(i => i.Key.EndsWith(drinkSize + "_water")).Value.Invoke()
                }, 3);

                drinks[drinkSize + "_latte"] = () => new FufilledDrink(new List<FufilledIngredient>()
                {
                    ingredients.Where(i => i.Key.EndsWith("roast")).ElementAt(rng.Next(0,3)).Value.Invoke(),
                    ingredients.Where(i => i.Key.EndsWith("grind")).ElementAt(rng.Next(0,3)).Value.Invoke(),
                    ingredients.Where(i => i.Key.EndsWith("espresso")).ElementAt(rng.Next(0,3)).Value.Invoke(),
                    ingredients.Where(i => i.Key.EndsWith("sugar")).ElementAt(rng.Next(0,4)).Value.Invoke(),
                    ingredients.Where(i => i.Key.EndsWith("milk")).ElementAt(rng.Next(0,3)).Value.Invoke(),
                    ingredients.First(i => i.Key.EndsWith("steam_milk_on")).Value.Invoke(),
                    ingredients.First(i => i.Key.EndsWith(drinkSize + "_water")).Value.Invoke(),
                }, 4);
            }
        }
    }
}
