using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer messRenderer;
    [SerializeField] private float worldHeigh;
    [SerializeField] private float worldWidth;
    [SerializeField] private float animationSpeed = 0.1f;
    void Awake()
    {
        messRenderer = GetComponentInChildren<MeshRenderer>();
        if (messRenderer == null) return;
    }   
    // Start is called before the first frame update
    void Start()
    {
        ScaleFullScren();
    }

    // Update is called once per frame
    void Update()
    {
        ParallaxGameObj.ParallaxScolling(messRenderer, animationSpeed);
    }
    void ScaleFullScren()
    {
        worldHeigh = Camera.main.orthographicSize * 2f;
        worldWidth = worldHeigh * Screen.width / Screen.height;
        messRenderer.transform.localScale = new Vector3(worldWidth, worldHeigh, 0f);
    }
}
