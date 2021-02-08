using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script should sit on EVERY INVENTORYSLOT Prefab. The GetComponentInParent
 * below should look then look for the imageOfItem in its parent object, InventorySlot.
 * 
 */

public class DocumentViewerSetImage : MonoBehaviour
{
    [HideInInspector]
    public MenuObjectsManager menuObjectsManager;

    //InventorySlot inventorySlot;

    [SerializeField]
    RawImage documentImageRawImage;

    //[SerializeField] Text documentTextBody;

    public GameObject inventory;
    public GameObject documentViewer;

    public void SetImageFromInventorySlot()
    {
        // Set references to inventory and documentViewer via menuObjectsManager
        Debug.Log(menuObjectsManager);
        inventory = menuObjectsManager.inventory;
        Debug.Log("Found object: " + inventory);
        documentViewer = menuObjectsManager.documentViewer;
        Debug.Log("Found object: " + documentViewer);

        // Set the document image to the one sitting on the current inventoryslot
        documentImageRawImage = GetComponentInParent<InventorySlot>().imageOfItem;
        Debug.Log(documentImageRawImage);

        documentViewer.SetActive(true);

        RawImage image = documentViewer.GetComponentInChildren<RawImage>();
        Debug.Log(image);
        Debug.Log(image.texture);

        image.texture = documentImageRawImage.texture;


        //inventory.SetActive(false);
    }

    public void CloseDocumentViewer()
    {

    }
}
