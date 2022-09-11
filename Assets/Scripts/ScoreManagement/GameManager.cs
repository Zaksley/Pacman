using System.Collections;
using System.Collections.Generic;
using ScoreManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource pelletSound;
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;
    public static int endScore;

    public int lives { get; private set; }
    public int score { get; private set; }
    
    private void Start()
    {
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
        // quand pacman a mang� tous les points ou au debut du jeu
        // r�active les pac-gommes
        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        // r�active les ghosts
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }

        // r�active pacman
        this.pacman.gameObject.SetActive(true);

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
    }

    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);
        SetLives(this.lives - 1);
        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(ResetState), 1.5f);
        }
        
    }

    public void PelletEaten(Pellet pellet)
    {
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
