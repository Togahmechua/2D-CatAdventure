using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerAnimation : MonoBehaviour
{
    private Animator anim;
    private bool isTouch;
    public GameObject portal;
    public string newTag = "CheckPoint";
  
    private void Start()
    {
        isTouch = false;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isTouch == true && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isTouch == false)
        {
            anim.SetTrigger("IsNext");
            isTouch = true;
        }
    }
}
