using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Playerscript : MonoBehaviour
{
    public float speed = 10f;

    Rigidbody rb;

    public InputAction moveAction;
    public InputAction restartAction;
    public Animator animator;

    public GameObject gameOverScreen;
    public int health = 5;
    public TextMeshProUGUI healthText;
        
    //Among us
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction.Enable();
        restartAction.Enable();
    }
    
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 newVelocity = rb.linearVelocity;
        newVelocity.x = moveInput.x * speed;
        newVelocity.z = moveInput.y * speed;
        rb.linearVelocity = newVelocity;
        animator.SetFloat("Speed",newVelocity.magnitude);
        if (restartAction.WasPressedThisFrame()) 
        {
            SceneManager.LoadScene("Programmering");
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            health = health - 1;
            rb.linearVelocity += Vector3.up * 20;
            Destroy(other.gameObject);
            healthText.text = "Health: " + health + "/5";
        }
        
        if (health<=0)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
