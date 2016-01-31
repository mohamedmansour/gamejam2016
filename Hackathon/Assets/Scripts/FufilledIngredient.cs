using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Networking;

namespace Assets
{
    public class FufilledIngredient : NetworkBehaviour
    {
        private readonly int fufillmentCriteria;
        public string Name { get; private set; }

        public int FufillmentState { get; set; }

        public bool IsFufilled
        {
            get
            {
                return FufillmentState == fufillmentCriteria;
            }
        }

        public FufilledIngredient(string name, int fufillmentCriteria)
        {
            FufillmentState = 0;
            Name = name;
            this.fufillmentCriteria = fufillmentCriteria;
        }
    }
}