using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        items.Add(item);
        Debug.Log("Item added: " + item.name);
    }

    public void RemoveItem(GameObject item)
    {
        items.Remove(item);
        Debug.Log("Item removed: " + item.name);
    }

    public List<GameObject> GetItems()
    {
        return items;
    }
}