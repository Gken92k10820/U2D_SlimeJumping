using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameController m_gc; 
    public static float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3.left = (-1, 0, 0)
        // (-1, 0, 0) * 5 = (-5, 0, 0)
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
    }

    public void moveSpeedIncrement()
    {
        moveSpeed += 0.2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SceneLimit"))
        {
            if (!m_gc.isGameOver())
            {
                if (moveSpeed <= 10)
                {
                    m_gc.scoreIncrement();
                }
                if (m_gc.getScore() > 0 && m_gc.getScore() % 10 == 0)
                {
                    moveSpeedIncrement();
                }
            }
            //Debug.Log("Deathzone out of scene!");
            //Debug.Log("Score: " + m_gc.getScore());
            Destroy(gameObject);
        }
    }
}
