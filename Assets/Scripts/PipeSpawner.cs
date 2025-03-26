using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float maxTime;
    [SerializeField] float heightRange;
    [SerializeField] GameObject _pipe;

    float _timer;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
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
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange),0);
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}
