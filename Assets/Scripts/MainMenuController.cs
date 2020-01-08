using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour{

    public GameObject MainMenu;
    public GameObject Credits;
    public GameObject Options;

    public void playGame() {
        SceneManager.LoadScene("SampleScene");
    }
 
    public void options() {
        MainMenu.SetActive(false);
        Options.SetActive(true);
    }
	
	public void creditcard() {
		MainMenu.SetActive(false);
        Credits.SetActive(true);     
    }
	
	public void back() {
		MainMenu.SetActive(true);
		Credits.SetActive(false);
		Options.SetActive(false);
    }
 
    public void exitGame() {
        Application.Quit();
    }
}
