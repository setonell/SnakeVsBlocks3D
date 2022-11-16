using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    public Rigidbody Rb;

    public Vector3 PrevPosition;
     
    public float Smooth;
    public float Speed;

    public Transform Player;

    private void Start() => Rb = GetComponent<Rigidbody>();

    private void FixedUpdate()   
    {
        if (Input.GetMouseButton(0))
        {
            var delta = Input.mousePosition - PrevPosition;
            Rb.AddForce(new Vector3(delta.x, 0, 0) * Smooth * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        PrevPosition = Input.mousePosition;
        Rb.velocity = Vector3.forward * Speed * Time.fixedDeltaTime; 
    }
}
