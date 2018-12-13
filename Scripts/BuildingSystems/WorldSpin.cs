using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpin : MonoBehaviour {

    public float spinSpeed;
    Ray r;
    RaycastHit rh;
    float rotationY = 140;
    public int leftRot;
    public int rightRot;
   


    public void OnMouseDrag()
    {
       
        r = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out rh, 100))
            {
                if (rh.collider.gameObject.tag == "world")
                {
               
                if (Input.GetMouseButton(0))
                    {
                    rotationY -= Input.GetAxis("Mouse X") * spinSpeed;
                    rotationY = Mathf.Clamp(rotationY, leftRot, rightRot);
                    transform.rotation = Quaternion.Euler(0f, rotationY, 0f); 
                    //new Vector3(transform.localEulerAngles.x, -rotationY, transform.localEulerAngles.z);
                      //  transform.Rotate(0, (Input.GetAxis("Mouse X") * spinSpeed * -Time.deltaTime), 0, Space.World);
                    }
                }
              
                    if (rh.collider.gameObject.tag == "Admiral")
                    {
                        if (Input.GetMouseButton(0))
                        {
                            transform.Rotate(0, (Input.GetAxis("Mouse X") * spinSpeed * -Time.deltaTime), 0, Space.World);
                            //can use this to trigger character animations when touched
                        }
                    }
                    if (rh.collider.gameObject.tag == "Hammer")
                    {
                        if (Input.GetMouseButton(0))
                        {
                            transform.Rotate(0, (Input.GetAxis("Mouse X") * spinSpeed * -Time.deltaTime), 0, Space.World);
                        }
                    }
            }
        
    }
}
