using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering;

public class IdleState: State<EnemyController>
{
    [SerializeField] private Transform route;
    [SerializeField] private float speed;

    private List<Vector3> pointList = new List<Vector3>();

    private Vector3 currentDestination;
    private int currentDestinationIndex;
    public override void onEnterState(EnemyController controller)
    {
        base.onEnterState(controller);
        foreach (Transform t in route)
        {
            pointList.Add(t.position);
        }

        currentDestination = pointList[currentDestinationIndex];
    }

    public override void onUpdateState()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentDestination, speed * Time.deltaTime);
        if (transform.position == currentDestination)
        {
            CalculateNewDestination();
        }
    }

    private void CalculateNewDestination()
    {
        currentDestinationIndex++;
        if(currentDestinationIndex > pointList.Count -1)
        {
            currentDestinationIndex = 0;
        }

        currentDestination = pointList[currentDestinationIndex];

    }

    public override void onExitState()
    {
        pointList.Clear();
        currentDestinationIndex = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out PlayerController player))
        {
            controller.ChangeState(controller.ChaseState);
        }
    }




}
