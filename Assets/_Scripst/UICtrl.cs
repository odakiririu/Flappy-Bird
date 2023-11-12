using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour
{
    public static UICtrl Ins;  
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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetActive(GameObject go, bool active)
    {
        go.SetActive(active);
    }
}
