using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;

public class RecoderShirr : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _player;

    private void Start(){

        GameObject player = Instantiate(_player);

    }

}
