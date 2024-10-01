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
            
            speedPowerUp.ApplyPowerUp(player);

           
            Destroy(gameObject);
        }
    }
}
