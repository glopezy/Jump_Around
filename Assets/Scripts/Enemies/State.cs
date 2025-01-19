using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected EnemyController controller;
    public virtual void onEnterState(EnemyController controller)
    {
        this.controller = controller;
    }

    public abstract void onUpdateState();

    public abstract void onExitState();
}
