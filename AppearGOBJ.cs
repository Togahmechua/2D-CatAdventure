using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppearGOBJ : MonoBehaviour
{
    public GameObject trigger;
    public float disapear;
    public float spawn;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(Wait), spawn);
        }
    }

    private void Wait()
    {
        trigger.SetActive(true);
        Invoke(nameof(Disapear), disapear);
    }

    private void Disapear()
    {
        trigger.SetActive(false);
    }
}
