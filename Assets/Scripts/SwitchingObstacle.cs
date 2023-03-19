using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingObstacle : MonoBehaviour
{
    public Material[] materials;
    private int i = 0;
    public MeshRenderer mr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (other.GetComponent<MeshRenderer>().material.color == mr.material.color)
            {
                if(i==materials.Length-1)
                {
                    Destroy(gameObject);
                    Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = false;
                    return;
                }
                else if(i==0)
                {
                    Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = true;
                }
                i++;
                mr.material = materials[i];
            }
        }
    }
}
