using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoom : MonoBehaviour
{
   
    [SerializeField]
    private CreateRoom _createRoom;
    [SerializeField]
    private RoomListingsMenu _roomListingsMenu;

    private RoomCanvases _roomCanvases;

    public void Initialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
        _createRoom.Initialize(canvases);
        _roomListingsMenu.Initialize(canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
