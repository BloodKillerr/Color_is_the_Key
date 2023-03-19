using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Mute : MonoBehaviour
{
    public bool canBeUsed = false;
    public bool isMute = false;
    public AudioMixer mainMixer;
    public GameObject icon;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Volume"))
        {
            if(PlayerPrefs.GetFloat("Volume")==0f)
            {
                isMute = false;
                mainMixer.SetFloat("Volume", 0f);
            }
            else if(PlayerPrefs.GetFloat("Volume")==-80f)
            {
                isMute = true;
                mainMixer.SetFloat("Volume", -80f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Show icon; 
            icon.SetActive(true);
            canBeUsed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Show icon; 
            icon.SetActive(false);
            canBeUsed = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canBeUsed)
        {
            if (!isMute)
            {
                mainMixer.SetFloat("Volume", -80f);
                PlayerPrefs.SetFloat("Volume", -80f);
            }
            else
            {
                mainMixer.SetFloat("Volume", 0f);
                PlayerPrefs.SetFloat("Volume", 0f);
            }
            isMute = !isMute;
            PlayerPrefs.Save();
        }
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && canBeUsed)
        {
            if(!isMute)
            {
                mainMixer.SetFloat("Volume", -80f);
                PlayerPrefs.SetFloat("Volume", -80f);
            }
            else
            {
                mainMixer.SetFloat("Volume", 0f);
                PlayerPrefs.SetFloat("Volume", 0f);
            }
            isMute = !isMute;
            PlayerPrefs.Save();
        }
    }
    */
}
