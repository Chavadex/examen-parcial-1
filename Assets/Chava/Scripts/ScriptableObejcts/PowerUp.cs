using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPowerUp", menuName = "PowerUp")]
public class PowerUp : ScriptableObject
{
    public float swimSpeedModifier = 2.0f;  
    public float walkSpeedModifier = 2.0f; 
    public float duration = 5.0f;           
    public Sprite powerUpSprite;            

    
    public void ApplyPowerUp(PlayerMovement player)
    {
        player.ModifySpeed(swimSpeedModifier, walkSpeedModifier, duration);
    }



}
