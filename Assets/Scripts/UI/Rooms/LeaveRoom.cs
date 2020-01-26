using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LeaveRoom : MonoBehaviour
{
   
    private RoomCanvases _roomCanvases;

    public void Initialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        _roomCanvases.CurrentRoom.Hide();
    }

}
