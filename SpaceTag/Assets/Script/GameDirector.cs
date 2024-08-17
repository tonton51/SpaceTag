using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI[] pointtext;
    public TextMeshProUGUI nametext;
    float delta=0;
    public TextMeshProUGUI timertext;
    public static int[] Rpoint=new int[2];
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            nametext.text="kuma";
        }
        else
        {
            nametext.text="rocket";
        }
    }

    // Update is called once per frame
    void Update()
    {
        int[] point=PlayerController.point;
        pointtext[0].text=point[0].ToString();
        pointtext[1].text=point[1].ToString();

        this.delta+=Time.deltaTime;
        timertext.text=this.delta.ToString("F2");
        if(this.delta>30.0){
            Rpoint=PlayerController.point;
            SceneManager.LoadSceneAsync("Ending",LoadSceneMode.Single);
        }
    }
}
