using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script shoots the ray to detect interactable objects.
// Also changes the cursor when ray is hitting an interactable object.

public class InteractRaycast : MonoBehaviour
{

    Interactable interactable = null;

    Collider currentCollider = null;

    public bool isKeyHeld = false;

    public RaycastHit hit;

    [Header("Raycast Parameters")]
    [SerializeField] private float rayLength = 0.5f;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string exludeLayerName = null;

    [Header("Key Codes")]
    // Mouse button to interact with doors
    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;
    // Button to interact with level changers (open doors etc)
    [SerializeField] private KeyCode levelChangeKey = KeyCode.Mouse0;

    public LevelControl levelSwitcher;

    [Header("UI Parameters")]
    public GameObject cursorNormal = null;
    public GameObject cursorInteract = null;

    // Tags so the Raycast can tell what kind of object it has hit & which script to run
    private const string interactableTag = "InteractiveObject";
    private const string changeLevelTag = "ChangeLevelRaycatcher";
    private const string pickupableItemTag = "PickUpableObject";
    private const string doorRequiresItemTag = "ThisDoorRequiresAnItem";

    //Virtual method "Interact" from Brackeys item tutorial (RPG ep02)
    public virtual void Interact ()
    {
        // This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    // ************************************************************************
    // Start

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        cursorNormal.SetActive(true);
        cursorInteract.SetActive(false);
    }
    // ************************************************************************
    // Update is called once per frame

    void Update()
    {
        // RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            // If ray hits object on layer "Interact"
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Interact"))
            {
                cursorNormal.SetActive(false);
                cursorInteract.SetActive(true);

                // at the moment this isn't working because interactable will
                // never get reset to null after 
                if (currentCollider != hit.collider)
                {

                    interactable = hit.collider.gameObject.GetComponent<Interactable>();
                    //Debug.Log("Got component <Interactable>");

                }

                currentCollider = hit.collider;

                if (Input.GetKeyDown(openDoorKey))
                {
                    interactable.Interact();
                }

            }

            //// Interacts with levelcontroller to change level
            //if (hit.collider.CompareTag(changeLevelTag))
            //{
            //    cursorNormal.SetActive(false);
            //    cursorInteract.SetActive(true);

            //    if (!isAlreadyCollided)
            //    {
            //        levelSwitcher = hit.collider.gameObject.GetComponent<LevelControl>();
            //    }

            //    isAlreadyCollided = true;

            //    if (Input.GetKeyDown(levelChangeKey))
            //    {
            //        levelSwitcher.ChangeLevel();
            //    }
            //}

            // Interacts with items to pickup to inventory
            //if (hit.collider.CompareTag(pickupableItemTag))
            //{
            //    cursorNormal.SetActive(false);
            //    cursorInteract.SetActive(true);
            //}
        }
        else
        {
            cursorNormal.SetActive(true);
            cursorInteract.SetActive(false);
        }
    }
}