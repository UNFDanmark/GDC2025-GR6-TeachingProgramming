using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = Unity.Mathematics.Random;

public class shootingScript : MonoBehaviour
{
    public GameObject BulletPrefab;

    public float coolclown; 
    float cooldownProgress;
    public InputAction shoot;

    public float bulletSpeed=5f;
    public Animator animator;

    AudioSource audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shoot.Enable();
        audioSource = GetComponent < AudioSource>();
        
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
           audioSource.pitch = UnityEngine.Random.Range(0.3f, 3f);
           audioSource.Play();
           
           cooldownProgress = coolclown;
        }
    }
}
