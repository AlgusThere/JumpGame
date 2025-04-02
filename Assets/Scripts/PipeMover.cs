using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 2f;

    public static PipeMover instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }
}
