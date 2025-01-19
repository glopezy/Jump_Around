using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IdleState idleState;
    private ChaseState chaseState;

    private State<EnemyController> current;

    public IdleState IdleState { get => idleState; }
    public ChaseState ChaseState { get => chaseState; }


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

    public void ChangeState(State<EnemyController> newState)
    {
        if (current != null)
        {
            current.onExitState();
        }
        current = newState;
        current.onEnterState(this);
    }
}
