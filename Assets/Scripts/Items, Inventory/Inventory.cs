using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

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
        //}

        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
