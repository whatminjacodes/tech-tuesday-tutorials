// Modified from tutorial sharpcoderblog.com @2019 https://sharpcoderblog.com/blog/create-a-hologram-effect-in-unity-3d
using System.Collections;
using UnityEngine;

public class ControllingGlitch : MonoBehaviour
{
    [SerializeField] [Range (0, 1)] public float _glitchFrequency = 0.1f;
    [SerializeField] [Range (0, 1)] private float _minGlitchIntensity = 0.001f;
    [SerializeField] [Range (0, 1)] private float _maxGlitchIntensity = 0.005f;

    Material hologramMaterial;
    WaitForSeconds glitchLoopWait = new WaitForSeconds(0.1f);

    void Awake()
    {
        hologramMaterial = GetComponent<Renderer>().material;
    }

    IEnumerator Start()
    {
        while (true)
        {
            float glitchTest = Random.Range(0f, 1f);

            if (glitchTest <= _glitchFrequency)
            {
                float originalGlowIntensity = hologramMaterial.GetFloat("_GlowIntensity");
                hologramMaterial.SetFloat("_GlitchIntensity", Random.Range(_minGlitchIntensity / 100, _maxGlitchIntensity / 100));
                hologramMaterial.SetFloat("_GlowIntensity", originalGlowIntensity * Random.Range(0.14f, 0.44f));
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
                hologramMaterial.SetFloat("_GlitchIntensity", 0f);
                hologramMaterial.SetFloat("_GlowIntensity", originalGlowIntensity);
            }

            yield return glitchLoopWait;
        }
    }
}