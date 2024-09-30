using UnityEngine;

public class FirePowerUp : PowerUp
{
    public GameObject firePrefab;  // Prefab for the fireball projectile

    public override void Activate()
    {
        // Logic to launch the fireball or give the player fireball ability
        Debug.Log("Fire PowerUp Activated!");
        // You could instantiate the fireball here or give the player fireball abilities
    }
}
