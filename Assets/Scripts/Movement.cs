using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    [SerializeField] InputAction fly;
    [SerializeField] InputAction rotation;
    [SerializeField] InputAction jump;
    [SerializeField] float jumpForce = 0f;
    [SerializeField] float flyStrength = 100f;
    [SerializeField] float rotationStrength = 100f;

    Rigidbody rb;
    bool isGrounded;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        fly.Enable();
        jump.Enable();
        //rotation.Enable();
    }

    private void FixedUpdate()
    {
        StartFly();
        Jump();
        //ProcessRotation();
    }

    private void Jump()
    {
        if(jump.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void StartFly()
    {
        if (fly.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * flyStrength * Time.fixedDeltaTime);
        }
    }

    void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();

        if (rotationInput < 0)
        {
            StartRotation(rotationStrength);
        }
        else if (rotationInput > 0)
        {
            StartRotation(-rotationStrength);
        }
    }

    private void StartRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
