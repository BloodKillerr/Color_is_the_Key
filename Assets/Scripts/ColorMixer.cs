using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixer : MonoBehaviour
{
    public Material[] put;
    public GameObject picker;
    public GameObject pickerCords;
    public GameObject[] colorHolders;
    public GameObject putAudioObj;
    public GameObject rightAudioObj;
    public GameObject wrongAudioObj;
    int i = 0;

    public void Check()
    {
        GameObject pickerCopy = Instantiate(picker);
        if ((put[0].color == MaterialHolder.instance.materials[0].color &&
            put[1].color == MaterialHolder.instance.materials[7].color) ||
            (put[0].color == MaterialHolder.instance.materials[7].color &&
            put[1].color == MaterialHolder.instance.materials[0].color))
        {
            pickerCopy.GetComponent<ColorPicker>().mr.material = MaterialHolder.instance.materials[5];
        }
        else if ((put[0].color == MaterialHolder.instance.materials[3].color &&
            put[1].color == MaterialHolder.instance.materials[4].color) ||
            (put[0].color == MaterialHolder.instance.materials[4].color &&
            put[1].color == MaterialHolder.instance.materials[3].color))
        {
            pickerCopy.GetComponent<ColorPicker>().mr.material = MaterialHolder.instance.materials[1];
        }
        else if ((put[0].color == MaterialHolder.instance.materials[0].color &&
            put[1].color == MaterialHolder.instance.materials[3].color) ||
            (put[0].color == MaterialHolder.instance.materials[3].color &&
            put[1].color == MaterialHolder.instance.materials[0].color))
        {
            pickerCopy.GetComponent<ColorPicker>().mr.material = MaterialHolder.instance.materials[2];
        }
        else
        {
            ResetMats();
            Instantiate(wrongAudioObj, transform.position, Quaternion.identity);
            Destroy(pickerCopy);
            return;
        }

        Instantiate(pickerCopy, pickerCords.transform.position, Quaternion.identity, pickerCords.transform);
        Instantiate(rightAudioObj, transform.position, Quaternion.identity);
        Destroy(pickerCopy);
        //Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = false;
    }

    public void ResetMats()
    {
        for (int k = 0; k < put.Length; k++)
        {
            put[k] = MaterialHolder.instance.materials[6];
            colorHolders[k].GetComponent<MeshRenderer>().material = MaterialHolder.instance.materials[6];
        }

        i = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile") && i < put.Length)
        {
            put[i] = other.GetComponent<MeshRenderer>().material;
            colorHolders[i].GetComponent<MeshRenderer>().material = put[i];
            Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = true;
            i++;

            if (i == put.Length)
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
