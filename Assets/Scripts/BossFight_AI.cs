using UnityEngine;

public enum BossFightState
{
    Idle,
    Attacking

}

public class BossFight_AI : MonoBehaviour
{
    public Transform playerPosition;
    int hysteresis = 2;
    SpriteRenderer spriteRenderer;
    public int attackDistance; 
    // Current state of the Big Boss
    public BossFightState currentState = BossFightState.Idle;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // get distance to player
        float distanceToPlayer = Vector2.Distance(transform.position, playerPosition.position);
        switch (currentState)
        {
            case BossFightState.Idle:
                if (distanceToPlayer < attackDistance)
                {
                    currentState = BossFightState.Attacking;
                    spriteRenderer.color = Color.red;
                }
                break;

            case BossFightState.Attacking:
                if (distanceToPlayer > attackDistance + hysteresis)
                {
                    currentState = BossFightState.Idle;
                    spriteRenderer.color = Color.white;
                }
                break;
        }
    }
}
