using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace UnityStandardAssets.Network
{
    //List of players in the lobby
    public class LobbyPlayerList : MonoBehaviour
    {
        public static LobbyPlayerList _instance = null;

        public RectTransform playerListContentTransform;
        public GameObject warningDirectPlayServer;
        public Transform addButtonRow;
        public Text txtIpStatus;

        protected VerticalLayoutGroup _layout;
        protected List<LobbyPlayer> _players = new List<LobbyPlayer>();

        public void OnEnable()
        {
            _instance = this;
            _layout = playerListContentTransform.GetComponent<VerticalLayoutGroup>();
        }

        public void DisplayDirectServerWarning(bool enabled)
        {
            txtIpStatus.text = string.Format("Ask others to connect join {0}", GetHostIp());
        }

        private string GetHostIp()
        {
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] interfaceAddresses = ipHostEntry.AddressList;
            if (interfaceAddresses.Length > 0)
                return interfaceAddresses[interfaceAddresses.Length - 1].ToString();
            return string.Empty;
        }

        void Update()
        {
            //this dirty the layout to force it to recompute evryframe (a sync problem between client/server
            //sometime to child being assigned before layout was enabled/init, leading to broken layouting)

            if (_layout)
                _layout.childAlignment = Time.frameCount % 2 == 0 ? TextAnchor.UpperCenter : TextAnchor.UpperLeft;
        }

        public void AddPlayer(LobbyPlayer player)
        {
            _players.Add(player);

            player.transform.SetParent(playerListContentTransform, false);
            addButtonRow.transform.SetAsLastSibling();

            PlayerListModified();
        }

        public void RemovePlayer(LobbyPlayer player)
        {
            _players.Remove(player);
            PlayerListModified();
        }

        public void PlayerListModified()
        {
            int i = 0;
            foreach (LobbyPlayer p in _players)
            {
                p.OnPlayerListChanged(i);
                ++i;
            }
        }
    }
}
