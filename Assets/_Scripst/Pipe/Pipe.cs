using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameCtrl;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 2.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {     
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private void OnEnable()
    {
        Invoke("Destroy", 10f);
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

}
