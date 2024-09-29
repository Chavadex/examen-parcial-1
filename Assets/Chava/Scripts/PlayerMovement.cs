using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;
    private bool facingRight = true;
    public bool canMove = true;
    [SerializeField] private float timeStop;
    [SerializeField] private float pushForce;

    [Header ("Valores Movimiento Nadando")]
    [SerializeField] private float upSpeed;
    [SerializeField] private float downSpeed;
    [SerializeField] private float swimSpeed = 2.0f;
    [SerializeField] private float swimAcceleration = 1.0f;
    [SerializeField] private float floatDownSpeed = 1.0f;

    [Header("Valores Movmiento Caminando")]

    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayLength;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;


    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            if (!isGrounded)
            {
                Swim();
            }
            else
            {
                Walk();
            }

            Swim();
            FlipCharacter();
        }
        CheckIfGrounded();
    }

    private void Swim()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * swimSpeed, rb.velocity.y);
        rb.velocity = Vector2.Lerp(rb.velocity, movement, swimAcceleration * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, upSpeed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -downSpeed);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -floatDownSpeed);
        }
    }

    private void Walk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (horizontalInput > 0) // Mover a la derecha
        {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }
        else if (horizontalInput < 0) // Mover a la izquierda
        {
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
        }
        else // Dejar de moverse
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void FlipCharacter()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");

        
        if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }
        
        else if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
     
        facingRight = !facingRight;

        
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void CheckIfGrounded()
    {
        // Posición desde donde lanzaremos el raycast (justo debajo del personaje)
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y);

        // Longitud del rayo (ajusta según el tamaño del personaje)
        //float rayLength = 0.5f;

        // Lanzar el raycast hacia abajo
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);

        // Verificar si el raycast golpea algo en la capa "Piso"
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Para visualizar el raycast en la escena
        Debug.DrawRay(rayOrigin, Vector2.down * rayLength, Color.red);
    }

    public void ModifySpeed(float newSwimSpeed, float newWalkSpeed, float duration)
    {
        StartCoroutine(ApplySpeedModifier(newSwimSpeed, newWalkSpeed, duration));
    }

    private IEnumerator ApplySpeedModifier(float newSwimSpeed, float newWalkSpeed, float duration)
    {
        float originalSwimSpeed = swimSpeed;
        float originalWalkSpeed = walkSpeed;

        // Cambiar las velocidades
        swimSpeed = newSwimSpeed;
        walkSpeed = newWalkSpeed;

        // Esperar la duración del power-up
        yield return new WaitForSeconds(duration);

        // Restaurar las velocidades originales
        swimSpeed = originalSwimSpeed;
        walkSpeed = originalWalkSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {

            Vector2 collisionNormal = collision.contacts[0].normal;

            // Aplicar un empuje en la dirección contraria al choque
            ApplyPushback(collisionNormal);
            StartCoroutine(StopMoving());
        }
    }

    private void ApplyPushback(Vector2 collisionNormal)
    {
        Debug.Log("Esta chocando");
        // Puedes ajustar este valor según la fuerza que quieras aplicar
        rb.velocity = collisionNormal * pushForce;  // Empuje en la dirección contraria al choque
    }

    private IEnumerator StopMoving()
    {
        canMove = false;
        yield return new WaitForSeconds(timeStop);
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EndLevel"))
        {
            gameManager.NextStage();
        }
    }
}
