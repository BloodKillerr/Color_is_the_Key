using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayscalePostprocess : MonoBehaviour
{
    private Material _GSmaterial;
    public Shader _shader;
    void Start()
    {
        _GSmaterial = new Material(_shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, _GSmaterial);
    }
}
