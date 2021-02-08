using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = null;
    public string itemDescription = null;
    public Sprite icon = null;
    public bool isCarriedTool = false;

    //creates drop-down for type of item
    public enum ItemType
    {
        Object = 1,
        Document = 2,
        Key = 3,
    }
    public ItemType itemType;

    // a nice full-res image of the document/object to show when player interacts with inventory slots
    [Header("Image for when the player clicks on item slot in inventory:")]
    public RawImage imageOfItem;

}
