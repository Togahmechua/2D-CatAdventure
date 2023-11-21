using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePush : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerMovement.HandleKnockback();
            playerMovement.KbCounter = playerMovement.KbTotalTime;
            if (other.transform.position.x < transform.position.x)
            {
                playerMovement.KnockFromRight = true;
            }
            if (other.transform.position.x > transform.position.x)
            {
                playerMovement.KnockFromRight = false;
            }
        }
        
    }
}
