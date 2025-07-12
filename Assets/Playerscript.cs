using UnityEngine;
using UnityEngine.InputSystem;


public class Playerscript : MonoBehaviour
{
    public float speed = 10f;

    Rigidbody rb;

    public InputAction moveAction;
    
    
    //Among us
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction.Enable();
    }
    
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 newVelocity = rb.linearVelocity;
        newVelocity.x = moveInput.x * speed;
        newVelocity.z = moveInput.y * speed;
        rb.linearVelocity = newVelocity;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            rb.linearVelocity += Vector3.up * 20;
            Destroy(other.gameObject);
        }
    }
}
