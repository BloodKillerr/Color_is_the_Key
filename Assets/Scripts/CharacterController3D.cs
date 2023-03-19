using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
    public float speed = 5f;

    private CharacterController cc;

    private Vector3 movement;

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();   
    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        cc.Move(movement * speed * Time.deltaTime);

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
