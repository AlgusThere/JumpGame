using UnityEngine;
using UnityEngine.InputSystem;

public class MovementGetKey : MonoBehaviour
{
    [SerializeField] float jumpForce;
    //[SerializeField] float rotationSpeed;

    Animator anim;

    //float initialYRotation;

    Rigidbody rb;

    //public Vector3 torqueDirection = Vector3.up;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //initialYRotation = transform.eulerAngles.y;
    }

    private void Update()
    {
        Jumping();
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            anim.SetBool("isJump", true);
            rb.AddForce(Vector3.up * jumpForce);
            //rb.AddTorque(torqueDirection * rotationSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isJump", false);
        }
    }

    private void FixedUpdate()
    {
        //rb.AddForce(Vector3.right);
    }
}
