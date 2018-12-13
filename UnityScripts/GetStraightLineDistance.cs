using UnityEngine;
using System.Collections;

public class GetStraightLineDistance: MonoBehaviour
{
    public string axisx;
    public string axisy;
    public string axisz;

	// Use this for initialization
	void Start ()
    {
        double S1;
        double S2;
        double S3;             // creating folders for number
        double d;
        string str;


        str = (axisx);
        S1 = double.Parse(str);

        str = (axisy);
        S2 = double.Parse(str);             // converts inputed string to a double and stores in folder 

        str = (axisz);
        S3 = double.Parse(str);

        if (S3 == 0)
        {
            d = System.Math.Sqrt(S1 * S1 + S2 * S2); // if only 2 inputs and z is put at 0 then it will work out Pythagorean Theorem in 2D
        }
        else
        {
            d = System.Math.Sqrt(S1 * S1 + S2 * S2 + S3 * S3);     //uses Pythagorean Theorem to work out distance in 3D      
        }
        Debug.Log("Distance is " + d);       // Displays answer to user 
    }



	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
