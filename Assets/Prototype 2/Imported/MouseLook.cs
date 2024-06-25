using UnityEngine;

//Attached to a playable character's camera. Allows for full mouse input of the camera view, while allowing the player model to be constrained on all rotational axes.

public class MouseLook : MonoBehaviour
{
    //Below are variables from Brackeys "First Person Movement in Unity - FPS Controller".

    [Tooltip("Set the mouse-look sensitivity.")]
    public int mouseSensitivity = 300;

    [Tooltip("Reference the playable character model.")]
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //All below is from Brackeys
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
