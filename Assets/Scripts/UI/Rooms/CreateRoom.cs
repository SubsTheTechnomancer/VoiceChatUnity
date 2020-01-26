using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI _roomName;

    private RoomCanvases _roomCanvases;

    public void Initialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    public void OnClick_CreateRoom(){
       if(!PhotonNetwork.IsConnected){
           return;
       }
       RoomOptions options = new RoomOptions();
       options.MaxPlayers = 6;
       PhotonNetwork.JoinOrCreateRoom(_roomName.text,options,TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room sucessfully with name " + _roomName.text);
        _roomCanvases.CurrentRoom.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
         Debug.Log("Room creation failed: " + message);
    }

}
