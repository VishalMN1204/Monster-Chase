using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // to make the variables available in Unity Inspector but not available to other scripts then use this
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer myRenderer;

    private Animator myAnimator;

    private string WALK_ANIMATION = "Walk";

    private string GROUND_TAG = "Ground";

    private bool isGrounded = true;

    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
        // earlier these variable is used to get the reference instance of object needs to be created after that we can make changes to its properties
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //if the script is enable update is called at every frame
    void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
        PlayerJump();
        // used where movement of hands and legs will be seen while walking which was required

    }

    // Fixed Update is not called at every frame it is called at fixed intervals
    // Fixed Update is called at every 0.02 seconds Usually used for physics calculations involving rigid body
    private void FixedUpdate()
    {
       // PlayerJump();
    }

    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        // Both GetAxis and GetAxisRaw has values going from 1 to -1 where positive is right and negative is left
        // GetAxis takes time to go from -1 to 1 and vice versa like it goes through decimals in 0 before reaching to 1 or -1
        // GetAxisRaw doesn't have any decimal values it either 1 or -1 
        // 0 is basically no keys have been used

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        // using Time.deltaTime is the time between each frame in order to smooth out movement in Unity
        // without Time.deltaTime the movement will be ridiculously fast
        //Time.deltaTime is multiplied by moveForce to ensure that the movement speed remains consistent regardless of the frame rate. It scales the movement by the elapsed time since the last frame.



        //Velocity refers to the speed and direction of an object's movement, and using velocity to move the player allows for more realistic physics-based movement, such as applying forces like gravity or collisions. Velocity is often used when the player's movement should be affected by other objects in the game world,

        //such as when the player is colliding with walls, jumping, or being pushed by other objects.

        //Transform position, on the other hand, directly changes the position of the object, disregarding physics-based calculations. This is often useful when you want precise control over the player's movement,

        //such as in a platformer or puzzle game where the player needs to move with pixel-perfect accuracy. Transform position is also useful when the player's movement should not be influenced by other objects in the game world.

        //In general, if you want more realistic and physics-based movement for your player, use velocity. If you need more precise control over the player's movement or want to ignore physics-based calculations, use transform position.
    }

    void AnimatePlayer()
    {
        // we are going to the right side
        if (movementX > 0f)
        {
            myAnimator.SetBool(WALK_ANIMATION, true);
            // we have created walk animation in the animator section and the value of the variable passed as parameter should
            // match the name of the parameter in animator section
            myRenderer.flipX = false;
            // to turn the player facing the right side
        }
        // we are going to the left side
        else if (movementX < 0f)
        {
            myAnimator.SetBool(WALK_ANIMATION, true);
            myRenderer.flipX = true;
            // to turn the player facing left side
        }
        // not moving at all
        else
        {
            myAnimator.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            // to avoid double jump when you have already jumped
        {
            isGrounded = false;
            // getbuttondown is platform neutral like pressing space in computor or clicking X in console or touch in mobile
            // there is getbuttonup works after releasing the button
            // to make sure player doesn't double jump
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        //    myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            // Adding force vertically rather than horizontally
            // forcemode will help to push the player 
            //myBody.velocity = Vector2.up * jumpForce;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // in built behaviour in unity which helps to detect collision between two game objects
        // to test the collider
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            // checking whether the variable is equal to the tag in the unity inspector at the first section
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Main Menu");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // isTrigger check in boxcollider2D is checked and applied to ghost enemy
        // not a solid collider
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Main Menu");
        }
    }
}
