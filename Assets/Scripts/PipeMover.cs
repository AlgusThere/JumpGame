using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    private void Update()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }
}
