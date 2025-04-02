using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] public float maxTime;
    [SerializeField] float heightRange;
    [SerializeField] public GameObject _pipe;

    float _timer;

    public static PipeSpawner instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        TimeCalculator();
    }

    private void TimeCalculator()
    {
        if (_timer > maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange), 0);
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        Destroy(pipe, 12f);
    }
}
