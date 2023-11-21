using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameCtrl;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
