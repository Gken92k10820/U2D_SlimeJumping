using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel;
    
    public void setScoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }

    public void showGameOverPanel(bool isShowed)
    {
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(isShowed);
        }
    }
}
