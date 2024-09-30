using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public string powerUpName;  // Name of the power-up, e.g., "Fireball", "Wood", etc.
    public abstract void Activate();  // Define this method in child classes for each power-up type

    public void Collect(Inventory inventory)
    {
        // When collected, add the power-up to the player's inventory
        inventory.AddPowerUp(gameObject, powerUpName);
    }
}
