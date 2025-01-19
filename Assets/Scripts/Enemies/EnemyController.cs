using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IdleState idleState;
    private ChaseState chaseState;

    private State current;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        idleState = GetComponent<IdleState>();
        chaseState = GetComponent<ChaseState>();
        
        ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        if (current != null)
        {
            current.onUpdateState();
        }
    }

    public void ChangeState(State newState)
    {
        if (current != null)
        {
            current.onExitState();
        }
        current = newState;
        current.onEnterState(this);
    }
}
