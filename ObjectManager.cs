using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgrmusic;
    private void Start()
    {
        bgrmusic.Play();
    }
    private void Update()
    {
        CheckAndDestroyObjects();
    }

    private void CheckAndDestroyObjects()
    {
        GameObject[] objectsToCheck = GameObject.FindGameObjectsWithTag("Trap"); 

        foreach (GameObject obj in objectsToCheck)
        {
            float posY = obj.transform.position.y;

            if (posY >= 30 || posY <= -30)
            {
                Destroy(obj);
            }
        }
    }
}

