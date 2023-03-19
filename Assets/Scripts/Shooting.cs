using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform point;

    public GameObject bullet;

    public GameObject shootAudioObj;

    public float force = 20f;

    private float cooldown = 0f;

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && cooldown <= 0f)
        {
            {
                if(gameObject.GetComponent<MeshRenderer>().material.color != MaterialHolder.instance.materials[6].color)
                {
                    Shoot();
                }
            }  
        }
    }

    public void Shoot()
    {
        GameObject bulletCopy = Instantiate(bullet, point.position, point.rotation);
        bulletCopy.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
        Rigidbody rb = bulletCopy.GetComponent<Rigidbody>();
        rb.AddForce(point.forward * force, ForceMode.Impulse);
        Instantiate(shootAudioObj, transform.position, Quaternion.identity);
        cooldown = .35f;
    }
}
