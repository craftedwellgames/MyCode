using UnityEngine;
using System.Collections;

public class Add : MonoBehaviour
{
    public int number1;
    public int number2;

    // Use this for initialization
    void Start()
    {

        int Add = (number1 + number2);   // adds user inputed number1 and number2 together

        int answer;          //makes a file called answer

        answer = number1 + number2; // puts the answer into the answer file

        Debug.Log(answer);  // takes answer out of file and prints it on the console
        
    }
        
	// Update is called once per frame
	void Update ()
    {
	
	}
}
