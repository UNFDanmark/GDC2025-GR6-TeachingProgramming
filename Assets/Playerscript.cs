using UnityEngine;
using UnityEngine.InputSystem;


public class Playerscript : MonoBehaviour
{
    int health = 10;

    float vægt = 63.5f;

    public string navn = "John";

    bool erSej = true;
    public float speed = 10f;

    Rigidbody rb;

    public InputAction moveAction;
    
    //Among us
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction.Enable();
        
        print("Among us");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 newVelocity = rb.linearVelocity;
        newVelocity.x = moveInput.x * speed;
        newVelocity.z = moveInput.y * speed;
        rb.linearVelocity = newVelocity;
        

    }
}
