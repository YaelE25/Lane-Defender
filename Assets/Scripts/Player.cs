using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float tankSpeed;
    private float vertical;

    
    public void Move(InputAction.CallbackContext context)
    {
        //run = true
        vertical = context.ReadValue<Vector2>().y;
    }
    // Update is called once per frame
    void Update()
    {
        rb2D.velocity= new Vector2(rb2D.velocity.x, vertical * tankSpeed);
    }
}
