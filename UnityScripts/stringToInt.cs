using UnityEngine;
using System.Collections;

public class stringToInt : MonoBehaviour
{
    public string number;
    
    // Use this for initialization
    void Start()
    {
        string text = number;    // registering input from user
        int num;
        bool res = int.TryParse(text, out num);   // checking if input was a number
        if (res == false)  // if the result shows false print this
        {
            Debug.Log("please put in an integer or float"); // String is not a number.
        }
        else  // if result is true print this
        {
            Debug.Log(num);       // string is a number
        }
       

       





    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
