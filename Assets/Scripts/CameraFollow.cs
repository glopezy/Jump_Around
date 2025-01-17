using UnityEngine;
using UnityEngine.Windows;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(7.44f,1.28f,-10f);
    [SerializeField] [Range(1,10)] private float smoothFactor;
    [SerializeField] private Vector3 minValue, maxValue;

    // Update is called once per frame
    private void FixedUpdate()
    {

        Follow();
       
    }

    private void Follow()
    {
        

        Vector3 targetPosition = target.position + offset;

        Vector3 boundPosition = new Vector3(Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x), Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y), targetPosition.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;

        
    }
}
