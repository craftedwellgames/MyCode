using UnityEngine;
using System.Collections;

public class square : MonoBehaviour
{
   public double number;
	
    // Use this for initialization
	void Start ()

    {
        object value = System.Math.Pow(number, 2);  // takes the number inputed and uses the power of 2 then stores it in value
        Debug.Log(value);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
