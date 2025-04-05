using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 6f;

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


        if (GameManager.instance.currentScore == GameManager.instance.randomRangeNumber && movementSpeed == 6f)
        {
            movementSpeed = 7f;
            Debug.Log("SPEED: " + movementSpeed);


            if (BackgroundLoop.instance.speed == 20)
            {
                return;
            }
            BackgroundLoop.instance.speed += 1;
        }
        else if (GameManager.instance.currentScore == GameManager.instance.randomRangeNumber1 && movementSpeed == 7f)
        {
            movementSpeed = 9f;
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
