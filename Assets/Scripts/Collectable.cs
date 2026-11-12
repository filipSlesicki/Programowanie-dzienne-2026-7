using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int pointsValue = 1;
    public PointsSpawner spawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player2D player = other.GetComponent<Player2D>();
        if (player != null)
        {
            other.GetComponent<Player2D>().AddPoints(pointsValue);
            spawner.SpawnPoint();
            //FindAnyObjectByType<PointsSpawner>().SpawnPoint();
            Destroy(gameObject);
        }

    }

}
