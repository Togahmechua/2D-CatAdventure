using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    
    public GameObject face;
    public GameObject trigger;
    public GameObject thisGameOBJ;
    public float speed;
    private bool isTouch = false;

    private void Update()
    {
        if (isTouch == true)
        {
            thisGameOBJ.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            face.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed, ForceMode2D.Impulse);
            Invoke(nameof(Wait), 0.5f);
            isTouch = true;
        }
    }

    private void Wait()
    {
        trigger.SetActive(true);
        Invoke(nameof(Disapear), 1.5f);
    }

    private void Disapear()
    {
        trigger.SetActive(false);
    }
}
