using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicDoorController : Interactable
{
    InventoryUI inventoryUI;
    Inventory inventory;

    private Animator doorAnim;
    private bool doorOpen = false;

    public GameObject menuManager = null;
    public ScriptableObject thisDoorOpensFor = null;
    bool isItemPresentInInventory = false;

    public Text playerCharacterText;
    public GameObject playerCharacterTextGameObject;
    public string textToDisplayIfLocked = "This door seems to be locked...";
    public string textToDisplayIfUnlocked = "Used the key in the lock.";

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

    public override void Interact() // from Interactable
    {
        #region Check inventory for item name
       
             // Checks each inventory slot for specified item name, and prints a message to the console if found.

            foreach (InventorySlot slot in inventoryUI.slots)
            {
                // if (slot.itemName.text == thisDoorOpensFor) 
                if (Equals(slot.itemName.text, thisDoorOpensFor.name))
                {
                    // playerCharacterTextGameObject = new MenuController.playerCharacterTextGameObject<GameObject>();
                    isItemPresentInInventory = true; 
                    Debug.Log("isItemPresentInInventory = true)");
                    // playerCharacterTextGameObject.SetActive(true);
                    playerCharacterText.text = textToDisplayIfUnlocked;
                    // Debug.Log("waiting for 5 secs");
                    // // yield return new WaitForSeconds(5);
                    // Debug.Log("...Done waiting");
                    break;
                }
                else
                {
                    isItemPresentInInventory = false; 
                    Debug.Log("isItemPresentInInventory = false)");
                    playerCharacterText.text = textToDisplayIfLocked;

                }
            }

            if (isItemPresentInInventory == true)
            {
                PlayAnimation();
            }

        #endregion
    }
}
