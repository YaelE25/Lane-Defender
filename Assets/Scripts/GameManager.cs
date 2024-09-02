using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int playerHealth;
    [SerializeField] private float score;
    [SerializeField] private float highScore;
    [SerializeField] private TMP_Text HighScoreText;
    [SerializeField] private float enclosedHighSscoreNumber = 0;
    [SerializeField] private TMP_Text deathHighScoreText;
    [SerializeField] private GameObject deathHighScoreObject;
    [SerializeField] private GameObject congratsnewHighScore;
    [SerializeField] private GameObject playerTank;
    private int health;
    [SerializeField] private GameObject UI;
    private float enclosedHighScoreNumber;
    private InputAction restart;
    private InputAction quit;
    [SerializeField] private AudioClip _deathSound;

    public int PlayerHealth { get => playerHealth; set => playerHealth = value; }
    public float Score { get => score; set => score = value; }

    // Start is called before the first frame update
    void Start()
    {
        congratsnewHighScore.SetActive(false);
        restart = _playerInput.currentActionMap.FindAction("Restart");
        quit = _playerInput.currentActionMap.FindAction("Quit");
        restart.started += RestartStarted;
        quit.started += Quit_started;
        health = 3;
        UI.SetActive(false);
    }

    private void Awake()
    {
        highScore = PlayerPrefs.GetFloat("High Score:");
        HighScoreText.text = "High Score: " +highScore.ToString();
    }
    public void OnDestroy()
    {
        restart.started -= RestartStarted;
        quit.started -= Quit_started;
    }

    private void Quit_started(InputAction.CallbackContext obj)
    {
        Application.Quit();
    }

    private void RestartStarted(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }

    public void LoseHealth()
    {
        health -= 1;
        playerHealth--;
        lifeText.text = "Lives: " + playerHealth.ToString() + "/3";
        if (health <= 0)
        {
            //Death
           UI.SetActive(true);
            AudioSource.PlayClipAtPoint(_deathSound, transform.position);
            deathHighScoreText.text = "High Score: " + highScore;
            PlayerPrefs.SetFloat("High Score:", highScore);
        }
    }

    public void AddScore()
    {
        //PlayerPrefs.GetFloat("High Score: ");
        score += 300f;
        //score++;
        scoreText.text = "Score: " + score.ToString();
        if (score > highScore)
        {
            checkHighScore();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        //score = enclosedHighScoreNumber;
    }

    private void checkHighScore()
    {
        highScore = score;
        HighScoreText.text ="High Score: " + highScore.ToString();
        //if(enclosedHighScoreNumber > PlayerPrefs.GetFloat("High Score: ",0))
        //{
        //    PlayerPrefs.SetFloat("High Score: ", enclosedHighScoreNumber);
            
        //}
        
    }
}
