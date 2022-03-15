using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        low,
        high
    }

    public UnityEvent Collided;
    public GameObject collisionParticlesPrefab;
    public TextureOffsetAnimation textureAnimation;
    private bool IsChanging;
    private const float changeDuration = 0.3f;

    private Dictionary<PlayerState, (Vector3 scale, Vector3 position, float animSpeed)> playerStates = new Dictionary<PlayerState, (Vector3, Vector3, float)>
    {
        { PlayerState.low, (new Vector3(0.5f, 1.5f, 0.5f), new Vector3(0, 0.25f, 0), -8f) },
        { PlayerState.high, (new Vector3(1, 0.3f, 1), new Vector3(0, 0.5f, 0), -4f) }
    };

    private PlayerState currentState = PlayerState.high;
    private PlayerState targetState => currentState == PlayerState.low ? PlayerState.high : PlayerState.low;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacles")
        {
            Instantiate(collisionParticlesPrefab, collision.transform.position, Quaternion.identity);
            Collided.Invoke();
        }
    }

    public void ToggleShape()
    {
        if(!IsChanging)
        {
            Debug.Log($"currentState: {currentState}, targetState: {targetState}");
            StartCoroutine(ChangeCooldown());
            transform.DOScale(playerStates[targetState].scale, changeDuration);
            transform.DOMove(playerStates[targetState].position, changeDuration);
            textureAnimation.speedX = playerStates[targetState].animSpeed;
        }
    }

    private IEnumerator ChangeCooldown()
    {
        IsChanging = true;
        yield return new WaitForSeconds(changeDuration);
        currentState = targetState;
        IsChanging = false;
    }
}
