using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameCtrl;

public class BirdCtrl : MonoBehaviour
{
    public static BirdCtrl Ins;
    public float upSpeed = 4.5f;
    private void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else if (Ins)
        {
            Destroy(this);
        }

    }
    public void Init()
    {
        var _go = Resources.Load("_Prefabs/Bird") as GameObject;
        if (_go == null) return;
        GameObject bird = Instantiate(_go, transform.position + Vector3.up, Quaternion.identity);
        bird.transform.name = "Bird";
        bird.transform.parent = transform;
    }
    public void Jump()
    {
        if (GameCtrl.Ins.gameState != GameState.GamePlay) return;
            transform.GetComponentInChildren<Rigidbody2D>().velocity = Vector2.up * upSpeed;
            AudioCtrl.Ins.PlayMusic("sfx_wing");
    }
}
