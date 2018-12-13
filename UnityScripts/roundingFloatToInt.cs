using UnityEngine;
using System.Collections;

public class roundingFloatToInt : MonoBehaviour
{
    public double number;
	// Use this for initialization
	void Start ()
    {
        double z = number;    // Creates a file called (z) and puts the float number inside 
        int a = (int)System.Math.Round(z);    // creates a new file (a), then rounds the number in (z) file and stores it in (a)
        Debug.Log(a);           // takes number from file (a) and displays it on the console
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
