using UnityEngine;
using System.Collections;
using System;

public class Repeating: MonoBehaviour 
{

    private float groundVerticalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.
    public Camera mainCam;
    private Transform cameratTrans;

    //Awake is called before Start.
    private void Awake ()
    {
        //Store the size of the collider along the x axis (its length in units).
        groundVerticalLength =  GetComponent<BoxCollider2D>().size.y;
        groundVerticalLength *= transform.localScale.y;
        cameratTrans = mainCam.transform;
    }

    //Update runs once per frame
    private void Update()
    {
        //Check if the difference along the y axis between the main Camera and the position of the object this is attached to is greater than groundHorizontalLength.

        if (cameratTrans.position.y - transform.position.y > groundVerticalLength)
        {
            Debug.Log(String.Format("y: {0}, length {1}", transform.position.y, groundVerticalLength));
            //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
            RepositionBackground ();
        }
    }

    //Moves the object this script is attached to right in order to create our looping background effect.
    private void RepositionBackground()
    {
        //This is how far to the right we will move our background object, in this case, twice its length. This will position it directly to the right of the currently visible background object.
        Vector2 groundOffSet = new Vector2(0, groundVerticalLength * 2f);

        //Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
        transform.position = (Vector2) transform.position + groundOffSet;
    }
}