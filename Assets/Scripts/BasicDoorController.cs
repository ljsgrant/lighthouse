using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicDoorController : Interactable
{
    InventoryUI inventoryUI;
    Inventory inventory;

    private Animator doorAnim;
    private bool isDoorOpen = false;

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
        if (!isDoorOpen && !pauseInteraction)
        {
            doorAnim.Play(openAnimationName, 0, 0.0f);
            isDoorOpen = true;
            StartCoroutine(PauseDoorInteraction());
        }

        else if(isDoorOpen && !pauseInteraction)
        {
            doorAnim.Play(closeAnimationName, 0, 0.0f);
            isDoorOpen = false;
            StartCoroutine(PauseDoorInteraction());
        }
    }

    private IEnumerator SearchInventoryCoroutine()
    {
        //We use this to control length of pause before PlayerCharacterText disappears.
        // Eventually perhaps we should automate the length of this WaitForSeconds
        // depending on number of words in string passed into playerCharacterText.text?
        yield return new WaitForSeconds(2);
        playerCharacterText.text = null;
    }

    public override void Interact() // from Interactable
    {
        #region Check inventory for item name
       
        // Checks each inventory slot for specified item name, 
        // and prints a message to the console if found.

        foreach (InventorySlot slot in inventoryUI.slots)
        {
            // if (slot.itemName.text == thisDoorOpensFor) 
            if (Equals(slot.itemName.text, thisDoorOpensFor.name))
            {
                // playerCharacterTextGameObject = new MenuController.playerCharacterTextGameObject<GameObject>();
                isItemPresentInInventory = true; 
                Debug.Log("isItemPresentInInventory = true)");
                // playerCharacterTextGameObject.SetActive(true);
                if(!isDoorOpen)
                {
                    playerCharacterText.text = textToDisplayIfUnlocked;
                    StartCoroutine(SearchInventoryCoroutine());
                }
                else
                {
                    playerCharacterText.text = null;
                }
                break;
            }
            else
            {
                isItemPresentInInventory = false; 
                Debug.Log("isItemPresentInInventory = false)");
                playerCharacterText.text = textToDisplayIfLocked;
                StartCoroutine(SearchInventoryCoroutine());
            }
        }

        if (isItemPresentInInventory == true)
        {
            PlayAnimation();
        }

        #endregion
    }
}
