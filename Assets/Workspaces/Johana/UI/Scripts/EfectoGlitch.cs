using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

// glitch cuando cambia el mundo
// usa un Volume con Chromatic Aberration y Lens Distortion
public class EfectoGlitch : MonoBehaviour
{
    public Volume volumen;
    public float duracion = 0.5f;

    ChromaticAberration aberracion;
    LensDistortion distorsion;

    void Start()
    {
        volumen.profile.TryGet(out aberracion);
        volumen.profile.TryGet(out distorsion);
        volumen.weight = 0; // apagado al inicio
    }

    public void Lanzar()
    {
        StopAllCoroutines();
        StartCoroutine(Glitch());
    }

    IEnumerator Glitch()
    {
        float t = 0;
        volumen.weight = 1;

        while (t < duracion)
        {
            t = t + Time.deltaTime;
            // valores random para que tiemble
            aberracion.intensity.value = Random.Range(0.4f, 1f);
            distorsion.intensity.value = Random.Range(-0.45f, 0.45f);
            yield return null;
        }

        volumen.weight = 0;
    }
}
