using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine;
using TMPro;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
   [SerializeField]
    private PlayerListing _playerListing;
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private TextMeshProUGUI _readyText;


    private List<PlayerListing> _listings = new List<PlayerListing>();
    private RoomCanvases _roomCanvases;
    private bool _ready = false;

    private void Awake()
    {
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SetReady(false);
        GetCurrentRoomPlayers();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for(int i = 0; i < _listings.Count; i++)
        {
            Destroy(_listings[i].gameObject);
        }
        _listings.Clear();
    }

    public void Initialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    private void SetReady(bool state)
    {
        _ready = state;
        if(_ready)
            _readyText.text = "Ready";
        else
            _readyText.text = "Not Ready";
    }

    private void GetCurrentRoomPlayers()
    {
        if(!PhotonNetwork.IsConnected)
            return;
        if(PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;

        foreach(KeyValuePair<int,Player> playerinfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerinfo.Value);
        }
    }

    private void AddPlayerListing(Player newPlayer)
    {
        int index = _listings.FindIndex(x => x.Player == newPlayer);
        if(index != -1)
        {
            _listings[index].SetPlayerInfo(newPlayer);
        }
        else{
            PlayerListing listing = Instantiate(_playerListing,_content);
            if(listing != null)
            {
                listing.SetPlayerInfo(newPlayer);
                _listings.Add(listing);
            }
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        _roomCanvases.CurrentRoom.LeaveRoom.OnClick_LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listings.FindIndex(x => x.Player == otherPlayer);
        if(index != -1)
        {
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }

    public void OnClick_StartGame()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            for(int i = 0; i < _listings.Count; i++)
            {
                if(_listings[i].Player != PhotonNetwork.LocalPlayer)
                {
                    if(!_listings[i].Ready)
                    {
                        Debug.Log("Someone is not ready");
                        return;
                    }
                }
            }

            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }
    }

    public void OnClick_Ready()
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            SetReady(!_ready);
            base.photonView.RPC("RPC_ChangeReadyState",RpcTarget.MasterClient,PhotonNetwork.LocalPlayer,_ready);
        }
    }

    [PunRPC]
    private void RPC_ChangeReadyState(Player player, bool ready)
    {
        int index = _listings.FindIndex(x => x.Player == player);
        if(index != -1)
        {
            _listings[index].Ready = ready;
        }
    }

}
