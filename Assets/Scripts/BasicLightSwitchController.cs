using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLightSwitchController : Interactable
{

    public GameObject lightToTurnOn;
    public GameObject lightToTurnOn2;
    public GameObject lightToTurnOn3;
    public GameObject lightSwitch = null;
    public bool isLightToTurnOnActive;

    InteractRaycast interactRaycast;

#region Light Sequence
    // Comment this out for using with normal lights (whilst testing).
    // Eventually need to build in functionality whereby Interact checks
    // a tag on the light to see if it's part of a sequence or a discrete
    // light?
    private IEnumerator TurnOnLightSequenceCoroutine()
    {
        if (!isLightToTurnOnActive)
        {            
            lightToTurnOn.GetComponent<Light>().enabled = true;
            isLightToTurnOnActive = true;
            yield return new WaitForSeconds(2);
            lightToTurnOn2.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(1);
            lightToTurnOn3.GetComponent<Light>().enabled = true;
        }
        else
        {
            lightToTurnOn.GetComponent<Light>().enabled = false;
            isLightToTurnOnActive = false;
            // Debug.Log("Turned light off");
        }
    }

    public override void Interact()
    {
        // this is incorrect, we don't shoot the ray at the light itself, 
        // so this will throw a NullReferenceException as the ray
        // can't see the light & its tag currently
        if(interactRaycast.hit.collider.gameObject.layer == LayerMask.NameToLayer("LightInSequence"))
        {
            StartCoroutine(TurnOnLightSequenceCoroutine());
            Debug.Log("light sequence");
        }
        // same issue here
        if(interactRaycast.hit.collider.gameObject.layer == LayerMask.NameToLayer("LightStandalone"))
        {
            if (!isLightToTurnOnActive)
            {            
                lightToTurnOn.GetComponent<Light>().enabled = true;
                isLightToTurnOnActive = true;
            }
            else
            {
                lightToTurnOn.GetComponent<Light>().enabled = false;
                isLightToTurnOnActive = false;
            }
        }
        else
        {
            Debug.Log("Couldn't find a light to work with!");
        }

    }
    #endregion

    // Comment this out for testing the light sequence above
    #region Normal light Interact 
    /*
    public override void Interact()
    {


    }
    */
    #endregion


    // // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
