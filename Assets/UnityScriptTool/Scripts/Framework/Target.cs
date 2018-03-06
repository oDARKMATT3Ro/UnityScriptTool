using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    [Header("Attributes")]
    [Tooltip("This is the start position for the gameObject.")]
    public Vector3 startPos;
    [Tooltip("This is the speed of the gameObject.")]
    [Range(0f, 100f)]
    public float speed;

}
