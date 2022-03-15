using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 2.0f;
    [SerializeField]
    private float speed = 1f;

    private void Start() {
        StartCoroutine(Lifetimer());
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private IEnumerator Lifetimer()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
