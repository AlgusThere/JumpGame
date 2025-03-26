using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    [SerializeField] InputAction fly;
    [SerializeField] InputAction rotation;
    [SerializeField] InputAction jump;
    [SerializeField] InputAction leftAndRight;
    [SerializeField] float jumpForce = 0f;
    [SerializeField] float flyStrength = 100f;
    [SerializeField] float rotationStrength = 100f;
    [SerializeField] float leftAndRightSpeed = 0;

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
        leftAndRight.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        StartFly();
        Jump();
        StartLeftAndRight();
        ProcessRotation();
    }



    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    private void Jump()
    {
        if(jump.IsPressed() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
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

    void StartLeftAndRight()
    {
        float isLeftOrRight = leftAndRight.ReadValue<float>();

        if (isLeftOrRight < 0)
        {
            GoLeftOrRight(leftAndRightSpeed);
        }
        else if (isLeftOrRight > 0)
        {
            GoLeftOrRight(-leftAndRightSpeed);
        }
    }

    private void GoLeftOrRight(float goWhere)
    {
        rb.AddForce(Vector3.left * goWhere * Time.deltaTime, ForceMode.Impulse);
    }
    private void StartRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
