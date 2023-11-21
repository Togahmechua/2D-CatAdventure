using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject player;
    private Animator anim;
    public GameObject pos;
      public GameObject pos2;
    private bool IsTouching;
    public GameObject bullet;
    private bool IsShoot;


    private void Start()
    {
        anim = GetComponent<Animator>();
        IsTouching =  false;
        IsShoot = false;
    }

    private void Update()
    {
        CheckPos();
        if (IsTouching == true)
        {
            Invoke(nameof(Shoot), 3f);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") && !IsTouching)
        {
            anim.SetTrigger("IsTouch");
            IsTouching = true;
        }
    }

    private void CheckPos()
    {
        if (transform.position.y >= 10 || transform.position.y <= -30)
        {
            Destroy(this.gameObject);
        }
    }


    private void Shoot()
    {
        if (IsShoot == false)
        {
            if (player.transform.position.x > transform.position.x)
            {
                anim.SetTrigger("TurnRight");
                Instantiate(bullet, pos2.transform.position, Quaternion.identity);
                IsShoot = true;
            }
            else
            {
                Instantiate(bullet, pos.transform.position, Quaternion.identity);
                IsShoot = true;
            }  
        }
    }
}
