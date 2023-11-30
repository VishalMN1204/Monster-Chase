using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
   public void PlayGame() {

        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        // to get the name of the button we have pressed
        // converted string of number to int


        GameManager.instance.charIndex = selectedCharacter;
        // to access the charIndex in GameManager

        SceneManager.LoadScene("Gameplay");
        // we are transitioning from main menu to game the parameter string name should the match the scene name in Unity Scenes name
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
 