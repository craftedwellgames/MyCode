using UnityEngine;
using System.Collections;

public class PlayerLane : MonoBehaviour
{
    public GameObject rail1, rail2, rail3;
    public float speed = 5f;
    public float height = 1f;
    public int railOn = 2;
    Vector3 moveDirection = new Vector3(0, 0, 1);
    Vector3 startPos;
    Vector3 targetPos;


    Vector3 origPos;
    float origPosY;
    Vector3 jumpVec;
    bool heightReached = false;

    float jumpArcEndPos, leanEndPos, leanOrig, relativeLoc, relLocStart;
    public float halfDis;
    public float jumpArcSpeed = 0.1f;
    public float jumpArcHeight = 5f;

    public float jumpHeight = 5f;
    public bool jumped = false;

    public float distanceTo;
    public bool jumpPressed;
    public bool jumpedLeft;
    public bool moving = false;
    bool arcJumped = false;
    bool canMove = true, canLean = true;
    bool isLean, wasLean;

    // Use this for initialization
    void Start()
    {
		
        //setting the player at the start of the rail.
        Vector3 rail2StartZ = new Vector3(rail2.transform.position.x, height, rail2.transform.position.z - (rail2.GetComponent<Collider>().bounds.size.z * 0.5f));
        startPos = rail2StartZ;
        transform.position = rail2StartZ;
    }

