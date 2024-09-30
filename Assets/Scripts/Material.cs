using UnityEngine;

public abstract class Material : MonoBehaviour
{
    public string materialName;  // Name of the power-up, e.g., "Fireball", "Wood", etc.
    public void Collect(Inventory inventory)
    {
        // When collected, add the power-up to the player's inventory
        inventory.AddMaterial(gameObject, materialName);
    }
    public abstract void Activate();
}
