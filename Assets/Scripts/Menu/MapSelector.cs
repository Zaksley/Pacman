using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class MapSelector : MonoBehaviour
{
    [SerializeField] private Button[] _maps;
    [SerializeField] private Button[] _difficulties;
    private int _mapSelected = 0;
    private int _difficulty = 0;

    public ColorBlock defaultColor;
    public ColorBlock selectedColor;

    private void Start()
    {
        UpdateDifficulty(0);
        SetMapColor();
    }

    public void UpdateDifficulty(int difficulty)
    {
        _difficulty = difficulty;
        SetDifficultiesColors();
        PlayerPrefs.SetInt("GhostFollowPacman", difficulty);
    }

    private void SetDifficultiesColors()
    {
        for (int iDif = 0; iDif < _difficulties.Length; iDif++)
        {
            if (iDif != _mapSelected)
            {
                _difficulties[iDif].colors = defaultColor;
            }
            else
            {
                _difficulties[iDif].colors = selectedColor;
            }
        }
    }

    public void UpdateMapSelected(int mapSelected)
    {
        _mapSelected = mapSelected; 
        SetMapColor();
    }

    private void SetMapColor()
    {
        for (int iMenu = 0; iMenu < _maps.Length; iMenu++)
        {
            if (iMenu != _mapSelected)
            {
                _maps[iMenu].colors = defaultColor; 
            }
            else
            {
                _maps[iMenu].colors = selectedColor; 
            }
        }
    }
    
    public void PlayGame()
    {
        switch (_mapSelected)
        {
            case 0:
                SceneManager.LoadScene("Pacman Main Game"); 
                break;
            
            case 1:
                SceneManager.LoadScene("Map2"); 
                break; 
            
            case 2:
                SceneManager.LoadScene("Map3");
                break; 
        }
    }
}
