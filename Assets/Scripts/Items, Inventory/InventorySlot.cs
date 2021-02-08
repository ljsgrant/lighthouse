using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;

    public Image icon;
    public GameObject itemSlotButton;
    public Text itemName;
    public Text itemDescription;
    public int itemTypeIndex;

    public RawImage imageOfItem;

    public void AddItem(Item newItem)
    {
        item = newItem;

        itemSlotButton.SetActive(true);

        icon.sprite = item.icon;
        icon.enabled = true;

        itemName.enabled = true;
        itemName.text = item.name;

        itemDescription.enabled = true;
        itemDescription.text = item.itemDescription;

        itemTypeIndex = (int) item.itemType;
        //Debug.Log("InventorySlot.cs: itemTypeIndex = " + itemTypeIndex);

        imageOfItem = item.imageOfItem;
        Debug.Log("InventorySlot.cs: Image of item set to: " + imageOfItem);
    }

    public void ClearSlot()
    {
        item = null;

        itemSlotButton.SetActive(false);

        icon.sprite = null;
        icon.enabled = false;

        itemName.enabled = false;
        itemName.text = null;

        itemDescription.enabled = false;
        itemDescription.text = null;

        imageOfItem = null;
    }
}
