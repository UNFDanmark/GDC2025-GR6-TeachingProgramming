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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownProgress -= Time.deltaTime;
        if (shoot.WasPerformedThisFrame() && cooldownProgress < 0)
        {
           GameObject bulletClone = Instantiate(BulletPrefab, transform.position, quaternion.identity);
           Rigidbody bulletRb = bulletClone.GetComponent<Rigidbody>();
           bulletRb.linearVelocity = transform.forward * bulletSpeed;
           
           
           
           cooldownProgress = coolclown;
        }
    }
}
