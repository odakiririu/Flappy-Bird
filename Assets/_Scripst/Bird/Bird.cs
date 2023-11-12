using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameCtrl;

public class Bird : MonoBehaviour
{
    public float upSpeed = 4.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }
    private void Jump()
    {
        if (GameCtrl.Ins.gameState != GameState.GamePlay) return;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.up * upSpeed;
            AudioCtrl.Ins.PlayMusic("sfx_wing");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            GameCtrl.Ins.IncreasecurrentScore();
            AudioCtrl.Ins.PlayMusic("sfx_point");
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            GameCtrl.Ins.SetGameManagerState(GameCtrl.GameState.GameOver);
            AudioCtrl.Ins.PlayMusic("sfx_hit");
        }
    }
}
