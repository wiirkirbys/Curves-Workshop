using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField]
    public GameObject centerObject;
    [SerializeField]
    public bool isRotate = false;
    [SerializeField]
    float xTarget = 0f, yTarget = 0f, zTarget = 0f;
    public float speed = 3;
    private Vector3 rotation;
    private float distance;
   
    private Rigidbody orbiter;
    // Start is called before the first frame update
    void Start()
    {
        orbiter = gameObject.GetComponent<Rigidbody>();
        rotation = new Vector3(xTarget, yTarget, zTarget); //will rotate towards the stated vector relative to center
        distance = Vector3.Distance(gameObject.transform.position, centerObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posToMidLine = Vector3.Normalize(gameObject.transform.position - centerObject.transform.position);
        Vector3.OrthoNormalize(ref posToMidLine, ref rotation);
        orbiter.velocity = rotation * speed;
        if(isRotate)
        {
            gameObject.transform.LookAt(gameObject.transform.position + orbiter.velocity, posToMidLine); // bottom will face towards the center point
        }
        if (Vector3.Distance(gameObject.transform.position, centerObject.transform.position) > distance)
        {
            gameObject.transform.position += (Vector3.Distance(gameObject.transform.position, centerObject.transform.position) - distance) * -Vector3.Normalize(gameObject.transform.position - centerObject.transform.position);
        }
    }

}
