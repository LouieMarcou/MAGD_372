using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Collider))]
public class ColorChanger : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Shader shader;

    [SerializeField]
    private Material originalMaterial;

    float duration = 2.0f;

    private Volume volume;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        volume = GetComponent<Volume>();
        shader = originalMaterial.shader;

        Debug.Log(shader);

    }

    // Update is called once per frame
    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        meshRenderer.material.color = Color.Lerp(Color.blue, Color.red, lerp);


    }
}
