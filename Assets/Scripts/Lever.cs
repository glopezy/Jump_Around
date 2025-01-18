using UnityEngine;


public class Lever : MonoBehaviour
{
    [SerializeField] private Mechanism mechanism;

    public void Activate()
    {
        mechanism.Move();
    }

}
