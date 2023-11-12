using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParallaxGameObj
{
    public static void ParallaxScolling(MeshRenderer mesh, float animationSpeed)
    {
        mesh.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
