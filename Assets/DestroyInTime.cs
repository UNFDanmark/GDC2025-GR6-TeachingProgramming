using UnityEngine;

public class DestroyInTime : MonoBehaviour
{
    public float lifetime;

    float progress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;
        if (progress > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
