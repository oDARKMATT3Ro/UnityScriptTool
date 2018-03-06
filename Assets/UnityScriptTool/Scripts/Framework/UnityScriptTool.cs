using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomDataStructure {
    public string name;
    public GameObject target;
    public Vector3 position;
}

public class UnityScriptTool : MonoBehaviour {

    [Header("Attributes")]
    [Tooltip("This is the start position for the gameObject.")]
    public Vector3 startPos;
    [Tooltip("This is the speed of the gameObject.")]
    [Range(0f, 100f)]
    public float speed;
    [Tooltip("This is what the gameObject should follow.")]
    public Target target;
    [Tooltip("This is a list of custom targets.")]
    public CustomDataStructure[] customTargets;

    [Header("Dialog")]
    [Tooltip("This is the current dialog message for the gameObject.")]
    public string dialog;
    [Tooltip("This is the list of dialog messages for the gameObject.")]
    public List<string> dialogList;

    [Header("Array Tests")]
    public int[] numbers;
    public Vector3[] positions;
    public GameObject[] targets;



    [HideInInspector]
    public Dictionary<string, Vector3> childPositions;
    public int life { get; set; }


    // Use this for initialization
    void Start() {
        
    }

    void Update() {
        if (life <= 0) {
            kill();
        }
    }

    void kill() {
        Destroy(gameObject);
    }

}
