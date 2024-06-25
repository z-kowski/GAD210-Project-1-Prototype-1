using UnityEngine;

//Governs player movement controls (WASD).
//Controls movement speed and jump height.

public class PlayerController : MonoBehaviour
{
    [Tooltip("The speed at which the player can move.")]
    public float playerMoveSpeed;

    [Tooltip("The speed at which the player can turn left and right (using the arrow keys).")]
    public float playerTurnSpeed;

    private Rigidbody playerRB;

    [Tooltip("The force applied to the player's jump ability, effectively governing jump height.")]
    public float jumpForce;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += playerMoveSpeed * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= playerMoveSpeed * Time.deltaTime * transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= playerMoveSpeed * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += playerMoveSpeed * Time.deltaTime * transform.right;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(GetComponent<Rigidbody>().velocity.y) < 0.01f) //player can only jump once before returning to a surface. Currently checks if object velocity is basically 0.
        {
            playerRB.AddForce(transform.up * jumpForce);
            //note to self: checking the velocity can be removed if I want to add in-air jumps! I could probably include a boolean to limit the number of in-air jumps, like forcing a double jump.
        }
    }
}
