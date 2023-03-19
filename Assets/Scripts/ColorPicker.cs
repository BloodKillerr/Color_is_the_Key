using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public bool canBeUsed = false;
    public MeshRenderer mr;
    public GameObject icon;
    public GameObject pickAudioObj;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
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
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().material.color == MaterialHolder.instance.materials[6].color)
            {
                Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = true;
            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().material = mr.material;

            //Particles
            //Sound
            Instantiate(pickAudioObj, transform.position, Quaternion.identity);
        }
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && canBeUsed)
        {
            if (other.GetComponent<MeshRenderer>().material.color == MaterialHolder.instance.materials[6].color)
            {
                Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = true;
            }
            other.GetComponent<MeshRenderer>().material = mr.material;

            //Particles
            //Sound
            Instantiate(pickAudioObj, transform.position, Quaternion.identity);
        }
    }
    */
}
