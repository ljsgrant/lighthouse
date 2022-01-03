using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// This script manages inventory slots, updates the inventory slots when items are picked up etc

public class InventoryUI : MonoBehaviour
{
    public Transform documentSlotSpawnPoint;
    public Transform objectSlotSpawnPoint;
    public Transform keyItemSlotSpawnPoint;

    MenuObjectsManager menuObjectsManager;

    Vector3 scaleFactorOne = new Vector3(1, 1, 1);

    Object inventorySlotPrefab;
    GameObject newInventorySlotGO;

    public Item item { get; private set; }

    List<InventorySlot> slots = new List<InventorySlot>();

    Inventory inventory;

    ///////////////////////////////////////////////////////////////////////////
    // Start is called before the first frame update
    ///////////////////////////////////////////////////////////////////////////
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        //loads InventorySlot prefab from the Resources folder
        inventorySlotPrefab = Resources.Load("InventorySlot");

        menuObjectsManager = GetComponent<MenuObjectsManager>();

        //slots = inventorySlotSpawnPoint.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {

        ClearAllSlots();

        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (i < inventory.items.Count)
            {
                newInventorySlotGO = Instantiate(inventorySlotPrefab) as GameObject;
                Debug.Log("Instantiating item slot");

                InventorySlot slot = newInventorySlotGO.GetComponent<InventorySlot>();

                DocumentViewerSetImage documentViewerSetImage = slot.GetComponentInChildren<DocumentViewerSetImage>();
                Debug.Log(documentViewerSetImage);

                documentViewerSetImage.menuObjectsManager = menuObjectsManager;

                //Sets inventory slots to correct ScrollView parent depending on type:

                slot.AddItem(inventory.items[i]);
                slots.Add(slot);

                //Debug.Log("InventoryUI.cs: Item Type is " + slot.itemTypeIndex);

                if (slot.itemTypeIndex == 1)
                {
                    newInventorySlotGO.gameObject.transform.SetParent(objectSlotSpawnPoint);
                    //Debug.Log("InventoryUI.cs: Setting parent 1");
                    objectSlotSpawnPoint.localScale = scaleFactorOne;
                    slot.transform.localScale = scaleFactorOne; 
                    //Debug.Log("InventoryUI.cs: Setting localscale: " );

                }

                if (slot.itemTypeIndex == 2)
                {
                    newInventorySlotGO.gameObject.transform.SetParent(documentSlotSpawnPoint);
                    //Debug.Log("Setting parent 2");
                    documentSlotSpawnPoint.localScale = scaleFactorOne;
                    slot.transform.localScale = scaleFactorOne;
                    //Debug.Log("InventoryUI.cs: Setting localscale");                    
                }

                if (slot.itemTypeIndex == 3)
                {
                    newInventorySlotGO.gameObject.transform.SetParent(keyItemSlotSpawnPoint);
                    //Debug.Log("Setting parent 3");
                    keyItemSlotSpawnPoint.localScale = scaleFactorOne;
                    slot.transform.localScale = scaleFactorOne;
                    //Debug.Log("InventoryUI.cs: Setting localscale");                    
                }

            }

            else
            {
                slots[i].ClearSlot();
                //Debug.Log("InventoryUI: For loop ClearSlot");

                //Destroy(newInventorySlotGO);
                //Debug.Log("Destroying item slot instance");
            }
        }

#region Check inventory for item name
// Checks each inventory slot for specified item name, and prints a message to the console if found.
// Next should make it that the item to check for can be specified in the editor,
// and make it so that the result affects whether or not an action happens (i.e. opening a door).
        foreach (InventorySlot slot in slots)
        {
            if (slot.itemName.text == "KeyItemPlaceholder") // rather than checking string, instead check if Item in slot is equal to Item dropped in via editor from project files.
            {
                Debug.Log("LOOK! Found a key item in the inventory!");
                break;
            }
        }
#endregion
    }

    void ClearAllSlots()
    {
        foreach (InventorySlot slot in slots)
        {
            Debug.Log("ClearAllSlots");
            Destroy(slot.gameObject);
            slot.ClearSlot();
        }

        slots = new List<InventorySlot>();
    }
}

/*
for (int i = 0; i < 3; i++)
{
    //Creates a new Item Slot instance
    newInventorySlotGO = Instantiate(inventorySlotPrefab, inventorySlotSpawnPoint, true);
    Debug.Log("Instantiating item slot");

    lastCreatedItemSlot = newInventorySlotGO;

    Debug.Log("lastCreatedItemSlot contains " + lastCreatedItemSlot);
}
*/