using UnityEngine;
using UnityStandardAssets.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject playerBarista)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        
        Barista barista = playerBarista.GetComponent<Barista>();

        barista.PlayerName = lobby.playerName;
        barista.baristaActions = GetPlayerActions();
    }

    private List<string> GetPlayerActions()
    {
        throw new System.NotImplementedException();
    }
}
