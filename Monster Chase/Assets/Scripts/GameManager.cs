using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // GameManager will have access to the object of this class which is called instance and GameManager class is not static

    [SerializeField]
    private GameObject[] characters;
    // Type of player we will spawn

    private int _charIndex;

    public int charIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        // test whether allowed to have copy
        if (instance == null)
        {
            instance = this;
            // this refers to the GameManager class
            // copy of game object is created
            Debug.Log(instance);
            DontDestroyOnLoad(gameObject);
            // Don't destroy the game object while moving to the next scene
            
        } else
        {
            Destroy(gameObject);
            // Destroy the duplicate
        }


        // singleton pattern allows to have one copy of the game object in this case it is GameManager
        // it is important because when we set the value of charIndex only unique values are stored and there are no duplicate values
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    // called before start function and after awake function
    // enable and disable can be done in Unity where there is a checkbox next to cube icon in the inspector

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }


    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Gameplay")
        {

            Instantiate(characters[charIndex]);
        }
    }
}

// delegation allow us to subscribe to the event
// for example company sending newspaper to its subscribers then company is the delegate and the newspaper is the event when that event happens the company informs to the subscribers
// unsubscribe is used to avoid memory leaking of data

