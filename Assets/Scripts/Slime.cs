using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    GameController m_gc;
    Rigidbody2D m_rb2d;
    public static float jumpForce = 550;
    bool m_isGround;
    public AudioSource aus;
    public AudioClip jumpSound;
    public AudioClip gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if (isJumpKeyPressed && m_isGround)
        {
            // Vector2.up = (0 ,1)
            // (0, 1) * 5 = (0, 5)
            m_rb2d.AddForce(Vector2.up * jumpForce);
            m_isGround = false;

            if(aus && jumpSound)
            {
                aus.PlayOneShot(jumpSound);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            //Debug.Log("Player touches Deathzone!");
            m_gc.setGameOver(true);

            if(aus && gameOverSound)
            {
                aus.PlayOneShot(gameOverSound);
            }
            Destroy(gameObject);
        }
    }
}
