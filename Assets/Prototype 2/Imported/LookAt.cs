using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform mainCamera;
    public Transform target;
    public float speed;

    public void FixedUpdate()
    {
        //transform.LookAt(target);

        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

    }
}
