using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3 : MonoBehaviour
{
    public Transform targetPosition;
    public Transform block;
    public float translationSpeed = 5f;

    private bool isMoving = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Chỉ xử lý khi game object với tag "Player" va chạm trigger
        {
            isMoving = true;
           
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            // Dịch chuyển game object đến vị trí được chỉ định
            block.position = Vector3.MoveTowards(block.position, targetPosition.position, translationSpeed * Time.deltaTime);

            // Kiểm tra xem game object đã đến vị trí đích chưa
            if (block.position == targetPosition.position)
            {
                isMoving = false; // Dừng dịch chuyển
            }
        }
    }
}
