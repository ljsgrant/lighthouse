using UnityEngine;
using System.Collections;

public class BasicDoorController : Interactable
{
    InventoryUI inventoryUI;
    Inventory inventory;

    private Animator doorAnim;
    private bool doorOpen = false;

    public GameObject menuManager = null;

    // public GameObject thisDoorOpensFor;
    public bool isItemPresentInInventory = false;

    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "DoorOpen";
    [SerializeField] private string closeAnimationName = "DoorClose";

    [Header("Pause Timer")]
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    void Start()
    {
        inventoryUI = menuManager.GetComponent<InventoryUI>();
    }

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;

    }

    public void PlayAnimation()
    {
        if (!doorOpen && !pauseInteraction)
        {
            doorAnim.Play(openAnimationName, 0, 0.0f);
            doorOpen = true;
            StartCoroutine(PauseDoorInteraction());
        }

        else if(doorOpen && !pauseInteraction)
        {
            doorAnim.Play(closeAnimationName, 0, 0.0f);
            doorOpen = false;
            StartCoroutine(PauseDoorInteraction());
        }
    }

// Is passed into Interact; contents are executed when Interact is called

    public override void Interact() // from Interactable
    {

        #region Check inventory for item name
       
        // Checks each inventory slot for specified item name, and prints a message to the console if found.
        // Next should make it that the item to check for can be specified in the editor,

        // if(inventory.items.Count > 0)
        // {
            foreach (InventorySlot slot in inventoryUI.slots)
            {
                if (slot.itemName.text == "KeyItemPlaceholder") // CHANGE THIS: rather than checking string, instead check if Item in slot is equal to Item dropped in via editor from project files.
                {
                    isItemPresentInInventory = true;
                    Debug.Log("Used the key in the door. (isItemPresentInInventory set to true)");
                    break;
                }
                else
                {
                    isItemPresentInInventory = false;
                    Debug.Log("This door needs a key. (isItemPresentInInventory set to false)");
                }
            }

            if (isItemPresentInInventory == true)
            {
                PlayAnimation();
                Debug.Log("Play door animation");
            }
        // }
        // else
        // {
        //     isItemPresentInInventory = false;
        //     Debug.Log("This door needs a key. (isItemPresentInInventory set to false)");
        // }
        #endregion
    }
}
