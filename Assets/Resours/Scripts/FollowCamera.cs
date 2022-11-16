using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float Number;
    public float smooth = 5.0f;
    private void LateUpdate()
    {
        if(target != null)
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.MoveTowards(transform.position.z, target.position.z - Number, .5f));
    }
}
