using UnityEngine;
using UnityEngine.InputSystem;

public class MovementGetKey : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            rb.AddForce(Vector3.up * jumpForce * gravity);
        }
    }

    private void FixedUpdate()
    {
        //rb.AddForce(Vector3.right);
    }
}
