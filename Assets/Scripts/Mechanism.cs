using UnityEngine;
using UnityEngine.Windows;


public class Mechanism : MonoBehaviour
{
   
    [SerializeField] private Transform final_position;
    [SerializeField] private float speed;
    [SerializeField] private bool comeback;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isdoor;

    public void Move()
    {
        collider.enabled = !isdoor;
        if (isdoor)
        {
            rb.linearVelocityY = speed;
        }
        if (!isdoor)
        {
            rb.linearVelocityY = speed;
        }

        //transform.position = Vector3.Lerp(transform.position, final_position.position, Time.deltaTime * speed);
    }
}
