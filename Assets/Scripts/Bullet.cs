using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject audioObj;
    public GameObject effect;

    private void Start()
    {
        effect.GetComponent<ParticleSystemRenderer>().material = GetComponent<MeshRenderer>().material;
        Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Instantiate(audioObj, transform.position, Quaternion.identity);
    }
}
