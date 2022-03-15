using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TextureOffsetAnimation : MonoBehaviour
{
    public Material mat;
    public float speedY = 0.5f;
    public float speedX = 0.5f;

    private void Update() {
        var offsetY = -speedY * Time.deltaTime;
        var offsetX = -speedX * Time.deltaTime;
        mat.mainTextureOffset += new Vector2(offsetX, offsetY);
    }
}
