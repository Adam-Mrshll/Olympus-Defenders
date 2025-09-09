using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public static Transform[] points;

    void Awake() // Awake is called when the script instance is being loaded    
    { 
        points = new Transform[transform.childCount]; // C# is case-sensitive

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i); // C# is case-sensitive
        }
    }
}