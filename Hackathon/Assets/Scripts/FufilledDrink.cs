using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class FufilledDrink
    {
        private List<FufilledIngredient> fufilledIngredients;

        public int difficulty;

        public bool IsFufilled
        {
            get { return fufilledIngredients.All(i => i.IsFufilled); }
        }

        public FufilledDrink(List<FufilledIngredient> fufilledIngredients, int difficulty)
        {
            this.fufilledIngredients = fufilledIngredients;
            this.difficulty = difficulty;
        }

        public void AddIngredientToDrink(string ingredientName, int state)
        {
            fufilledIngredients.First(i => i.Name == ingredientName).FufillmentState = state;
        }
    }
}
