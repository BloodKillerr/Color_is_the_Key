using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorContainer : MonoBehaviour
{
    public Material[] desired;
    public Material[] put;
    public GameObject[] colorHolders;
    public GameObject putAudioObj;
    public GameObject rightAudioObj;
    public GameObject wrongAudioObj;
    public bool isDone = false;
    int i = 0;

    public void Check()
    {
        for(int j=0; j<put.Length; j++)
        {
            if (desired[j].color != put[j].color)
            {
                ResetMats();
                Instantiate(wrongAudioObj, transform.position, Quaternion.identity);
                return;
            }
            else
            {
                continue;
            }
        }

        Debug.Log("Udało się!");
        //Particles
        //Sound
        Instantiate(rightAudioObj, transform.position, Quaternion.identity);
        //Animation
        isDone = true;
        MaterialHolder.instance.SpawnPortal();
    }

    public void ResetMats()
    {
        for(int k=0; k<put.Length; k++)
        {
            put[k] = MaterialHolder.instance.materials[6];
            colorHolders[k].GetComponent<MeshRenderer>().material = MaterialHolder.instance.materials[6];
        }

        i = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile") && i<put.Length)
        {
            put[i] = other.GetComponent<MeshRenderer>().material;
            colorHolders[i].GetComponent<MeshRenderer>().material = put[i];
            Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = true;
            i++;

            if(i == put.Length)
            {
                Check();
            }
            else
            {
                Instantiate(putAudioObj, transform.position, Quaternion.identity);
            }
        }
    }
}
