using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;

    private string PLAYER_TAG = "Player";

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
        // setting the player position value
        // refer the tags in Player.cs file

  
        // transfer data from one scene to another scene
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!player) return;


        tempPos = transform.position;
        // current position of the camera
        tempPos.x = player.position.x;
        if (tempPos.x < minX)
        {
            tempPos.x = minX;
            // to make sure that camera would stop at a particular point
        }
        if (tempPos.x > maxX) 
        {
            tempPos.x = maxX;
            // to make sure that camera would stop at a particular point
        }
        // camera's x position is equal to player's x position
        // when left or right keys are used the player will go left right
        transform.position = tempPos;
    }
    // LateUpdate is being called after all calculations in update are finished to avoid conflict with Update in Player.cs
}
