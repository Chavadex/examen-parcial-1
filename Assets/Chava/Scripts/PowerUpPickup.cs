using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    [SerializeField] private PowerUp speedPowerUp; 
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Si hay un sprite definido en el Scriptable Object, asignarlo al SpriteRenderer del objeto
        if (speedPowerUp.powerUpSprite != null)
        {
            spriteRenderer.sprite = speedPowerUp.powerUpSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null)
        {
            // Aplica el power-up al jugador
            speedPowerUp.ApplyPowerUp(player);

            // Destruir el objeto power-up después de recogerlo
            Destroy(gameObject);
        }
    }
}
