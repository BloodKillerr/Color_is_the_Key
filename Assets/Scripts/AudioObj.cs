using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObj : MonoBehaviour
{
    public float time = 1f;
    private void Start()
    {
        StartCoroutine(Wait(time));
    }

    public IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(x);
        Destroy(gameObject);
    }
}
