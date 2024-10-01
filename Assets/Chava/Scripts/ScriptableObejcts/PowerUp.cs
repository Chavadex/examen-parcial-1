using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPowerUp", menuName = "PowerUp")]
public class PowerUp : ScriptableObject
{
    public float swimSpeedModifier = 2.0f;  // Modificador de velocidad de nado
    public float walkSpeedModifier = 2.0f;  // Modificador de velocidad de caminar
    public float duration = 5.0f;           // Esto es cuanto dura el power-up en segundos
    public Sprite powerUpSprite;            // Sprite del power-up

    
    public void ApplyPowerUp(PlayerMovement player)
    {
        player.ModifySpeed(swimSpeedModifier, walkSpeedModifier, duration);
    }
}
