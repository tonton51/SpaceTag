using UnityEngine;
using Photon.Pun;

public class StickPlayerController : MonoBehaviourPun
{
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;
    public float moveSpeed = 5f;
    public float maxDistance = 2f;

    void Update()
    {
        // 自分のオブジェクトだけが入力を処理する
        if (photonView.IsMine)
        {
            HandleMovement();
            MaintainFixedDistance();
        }
    }

    void HandleMovement()
    {
        // 両プレイヤーの入力を取得
        float moveX1 = Input.GetAxis("Horizontal");
        float moveX2 = Input.GetAxis("Horizontal2");

        // 入力が一致した場合のみ、両方を移動
        if (Mathf.Abs(moveX1) > 0 && moveX1 == moveX2)
        {
            rb1.velocity = new Vector2(moveX1 * moveSpeed, rb1.velocity.y);
            rb2.velocity = new Vector2(moveX2 * moveSpeed, rb2.velocity.y);
        }
        else
        {
            // 入力が一致しない場合、移動を止める
            rb1.velocity = Vector2.zero;
            rb2.velocity = Vector2.zero;
        }
    }

    void MaintainFixedDistance()
    {
        // 両プレイヤーの位置を取得
        Vector2 position1 = rb1.position;
        Vector2 position2 = rb2.position;

        // 両プレイヤーの現在の距離を計算
        float currentDistance = Vector2.Distance(position1, position2);

        // 距離を maxDistance に固定
        if (currentDistance != maxDistance)
        {
            Vector2 direction = (position2 - position1).normalized;
            Vector2 midpoint = (position1 + position2) / 2;

            // プレイヤー1とプレイヤー2の位置を更新して距離を固定
            rb1.position = midpoint - direction * maxDistance / 2;
            rb2.position = midpoint + direction * maxDistance / 2;
        }
    }
}
