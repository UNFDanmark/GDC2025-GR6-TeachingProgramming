using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class shootingScript : MonoBehaviour
{
    public GameObject BulletPrefab;

    public float coolclown; 
    float cooldownProgress;
    public InputAction shoot;

    public float bulletSpeed=5f;
    public Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownProgress -= Time.deltaTime;
        if (shoot.IsPressed() && cooldownProgress < 0)
        {
           GameObject bulletClone = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
           Rigidbody bulletRb = bulletClone.GetComponent<Rigidbody>();
           bulletRb.linearVelocity = transform.forward * bulletSpeed;
           animator.SetTrigger("Shoot");
               
           
           
           cooldownProgress = coolclown;
        }
    }
}
