using UnityEngine;
using UnityEngine.InputSystem;


public class Player2D : MonoBehaviour
{
    public float speed = 3;
    private InputAction moveInput;

    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = moveInput.ReadValue<Vector2>();
        // Je¿eli pozycja na x jest wiêksza ni¿ 8 i chce siê ruszyæ w prawo
        if (transform.position.x > 8f && moveDirection.x > 0)
        {
            // to nie ruszaj siê w prawo
            moveDirection.x = 0;
        }


        transform.position += new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
        if(transform.position.x < -8) // Drugi sposób
        {
            // Jeœli ruszy³ siê za daleko w lewo, to przesuñ go na graniczn¹ pozycjê na x
            Vector3 position = transform.position; // Tworzê zmienn¹ z obecn¹ pozycj¹, któr¹ modyfikujê, bo nie mo¿na zmodyfikowaæ samego x w transform.position
            position.x = -8;
            transform.position = position;
        }
    }
}
