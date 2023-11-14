using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObjectPool instance;
    [SerializeField]
    private bool notEnoughobjectPoolInPool = true;
    private List<GameObject> objectPool;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        objectPool = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetGameObjectPool( GameObject poolobjlet)
    {
        if (objectPool.Count > 0)
        {
            for (int i = 0; i < objectPool.Count; i++)
            {
                if (!objectPool[i].activeInHierarchy)
                {
                    return objectPool[i];
                }
            }
        }
        if (notEnoughobjectPoolInPool)
        {
            GameObject obj = Instantiate(poolobjlet);
            obj.SetActive(false);
            objectPool.Add(obj);
            obj.transform.parent = transform;
            return obj;
        }
        return null;
    }
}
