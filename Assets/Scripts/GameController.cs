using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Obstacle;
    GameObject Slime;
    public static float spawnTime = 2;
    float m_spawnTime;
    int m_score;
    bool m_isGameOver;
    UIManager m_ui;

    // Start is called before the first frame update
    void Start()
    {
        Slime = GameObject.FindGameObjectWithTag("Player");
        m_spawnTime = 0;
        m_score = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.setScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_ui.showGameOverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0 && Slime)
        {
            spawnObstacle();
            m_spawnTime = spawnTime;
        }
    }

    public void setScore(int val)
    {
        m_score = val;
    }

    public int getScore()
    {
        return m_score;
    }

    public void scoreIncrement()
    {
        m_score++;
        m_ui.setScoreText("Score: " + m_score);
    }

    public bool isGameOver()
    {
        return m_isGameOver;
    }

    public void setGameOver(bool state)
    {
        m_isGameOver = state;
    }

    public void spawnObstacle()
    {
        Vector2 spawnPos = new Vector2(13, Random.Range(-5f, -3f));
        if (Obstacle)
        {
            Instantiate(Obstacle, spawnPos, Quaternion.identity);
        }
    }
    
    public void replay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
