using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inventory creates a list to hold items.
// Inventory is instantiated in Awake. It is a singleton & should not be instantiated more than once.

public class Inventory : MonoBehaviour
{

    #region Singleton

    public int inventorySpace = 20;

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    // This delegate method will execute any methods passed into it when it's Invoked (below).
    // Inventory is instantiated in InventoryUI Start method.
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    // Creates list to hold items.
    public List<Item> items = new List<Item>();

    /*
    public List<Item> objectInventory = new List<Item>();
    public List<Item> keyInventory = new List<Item>();
    */

    public bool Add (Item item)
    {

        #region Code for inventory size limit (NOT ACTIVE)
        /*
            if (!item.isCarriedTool) // currently not used - will allow to define item as default 'carried' item
            {
           
             //FROM BRACKEYS TUT, CURRENTLY NOT NEEDED AS INVENTORY IS INFINITE:
            if (items.Count >= inventorySpace)
            {
                Debug.Log("Not enough inventory space");
                return false;
            }
        */
        #endregion

        items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        

        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
