using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScore : MonoBehaviour
{
    private TextMeshProUGUI txt;

    void Update()
    {
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = GameManager.endScore.ToString();
    }

}