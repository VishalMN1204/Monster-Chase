using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    // accessible to other scripts not to the inspector

    private Rigidbody2D myBody;




    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        //speed = 7f;
        //this is variable is utilized in Monster Spawner
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        myBody.velocity = new Vector3(speed, myBody.velocity.y);
        // one of other is to use addForce and no changes to y axis of the velocity apply the same value of current velocity on y axis
        // only changes are made in x 
    }
}
