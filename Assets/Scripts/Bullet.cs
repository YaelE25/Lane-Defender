using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    [SerializeField] private float bulletExplodeTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            speed = 0;
            StartCoroutine(bulletBreak());
        }
    }

    private IEnumerator bulletBreak()
    {
        yield return new WaitForSeconds(bulletExplodeTime);
        Destroy(gameObject);
    }
}
