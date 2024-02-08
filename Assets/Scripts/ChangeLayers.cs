using UnityEngine;

public class ChangeLayers : MonoBehaviour
{
    [SerializeField] private Color[] layers;

    private new Renderer renderer;
    private int currentLayer = 0;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = layers[currentLayer];
    }

    public void UpLayer()
    {
        if(currentLayer > 0)
        {
            currentLayer--;
            renderer.material.color = layers[currentLayer];
        }
    }

    public void DownLayer()
    {
        if(currentLayer < layers.Length-1)
        {
            currentLayer++;
            renderer.material.color = layers[currentLayer];
        }
    }
}
