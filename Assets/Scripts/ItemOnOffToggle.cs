using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnOffToggle : MonoBehaviour
{
    public GameObject torch;
    public GameObject walkie;
    public string itemKey1;
    public string itemKey2;
    public bool isTorchOn;
    public bool isWalkieOn;

    public AudioSource torchSwitchAudio;
    public AudioSource walkieSwitchOnAudio;
    public AudioSource walkieSwitchOffAudio;

    // Start is called before the first frame update
    void Start()
    {
        isTorchOn = false;
        isWalkieOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(itemKey1))
        {
            if (isTorchOn == false)
            {
                torch.SetActive(true);
                isTorchOn = true;
                torchSwitchAudio.Play();
            }
            else
            {
                torch.SetActive(false);
                isTorchOn = false;
                if (Input.GetKeyUp(itemKey1))
                {
                    torchSwitchAudio.Play();
                }

            }

            if (Input.GetKeyUp(itemKey2))
            {

            }
        }



    }
}
