using UnityEngine;

public class PointsSpawner : MonoBehaviour
{
    public Collectable coinPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPoint();
    }

    public void SpawnPoint()
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-5f, 5f);
        // Quaternion.identity to rotacja (0,0,0)
        Collectable coin = Instantiate(coinPrefab, new Vector3(x, y, 0), Quaternion.identity);
        coin.spawner = this;
    }
}
