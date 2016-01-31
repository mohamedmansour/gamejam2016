using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Networking;

namespace Assets
{
    public class FufilledOrder : NetworkBehaviour
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
