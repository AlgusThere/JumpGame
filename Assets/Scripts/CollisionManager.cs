using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bum")
        {
            Debug.Log("Crashed!");
            Time.timeScale = 0;
        }
    }
}
