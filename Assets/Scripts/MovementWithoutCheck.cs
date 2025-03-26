using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementWithoutCheck : MonoBehaviour
{
    [SerializeField] InputAction jump;
    [SerializeField] InputAction movement;
    [SerializeField] float jumpForce;
    [SerializeField] float movementSpeed;

    Rigidbody rb;
    bool isJumping;


    private void OnEnable()
    {
        jump.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(jump.IsPressed())
        {
            rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
            Debug.Log("Space");
            StartCoroutine(WaitForForce());
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(WaitAndPrint());
        }
    }
    
    

    IEnumerator WaitForForce()
    {
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        yield return new WaitForSeconds(1);
    }

    IEnumerator WaitAndPrint()
    {
        Debug.Log("A basýldý");
        yield return new WaitForSeconds(5);
        Debug.Log("A basýldýktan sonra bir süre geçti");
    }
}
