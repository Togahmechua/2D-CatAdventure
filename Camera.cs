using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
     public Transform target; // Người chơi (player) là mục tiêu camera theo dõi.
    public bool followOnJump = false; // Biến xác định liệu camera có theo dõi khi nhảy hay không.

    public float smoothSpeed = 0.125f; // Điều chỉnh độ mượt của việc camera di chuyển.

    void LateUpdate()
    {
        if (followOnJump || !IsJumping()) // Chỉ theo dõi nếu cho phép hoặc người chơi không nhảy.
        {
            Vector3 desiredPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    bool IsJumping()
    {
        // Thêm code kiểm tra xem người chơi có đang nhảy không, ví dụ: 
        // return target.GetComponent<Rigidbody2D>().velocity.y > 0;
        return false; // Chỉ là một ví dụ đơn giản, bạn cần cung cấp logic kiểm tra nhảy của riêng bạn.
    }
}
