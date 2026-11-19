using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        //transform.up to kierunek "do góry" (zielona strza³ka) tego obiektu
        transform.position += speed * Time.deltaTime * transform.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
