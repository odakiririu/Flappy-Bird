using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameCtrl;

public class PipeCtrl : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float countDown;
    [SerializeField] private float timeDuration = 1f;

    private void Awake()
    {
        countDown = timeDuration;
    }

    void Start()
    {
        pipePrefab = Resources.Load("_Prefabs/Pipe") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameCtrl.Ins.gameState == GameState.GamePlay)
        {
            InitPipe();
        }
    }
    void InitPipe()
    {
        if (pipePrefab == null) return;
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {

            Instantiate(pipePrefab, RandomPositionPipe(), Quaternion.identity);
            countDown = timeDuration;
        }
    }
    private Vector3 RandomPositionPipe()
    {
        Vector3 pos = new Vector3(3, Random.Range(-1.5f, 1.5f), 0);
        return pos;
    }

}
