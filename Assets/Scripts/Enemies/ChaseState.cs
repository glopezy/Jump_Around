using UnityEngine;

public class ChaseState : State<EnemyController>
{

    private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    public override void onEnterState(EnemyController controller)
    {
        base.onEnterState(controller);
        
    }


    public override void onUpdateState()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
           

        }

        

    }

    public override void onExitState()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            target = player.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            controller.ChangeState(controller.IdleState);
        }
    }

}
