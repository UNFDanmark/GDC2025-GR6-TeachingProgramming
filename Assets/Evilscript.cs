using System;
using UnityEngine;
using UnityEngine.AI;

public class Evilscript : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject BulletPrefab;

    public float coolclown; 
    float cooldownProgress;
    public float bulletSpeed = 5f;
    public AIEyes eyes;
    public Transform BulletSpawn;
    GameObject playerTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("Hej jeg er evil");
        playerTarget = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cooldownProgress -= Time.deltaTime;
        agent.SetDestination(playerTarget.transform.position);
        if (cooldownProgress < 0 && eyes.seesPlayer)
        {
                GameObject bulletClone = Instantiate(BulletPrefab, BulletSpawn.position, Quaternion.identity);
                Rigidbody bulletRb = bulletClone.GetComponent<Rigidbody>();
                bulletRb.linearVelocity = transform.forward * bulletSpeed;
           
           
           
                cooldownProgress = coolclown;
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        
    }
}
