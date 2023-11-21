using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private Animator animator;
    public float currentHealth;
    public float MaxHealth;
    [SerializeField] private AudioSource hurt;
    [SerializeField] private AudioSource bgrmusic;

    private void Start()
    {
        bgrmusic.Play();
        animator =  GetComponent<Animator>();
        currentHealth = MaxHealth;
    }

    private void Update()
    {
        Check();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            currentHealth -= 10f;
            animator.SetTrigger("Hurt");
            animator.SetTrigger("Next");
            hurt.Play();
        }
    }

   

    private void Check()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
