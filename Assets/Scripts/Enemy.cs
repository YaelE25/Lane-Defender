using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float Health = 5f;
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float haltTime = 5f;
    [SerializeField] private float deathTime = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameManager gm;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip _hurtSound;
    [SerializeField] private AudioClip _deathSound;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Health > 0)
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
        }
        else if (Health <= 0)
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetBool("Dead", true);
            AudioSource.PlayClipAtPoint(_deathSound, transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Health -= 1;
            gm.AddScore();
            AudioSource.PlayClipAtPoint(_hurtSound, transform.position);
            StartCoroutine(bulletStop());
            animator.SetBool("Stunned", true);
            animator.SetBool("Walking", false);
        }

        if(collision.gameObject.tag == "Player")
        {
            gm.LoseHealth();
        }
    }

    private IEnumerator bulletStop()
    {
        Speed = 0;
        if(Health <= 0)
        {
            gm.Score += 300;
            yield return new WaitForSeconds(deathTime);
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(haltTime);
        Speed = maxSpeed;
        animator.SetBool("Stunned", false);
        animator.SetBool("Walking", true);
    }
}
