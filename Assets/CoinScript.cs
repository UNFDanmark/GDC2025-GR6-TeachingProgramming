
using UnityEngine;
    
public class CoinScript : MonoBehaviour
{
    public float spinningSpeed;
    float angle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * spinningSpeed;
        transform.rotation = Quaternion.Euler(90, angle, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        print("helo");
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
