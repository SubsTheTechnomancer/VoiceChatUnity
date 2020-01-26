using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

public class RecoderShirr : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private Recorder recorder;
    private PhotonVoiceView voiceView;


    private void Awake(){

        GameObject player = Instantiate(_player);
        voiceView = player.GetComponent<PhotonVoiceView>();
        voiceView.RecorderInUse = recorder;

    }

}
