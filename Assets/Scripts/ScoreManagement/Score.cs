using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public GameManager gameManager;
    private TextMeshProUGUI txt;

    void Update()
    {
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = gameManager.score.ToString();
    }

}