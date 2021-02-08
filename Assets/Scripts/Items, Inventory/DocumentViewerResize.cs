using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DocumentViewerResize : MonoBehaviour
{

    #region REGION: Can probably get rid of all this.
    //InventorySlot slot;
    //[SerializeField] UnityEngine.UI.Button itemSlotButton;

    // The image of the document
    //[SerializeField] GameObject documentImageGameObj;

    // Text-only alternate of the document
    //[SerializeField] GameObject documentTextGameObj;

    #endregion

    // The scrollview content area – changing the height of this will change
    // the height of the content, driven by the AspectRatioFitter component
    // (CHECK ASPECT RATIO FITTER IS ATTACHED TO ALL CHILD OBJECTS OF THE
    // CONTENT AREA)
    [SerializeField] private RectTransform contentArea;

    // This should never change. Clamps the max possible dims of the content
    // via the AspectRatioFitter.
    [SerializeField] float contentAreaConstantWidth = 545f;

    // By setting the content area to one of these heights will either allow the
    // content to fit to the contentAreaConstantWidth, or keep it constrained
    // by the height.
    [SerializeField] float contentAreaStandardHeight = 353f;
    [SerializeField] float contentAreaZoomedHeight = 800f;


    // Makes sure the zoom is set to Standard on Start
    private void Start()
    {
        ViewStandard();
        
    }

    // These methods are called from the button OnClick() editor in Unity:

    public void ViewStandard()
    {
        contentArea.sizeDelta = new Vector2(contentAreaConstantWidth, contentAreaStandardHeight);
    }

    public void ViewZoomed()
    {
        contentArea.sizeDelta = new Vector2(contentAreaConstantWidth, contentAreaZoomedHeight);
    }
}
