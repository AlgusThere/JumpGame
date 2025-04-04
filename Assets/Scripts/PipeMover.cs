using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 3f;

    bool isBackgroundSpeedUpdate;

    public static PipeMover instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;

        if (PipeSpawner.instance.maxTime == 2 && movementSpeed == 3f)
        {
            movementSpeed += 3;
            BackgroundLoop.instance.speed += 1;

            Debug.Log("SPEED: " + movementSpeed);
        }
        //else if (PipeSpawner.instance.maxTime == 2.5f && movementSpeed == 2f)
        //{
        //    movementSpeed += 1.5f;
        //    Debug.Log("SPEED: " + movementSpeed);
        //}
        //else if (PipeSpawner.instance.maxTime == 2f && movementSpeed == 2f)
        //{
        //    movementSpeed += 4f;
        //    Debug.Log("SPEED: " + movementSpeed);
        //}

    }
}
