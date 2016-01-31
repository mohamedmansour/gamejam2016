using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets;
using UnityEngine.Networking;

public class Barista : NetworkBehaviour
{
    public string PlayerName;

    public List<string> baristaActions;

    public FufilledOrder currentOrder;

    [SyncVar]
    public List<string> availableActions = new List<string> { "Steam", "Grind", "" };

    public Barista(string playerName, List<string> baristaActions)
    {
        PlayerName = playerName;
        this.baristaActions = baristaActions;
    }

    public void AssignOrder(FufilledOrder newOrder)
    {
        currentOrder = newOrder;
    }

    [Command]
    public void CmdSendIngredientToOrder(string ingredientName, int state)
    {
        currentOrder.fufilledDrinks.First(d => !d.IsFufilled).AddIngredientToDrink(ingredientName, state);
    }
}
