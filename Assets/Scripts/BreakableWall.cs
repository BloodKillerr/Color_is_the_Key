using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public MeshRenderer mr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            if(other.GetComponent<MeshRenderer>().material.color == mr.material.color)
            {
                Destroy(gameObject);
            }
        }
    }
}
