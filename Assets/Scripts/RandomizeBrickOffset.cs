using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeBrickOffset : MonoBehaviour
{
    // Scroll main texture based on time

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        float offsetX = Random.Range(-1, 1);
        float offsetY = Random.Range(-1, 1);

        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}
