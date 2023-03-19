using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectPortal : MonoBehaviour
{
    public bool canBeUsed = false;
    public GameObject icon;
    public GameObject portalAudioObj;

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
            BlackOut.instance.gameObject.GetComponent<Animator>().Play("GoBackBlackOut");
            //Particles
            //Sound
            Instantiate(portalAudioObj, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
