using UnityEngine;
using UnityEngine.Windows;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(7.44f,1.28f,-10f);
    [SerializeField] [Range(1,10)] private float smoothFactor;

    // Update is called once per frame
    private void FixedUpdate()
    {

        Follow();
       
    }

    private void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
