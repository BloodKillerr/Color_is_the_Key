using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public bool canBeUsed = false;
    public GameObject icon;
    public GameObject portalAudioObj;
    public GameObject effect;

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
            BlackOut.instance.gameObject.GetComponent<Animator>().Play("BlackOut");
            Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = false;
            //Particles
            //Sound
            Instantiate(portalAudioObj, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
