using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    [Header("Set the Item scriptableobj relating to this GFX object here:")]
    public Item item;

    public override void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        //Debug.Log("ItemPickup.cs: Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }

}
