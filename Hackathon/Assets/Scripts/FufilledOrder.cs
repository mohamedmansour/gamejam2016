using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class FufilledOrder
    {
        public List<FufilledDrink> fufilledDrinks;

        public bool IsFufilled
        {
            get
            {
                return fufilledDrinks.All(d => d.IsFufilled);
            }
        } 

        public FufilledOrder(List<FufilledDrink> fufilledDrinks)
        {
            this.fufilledDrinks = fufilledDrinks;
        }
    }
}
