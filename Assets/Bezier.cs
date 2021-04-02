using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{


    [SerializeField]
    private Vector3[] controlPoints;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t = Mathf.PingPong(Time.time, 1);
        gameObject.transform.position = BezierPoint(controlPoints, t);
    }

    // https://www.gamasutra.com/blogs/VivekTank/20180806/323709/How_to_work_with_Bezier_Curve_in_Games_with_Unity.php has a good visual for this
    Vector3 BezierPoint(Vector3[] points, float t)
    {
        if (points.Length == 2) // base case: returns the exact point wanted
        {
            return Vector3.Lerp(points[0], points[1], t);
        }
        else
        {
            Vector3[] newPoints = new Vector3[points.Length - 1];
            for (int i = 0; i < points.Length - 1; i++)
            {
                newPoints[i] = Vector3.Lerp(points[i], points[i + 1], t); // construct a new array of Lerp points
            }
            return BezierPoint(newPoints, t); // recursion
        }
    }
}
