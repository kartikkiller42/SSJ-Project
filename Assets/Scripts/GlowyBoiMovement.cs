using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script taken from https://answers.unity.com/questions/447663/rotate-object-around-other-object-or-circle-using.html
public class GlowyBoiMovement : MonoBehaviour
{
    public Transform target;
    public float fRadius = 1.0f;

    void Update () 
    {
        Vector3 v3Pos = Camera.main.WorldToScreenPoint (target.position);
        v3Pos = Input.mousePosition - v3Pos;
        float angle = Mathf.Atan2 (v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
        v3Pos = Quaternion.AngleAxis (angle, Vector3.forward) * (Vector3.right * fRadius);
        transform.position = target.position + v3Pos;
    }
}
