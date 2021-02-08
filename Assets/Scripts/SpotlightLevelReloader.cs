using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Lighthouse;

public class SpotlightLevelReloader : MonoBehaviour
{

    private bool isPlayerInLightBeam;
    private bool isTimerStarted;
    private float timeUntilDeath;
    

    // Start is called before the first frame update
    void Start()
    {
        timeUntilDeath = 5f;
        //isPlayerInLightBeam = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerInLightBeam = true;
        //isTimerStarted = false;
        timeUntilDeath = 5f;
        Debug.Log("Player entered spotlight collider");
        Debug.Log("Death timer stopped & reset");
    }

    private void OnTriggerExit(Collider other)
    {
            isPlayerInLightBeam = false;
            //isTimerStarted = true;
            Debug.Log("Player exited spotlight collider");
    }

    // Update is called once per frame
    void Update()
    {
        // sets a timer running if the player steps out of cone light beam collider
        if (!isPlayerInLightBeam)
        //Debug.Log("Player is not in collider");
        {
            //if (!isTimerStarted)
            //{
                timeUntilDeath -= Time.deltaTime;
                // Debug.Log("You have " + timeUntilDeath + " seconds remaining until you die");
                Debug.Log("Death timer running");
            //}
        }

        // if the time-till-death timer reaches zero, the level will reload
        if(timeUntilDeath <= 0f)
        {
            Debug.Log("You died. Reloading level...");
            GetComponent<LevelControl>().ChangeLevel();

            ////////////////////////////////////////////////////////////////////
            //way of calling the above class.method that would make use of custom namespace:
            ////////////////////////////////////////////////////////////////////
            //LevelControl levelControl = new LevelControl();
            //levelControl.ChangeLevel();
        }
    }
}
