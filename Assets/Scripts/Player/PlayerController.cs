using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour 
{
    
    public float Speed = 10f;             // Velocidad de movimiento
    
    private Rigidbody2D rb;                  // Referencia al Rigidbody2D
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {                 
        Move();        
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * Speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        // Llamar al método para girar el jugador
        Flip(horizontalInput);
    }    
   
    private void Flip(float horizontalInput)
    {
        if (horizontalInput > 0f) // Moverse a la derecha
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Mirar a la derecha
        }
        else if (horizontalInput < 0f) // Moverse a la izquierda
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Mirar a la izquierda
        }
    }
}
