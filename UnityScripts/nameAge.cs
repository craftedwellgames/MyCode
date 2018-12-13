using UnityEngine;
using System.Collections;

public class nameAge : MonoBehaviour
{
   new public string name;
    public int age;

	// Use this for initialization
	void Start ()
    {

        string nameAge =(name + age); // creates a file to put user inputed name and age in
        

        Debug.Log("hello I am " + name + " and I am " + age + " years old"); // brings name and age out of file and displays it on the console 
                                                                                                                               
    }

	// Update is called once per frame
	void Update ()
    {
	
	}
}
