using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public InputField createRoom;
    public InputField joinInput;
    public string NameOfPlayer;

    public void Start()
    {
        // Retrieve the player name from PlayerPrefs
        NameOfPlayer = PlayerPrefs.GetString("PlayerName", "DefaultName");

        // Debug statement to check the loaded player name
        Debug.Log("Loaded Player Name: " + NameOfPlayer);
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoom.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        SceneManager.LoadScene("LoadingScene");
        base.OnJoinRoomFailed(returnCode, message);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
        base.OnJoinedRoom();
    }
}
