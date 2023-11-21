using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Transform player; // Tham chiếu đến người chơi
    private void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Test();
    }

    private void Test()
    {
        if (player == null)
        {
            return;
        }
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        rb.velocity = new Vector2(direction.x, direction.y);
    }
}
