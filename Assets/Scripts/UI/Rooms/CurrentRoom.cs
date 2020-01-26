using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoom : MonoBehaviour
{

    [SerializeField]
    private PlayerListingsMenu _playerListingsMenu;
    [SerializeField]
    private LeaveRoom _leaveRoom;
    public LeaveRoom LeaveRoom{get{return _leaveRoom;}}
   
    private RoomCanvases _roomCanvases;

    public void Initialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
        _playerListingsMenu.Initialize(canvases);
        _leaveRoom.Initialize(canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
