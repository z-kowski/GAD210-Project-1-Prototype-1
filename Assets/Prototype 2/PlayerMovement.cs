using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal"), body.velocity.y);
    }
}
