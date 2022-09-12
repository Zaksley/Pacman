using System.Collections;
using System.Collections.Generic;
using ScoreManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource pelletSound;
    public GameObject[] hearts;
    public Pacman pacman;
    public Transform pellets;
    public static int endScore;

    public int lives { get; private set; }
    public int score { get; private set; }

    private PacmanAnimationController animePacman;


    private void Start()
    {

        animePacman = (PacmanAnimationController)this.pacman.gameObject.GetComponent(typeof(PacmanAnimationController));
        NewGame();
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        // quand pacman a mangé tous les points ou au debut du jeu
        // réactive les pac-gommes
        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {

        // réactive pacman
        this.pacman.gameObject.SetActive(true);
        animePacman.PlayStart();

    }

    private void GameOver()
    {
        this.pacman.gameObject.SetActive(false);
        GameManager.endScore = this.score;
        SceneManager.LoadScene("GameOver Scene", LoadSceneMode.Single);
    }

    public void SetScore(int score)
    {
        this.score = score;
    }

    public void SetLives(int lives)
    {
        this.lives = lives;
        showHearts(lives);

    }

    private void showHearts(int lives)
    {
        for (int i = 0; i < 3; i++)
        {
            if(i >= lives)
            {
                hearts[i].SetActive(false);
            }
            else
            {
                hearts[i].SetActive(true);
            }
        }
    }
    public void PacmanEaten()
    {
        animePacman.PlayDeath(); //ChoiceAfterDeath appelée dans PlayDeath()
        
    }

    public void ChoiceAfterDeath()
    {
        this.pacman.gameObject.SetActive(false);
        SetLives(this.lives - 1);
        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(ResetState),0.5f);
        }
    }

    public void PelletEaten(Pellet pellet)
    {
        if (!pelletSound.isPlaying)
        {
            pelletSound.Play();
        }

        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.points);
        
        if (!PelletsStillUp())
        {
            this.pacman.gameObject.SetActive(false);
            GameManager.endScore = this.score;
            SceneManager.LoadScene("Win Scene", LoadSceneMode.Single);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        PelletEaten(pellet);
        
    }

    private bool PelletsStillUp()
    {
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
        //plus de pac-gommes
    }
}
