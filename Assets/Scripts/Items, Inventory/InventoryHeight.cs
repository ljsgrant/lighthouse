using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHeight : MonoBehaviour
{
    Inventory inventory;

    public RectTransform inventoryDimensions;
    private const float inventoryDefaultHeight = 302.4f;
    public float inventoryHeight;

    // This is the number of items currently in the inventory, not its dimensions!
    public int inventorySize;

    void Start()
    {
        inventory = Inventory.instance;

        // passes method "Resize Inventory" to onItemChanged delegate method
        inventory.onItemChangedCallback += ResizeInventory;

        //Sets the integer "inventorySize" equal to items.Count (from class "Inventory")
        inventorySize = inventory.items.Count;

        //sets the RectTransform "inventoryDimensions" height equal to inventoryDefaultHeight
        inventoryDimensions.sizeDelta = new Vector2(0, inventoryDefaultHeight);
    }


    // Called from InventorySlot.AddItem and InventorySlot.ClearSlot methods
    public void ResizeInventory()
    {
        //Debug.Log("InventoryHeight.cs: Resizing Inventory");

        //Sets the integer "inventorySize" equal to items.Count from class "Inventory"
        inventorySize = inventory.items.Count;

        if (inventorySize > 6)
        {
            //if (inventoryHeight >= inventoryDefaultHeight)
            //{
                inventoryHeight = (50.4f * inventorySize) + 15;
            //}

            //inventoryHeight = inventoryDefaultHeight + 50.4f;

            inventoryDimensions.sizeDelta = new Vector2(0, inventoryHeight);
            Debug.Log("InventoryHeight.cs: inventoryHeight set to " + inventoryHeight);

        }
    }
}


