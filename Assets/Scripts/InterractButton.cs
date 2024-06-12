using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractButton : MonoBehaviour
{
    private Collider buttonCollider;
    private GameObject millChuck;
    private void Awake()
    {
        buttonCollider = GetComponent<Collider>();
        millChuck = GameObject.Find("Mill_chuck");
    }

    private void Update()
    {
        if (buttonCollider.bounds.Contains(Camera.main.transform.position))
        {
            RotateMillChuck();
        }
    }

    private void RotateMillChuck()
    {
        //Vector3 newPosition = millChuck.transform.position + new Vector3(0, 0, 0.05f);
        millChuck.transform.Rotate(new Vector3(0, 0, 2f));
    }
}
