using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private Animator anim;
    private bool Change = false;

   
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player") && !Change)
        {
            NoFlag();
            Change = true;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void NoFlag()
    {
        anim.SetTrigger("Flag");
        Invoke(nameof(HaveFlag), 1f);
    }

    private void HaveFlag()
    {
        anim.SetTrigger("Idle");
    }
}
