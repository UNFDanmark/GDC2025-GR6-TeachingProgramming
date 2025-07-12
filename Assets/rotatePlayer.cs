using UnityEngine;
using UnityEngine.InputSystem;
public class rotatePlayer : MonoBehaviour

{
    public float rotateSpeed;
    public InputAction rotateAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotateAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var transform = GetComponent<Transform>();
        transform.Rotate(0,rotateSpeed*rotateAction.ReadValue<float>()*Time.deltaTime,0);
    }
}
