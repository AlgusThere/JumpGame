using UnityEngine;

public class LimitFrameRate : MonoBehaviour
{
    [SerializeField] int frameRate = 180;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRate;
    }
}
