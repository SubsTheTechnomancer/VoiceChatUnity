using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice.Unity;
using Photon.Voice.PUN;
using UnityEngine.SceneManagement;

public class RecoderShirr : MonoBehaviourPunCallbacks
{
    
    [SerializeField]
    private GameObject _player;
    private PhotonVoiceView voiceView;

    void Start()
    {
        GameObject player = PhotonNetwork.Instantiate(_player.name,Vector3.zero,Quaternion.identity);
        voiceView = player.GetComponent<PhotonVoiceView>();
    }

}
