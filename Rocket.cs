using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{   
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public GameObject boss;
    private float distance;
    public float speed;
    private Vector3 directionToPlayer;
    private Rigidbody2D rb;
    
    private Animator anim;
    private bool isTouching = false;

    private void Awake()
    {
        anim =  GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        if (isTouching == true)
        {
            MoveToBoss();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouching = true;
            AnimateSprite();
            LateUpdate();
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
        }
    }

    private void MoveToBoss()
    {   
        distance = Vector2.Distance(transform.position , boss.transform.position);
        
        directionToPlayer = (boss.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y)*speed;
    }

    private void LateUpdate()
    {
        if (transform.position.x < boss.transform.position.x)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
        else if (transform.position.x > boss.transform.position.x)
        {
            transform.localScale =  new Vector3(1f,-1f,1f);
        }
    }

     private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
