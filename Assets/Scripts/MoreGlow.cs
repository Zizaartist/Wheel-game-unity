using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreGlow : MonoBehaviour
{
    public Material mat;
    public float intensity = 0f;

    void Start()
    {
        mat.EnableKeyword("_EMISSION");
    }
}
