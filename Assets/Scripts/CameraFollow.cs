using UnityEngine;
using UnityEngine.Windows;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset ;
    [SerializeField] private Vector3 crouchOffset;
    [SerializeField] private bool isCrouching;
    [SerializeField] [Range(1,10)] private float smoothFactor;
    [SerializeField] private Vector3 minValue, maxValue;

    public bool IsCrouching { get => isCrouching; set => isCrouching = value; }



    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isCrouching)
        {
            Follow();
        }
        else
        {
            Crouchfollow();
        }
        
       
    }

    private void Follow()
    {
        

        Vector3 targetPosition = target.position + offset;

        Vector3 boundPosition = new Vector3(Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x), Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y), targetPosition.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;

        
    }

    private void Crouchfollow()
    {
        Vector3 targetPosition = target.position + crouchOffset;

        Vector3 boundPosition = new Vector3(Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x), Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y), targetPosition.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }

    
}
