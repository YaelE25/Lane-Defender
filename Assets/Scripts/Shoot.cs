using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip tankShoot;


    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            animator.SetBool("Explode", true);
            AudioSource.PlayClipAtPoint(tankShoot, transform.position);
            StartCoroutine(StopExplode());
        }
    }

    private IEnumerator StopExplode()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Explode", false);
    }
}
