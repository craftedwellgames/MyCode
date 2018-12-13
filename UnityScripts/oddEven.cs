using UnityEngine;
using System.Collections;

public class oddEven: MonoBehaviour
{
    public int number;


    // Use this for initialization
    void Start()
    {
        
        if (number % 2 == 0)  // divides the number by 2 all the way to 0 to see if even or not 
        
        {
            Debug.Log ("is even");  //is even
        }
        else
        {
            Debug.Log ("is odd");//is odd
        }


    }
	// Update is called once per frame
	void Update ()
    {
	
	}
}
