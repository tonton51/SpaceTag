using System.Collections;
using UnityEngine;
using Photon.Pun;
 
public class StickPlayerGenerator : MonoBehaviourPunCallbacks
{
    private GameObject kuma;
    private GameObject rocket;
 
    void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            kuma = PhotonNetwork.Instantiate("kuma", new Vector3(-2.5f, 0, 0), Quaternion.identity);
        }
        else
        {
            rocket = PhotonNetwork.Instantiate("rocket", new Vector3(2.5f, 0, 0), Quaternion.identity);
        }
    }
}