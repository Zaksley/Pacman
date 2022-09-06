using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MapSelector : MonoBehaviour
{
    [SerializeField] private Button[] _maps;
    private int _mapSelected = 0;

    public ColorBlock defaultColor;
    public ColorBlock selectedColor;

    private void Start()
    {
        SetMapColor();
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
        
    }

}
