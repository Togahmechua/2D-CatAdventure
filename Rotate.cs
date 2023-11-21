using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360f; // Tốc độ xoay
    private bool isRotate = false;
    private float rotationTimer = 0f;
    public GameObject tree;
    [SerializeField] private float rotationDuration = 1.0f; // Thời gian xoay (1 giây mặc định)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRotate = true;
        }
    }

    private void Update()
    {
        if (isRotate)
        {
            rotationTimer += Time.deltaTime;

            if (rotationTimer < rotationDuration)
            {
                // Xoay cây với tốc độ đã đặt
                float angleToRotate = rotationSpeed * Time.deltaTime;
                tree.transform.Rotate(0, 0, angleToRotate);
            }
            else
            {
                isRotate = false;
                rotationTimer = 0f;
                enabled = false; // Tắt script sau khi xoay xong
            }
        }
    }
}
