using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    [SerializeField] private float score;

    public int PlayerHealth { get => playerHealth; set => playerHealth = value; }
    public float Score { get => score; set => score = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
