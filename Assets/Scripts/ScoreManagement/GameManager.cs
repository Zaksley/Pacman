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

    public int score { get; private set; }
    
    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        SetScore(0);
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
        // réactive les ghosts
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }

        // réactive pacman
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

    public void PacmanEaten()
    {
        // qu'une vie pour le moment
        GameOver();
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