    // Update is called once per frame
    void Update()
    {
		//print (rail1.GetComponent<Collider> ().bounds.size.z);

        gameObject.transform.Translate(moveDirection * speed * Time.deltaTime);
        relativeLoc = transform.position.x - relLocStart;



        
        
        //moving and leaning, no leaning on the middle lane 
        if (railOn == 2)
        {
            //moving
            if (Input.GetKey(KeyCode.A))
            {
                if (canMove == true)
                {
                    jumpedLeft = true;
                    distanceTo = Vector3.Distance(rail2.transform.position, rail1.transform.position);
                    moving = true;
                    arcJumped = true;
                    jumpArcEndPos = rail1.transform.position.x;
                    canMove = false;
                    railOn = 1;
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (canMove == true)
                {
                    jumpedLeft = false;
                    distanceTo = Vector3.Distance(rail2.transform.position, rail3.transform.position);
                    moving = true;
                    arcJumped = true;
                    jumpArcEndPos = rail3.transform.position.x;
                    canMove = false;
                    railOn = 3;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canMove == true)
                {
                    jumped = true;
                    canMove = false;
                    jumpPressed = true;
                }
            }
        }

        if (railOn == 1)
        {
            //Leaning
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (canLean == true)
                {
                    //leaning
                    leanOrig = rail1.transform.position.x;
                    leanEndPos = rail1.transform.position.x + -0.5f;
                    isLean = true;
                    canMove = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                //leaning
                isLean = false;
            }
            //moving
            if (Input.GetKey(KeyCode.D))
            {
                if (canMove == true)
                {
                    jumpedLeft = false;
                    distanceTo = Vector3.Distance(rail1.transform.position, rail2.transform.position);
                    moving = true;
                    arcJumped = true;
                    jumpArcEndPos = rail2.transform.position.x;
                    canMove = false;
                    railOn = 2;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canMove == true)
                {
                    jumped = true;
                    canMove = false;
                    jumpPressed = true;
                }
            }
        }

        if (railOn == 3)
        {
            //moving
            if (Input.GetKey(KeyCode.A))
            {
                if (canMove == true)
                {
					
                    jumpedLeft = true;
                    distanceTo = Vector3.Distance(rail3.transform.position, rail2.transform.position);
                    moving = true;
                    arcJumped = true;
                    jumpArcEndPos = rail2.transform.position.x;
                    canMove = false;
                    railOn = 2;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (canLean == true)
                {
                    leanOrig = rail3.transform.position.x;
                    leanEndPos = rail3.transform.position.x + 0.5f;
                    isLean = true;
                    canMove = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                isLean = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canMove == true)
                {
                    jumped = true;
                    canMove = false;
                    jumpPressed = true;
                }
            }
        }

        //Handles the movement between rails.
        if (moving == true)
        {
            if (arcJumped == true)
            {
                relLocStart = transform.position.x;
                relativeLoc = 0f;
                halfDis = distanceTo / 2;
                arcJumped = false;

            }

            Vector3 targetPos = Vector3.Lerp(transform.position, new Vector3(jumpArcEndPos, height, transform.position.z), jumpArcSpeed * Time.deltaTime);
            relativeLoc = Mathf.Abs(relLocStart - transform.position.x);

            if (jumpedLeft == true)
            {
                if (relativeLoc < halfDis)
                {
                    targetPos.y = Mathf.Lerp(targetPos.y, jumpArcHeight, (jumpArcSpeed * 2) * Time.deltaTime);
                    gameObject.transform.position = targetPos;
                    //move up
                }
                else if (relativeLoc >= halfDis)
                {
                    targetPos.y = Mathf.Lerp(targetPos.y, height, (jumpArcSpeed * 2) * Time.deltaTime);
                    gameObject.transform.position = targetPos;
                    //move down
                }
            }
            else if (jumpedLeft == false)
            {
                if (relativeLoc < halfDis)
                {
                    targetPos.y = Mathf.Lerp(targetPos.y, jumpArcHeight, (jumpArcSpeed * 2) * Time.deltaTime);
                    gameObject.transform.position = targetPos;
                    //move up
                }
                else if (relativeLoc >= halfDis)
                {
                    targetPos.y = Mathf.Lerp(targetPos.y, height, (jumpArcSpeed * 2) * Time.deltaTime);
                    gameObject.transform.position = targetPos;
                    //move down
                }
            }
            if (Mathf.Abs(transform.position.x - jumpArcEndPos) < 0.1f)
            {
                canMove = true;
                moving = false;
                transform.position = new Vector3(jumpArcEndPos, height, transform.position.z);
            }
        }


        //Leaning
        if (isLean == true)
        {
            //leanStartPos leanEndPos
            Vector3 leanPos = Vector3.Lerp(transform.position, new Vector3(leanEndPos, height, transform.position.z), jumpArcSpeed * Time.deltaTime);
            gameObject.transform.position = leanPos;
            wasLean = true;
        }
        else if (isLean == false)
        {
            if (wasLean == true)
            {
                Vector3 returnPos = Vector3.Lerp(transform.position, new Vector3(leanOrig, height, transform.position.z), jumpArcSpeed * Time.deltaTime);
                gameObject.transform.position = returnPos;

                if (Mathf.Abs(transform.position.x - leanOrig) < 0.03f)
                {
                    canMove = true;
                    wasLean = false;
                }
            }
        }


        //jumping
        if (jumped == true)
        {
            if (jumpPressed == true)
            {
                heightReached = false;
                origPosY = transform.position.y;
                jumpPressed = false;
            }

            origPos = new Vector3(transform.position.x, origPosY, transform.position.z);
            jumpVec = new Vector3(transform.position.x, jumpHeight, transform.position.z);
            targetPos = jumpVec;

            if (heightReached == false)
            {
                if (Vector3.Distance(jumpVec, transform.position) > 0.1)
                {
                    targetPos.y = Mathf.Lerp(transform.position.y, jumpVec.y, 0.1f);
                    transform.position = targetPos;
                }

                if (Mathf.Abs(transform.position.y - jumpVec.y) < 0.1f && heightReached == false)
                {
                    heightReached = true;
                }


            }
            else if (heightReached == true)
            {

                if (Vector3.Distance(origPos, transform.position) > 0.1)
                {
                    transform.position = Vector3.Lerp(transform.position, origPos, 0.1f);
                }
            }

            if (Mathf.Abs(transform.position.y - origPos.y) < 0.1f && heightReached == true)
            {
                canMove = true;
                jumped = false;
                transform.position = new Vector3(transform.position.x, height, transform.position.z);
            }
        }


        //the player starting back at the rail, or in the future, starting on a newly generated tile.
        if (railOn == 1)
        {
            if (transform.position.z > startPos.z + rail1.GetComponent<Collider>().bounds.size.z)
            {
                if (moving == true)
                {
                    gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, rail1.transform.position.z - (rail1.GetComponent<Collider>().bounds.size.z * 0.5f));
                }
                if (isLean == true)
                {
                    gameObject.transform.position = new Vector3(leanEndPos, height, rail1.transform.position.z - (rail1.GetComponent<Collider>().bounds.size.z * 0.5f));
                }
                else if (isLean == false && moving == false)
                {
                    gameObject.transform.position = new Vector3(rail1.transform.position.x, height, rail1.transform.position.z - (rail1.GetComponent<Collider>().bounds.size.z * 0.5f));
                }
            }
        }
        else if (railOn == 2)
        {
            if (transform.position.z > startPos.z + rail2.GetComponent<Collider>().bounds.size.z)
            {
                if (moving == true)
                {
                    gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, rail2.transform.position.z - (rail2.GetComponent<Collider>().bounds.size.z * 0.5f));
                }
                else
                {
                    gameObject.transform.position = new Vector3(rail2.transform.position.x, height, rail2.transform.position.z - (rail2.GetComponent<Collider>().bounds.size.z * 0.5f));
                }
            }
        }
        else if (railOn == 3)
        {
            if (transform.position.z > startPos.z + rail3.GetComponent<Collider>().bounds.size.z)
            {
                if (moving == true)
                {
                    gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, rail3.transform.position.z - (rail3.GetComponent<Collider>().bounds.size.z * 0.5f));
                }

                if (isLean == true)
                {
                    gameObject.transform.position = new Vector3(leanEndPos, height, rail3.transform.position.z - (rail3.GetComponent<Collider>().bounds.size.z * 0.5f));
                }
                else if (isLean == false && moving == false)
                {
                    gameObject.transform.position = new Vector3(rail3.transform.position.x, height, rail3.transform.position.z - (rail3.GetComponent<Collider>().bounds.size.z * 0.5f));
                }
            }
        }
    }

    
}