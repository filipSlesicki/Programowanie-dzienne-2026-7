using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2D : MonoBehaviour
{
    public float speed = 3;
    public float horizontalBounds = 8.5f;
    public GameObject bullet;
    public Transform shootPoint;
    public TMP_Text pointsText;
    private InputAction moveInput;
    private InputAction attackInput;
    private int points;

    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
        attackInput = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = moveInput.ReadValue<Vector2>();
        // Je¿eli pozycja na x jest wiêksza ni¿ 8 i chce siê ruszyæ w prawo
        if (transform.position.x > horizontalBounds && moveDirection.x > 0)
        {
            // to nie ruszaj siê w prawo
            moveDirection.x = 0;
        }


        transform.position += new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
        if(transform.position.x < -horizontalBounds) // Drugi sposób
        {
            // Jeœli ruszy³ siê za daleko w lewo, to przesuñ go na graniczn¹ pozycjê na x
            Vector3 position = transform.position; // Tworzê zmienn¹ z obecn¹ pozycj¹, któr¹ modyfikujê, bo nie mo¿na zmodyfikowaæ samego x w transform.position
            position.x = -horizontalBounds;
            transform.position = position;
        }

        if(attackInput.WasPerformedThisFrame())
        {
            //Shoot
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        }
    }

    public void AddPoints(int amount)
    {
        points += amount;
        pointsText.text = points.ToString();
    }
}
