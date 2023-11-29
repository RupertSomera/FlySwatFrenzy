using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System;

public class Connecttogame : MonoBehaviourPunCallbacks
{
    [SerializeField]
    bool Connecting = false;
    [SerializeField]
    bool Gaming = false;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Connecting = true;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Gaming = true;
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
