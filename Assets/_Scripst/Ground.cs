using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private float animationSpeed = 0.3f;
    private MeshRenderer messRenderer;
    [SerializeField] private float worldHeigh;
    [SerializeField] private float worldWidth;
    void Awake()
    {
        messRenderer = GetComponentInChildren<MeshRenderer>();
        if (messRenderer == null) return;
        ScaleScreen();
        var colider = transform.AddComponent<BoxCollider2D>();
        colider.size = new Vector2(worldWidth - 0.02f, 2);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ParallaxGameObj.ParallaxScolling(messRenderer, animationSpeed);
    }
    void ScaleScreen()
    {
        worldHeigh = Camera.main.orthographicSize * 2f;
        worldWidth = worldHeigh * Screen.width / Screen.height;
        messRenderer.transform.localScale = new Vector3(worldWidth, 2, 0f);
    }
}
