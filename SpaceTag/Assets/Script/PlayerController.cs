using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using ExitGames.Client.Photon;
public class PlayerController : MonoBehaviourPunCallbacks
{
    Rigidbody2D rb;
    float speed = 5.0f;
    // public static int[] point=new int[2];
    // private const byte PointEventCode=1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //PhotonNetwork.AddCallbackTarget(this);
    }

    // void OnDestroy(){
    //     PhotonNetwork.RemoveCallbackTarget(this);
    // }
    
    // void OnTriggerEnter2D(Collider2D other){
    //     int playernum;
    //     Debug.Log("Attack");
    //     if(other.gameObject.tag=="Item"){
    //         if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
    //         {
    //             Debug.Log("Player1at");
    //             point[0]++;
    //         }else
    //         {
    //             Debug.Log("Player2at");
    //             point[1]++;
    //         }
    //         RaiseEventOptions raiseEventOptions=new RaiseEventOptions{
    //             Receivers=ReceiverGroup.All
    //         };

    //         PhotonNetwork.RaiseEvent(PointEventCode,point,raiseEventOptions,SendOptions.SendReliable);
    //     }
    // }
    // // すべてのプレイヤーが以下の動作を行う
    // public void OnEvent(EventData photonEvent){
    //     if(photonEvent.Code==PointEventCode){
    //         int[] receivepoint=(int[])photonEvent.CustomData;
    //         point=receivepoint;
    //         Debug.Log("AttackCount:"+attackCount);
    //         // Debug.Log("point1:"+point[0]);
    //         // Debug.Log("point2:"+point[1]);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            Vector2 movement = Vector2.zero;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                movement += Vector2.up;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movement += Vector2.down;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                movement += Vector2.right;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movement += Vector2.left;
            }

            rb.velocity = movement.normalized * speed;
        }
    }
}