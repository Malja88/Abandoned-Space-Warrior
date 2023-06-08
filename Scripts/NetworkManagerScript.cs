using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NetworkManagerScript : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions()
        {
            MaxPlayers = 2,
            IsVisible = false
        };
        PhotonNetwork.JoinOrCreateRoom("Random Server", options, TypedLobby.Default);
    }
}
