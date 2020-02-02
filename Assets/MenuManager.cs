using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

	public GameObject PanelMain;
	public GameObject PanelEnd;
	public GameObject WinText;
	public GameObject DefeatText;
	public AudioSource audioSource;
	public static MenuManager Instance;
	public GameManager GameMngr;
	private void Awake()
	{
		Instance = this;
	}

	// Start is called before the first frame update
    void Start()
    {
		 GameMngr = GameManager.Instance;   
		 PanelMain.SetActive(true);
    }

    public void Play()
    {
	    PanelMain.SetActive(false);
	    GameMngr.Init();
	    StopMusique();
    }

    public void Quit()
    {
	    Application.Quit();
    }

    public void Restart()
    {
	    WinText.SetActive(false);
	    DefeatText.SetActive(false);
	    PanelMain.SetActive(true);
	    
	    GameMngr.RestartGame();
	    PanelEnd.SetActive(false);
	    gameObject.SetActive(false);
    }

    public void End(string state)
    {
	    audioSource.mute = true;
	    PanelEnd.SetActive(true);
	    switch (state)
	    {
		    case "Win":
			    WinText.SetActive(true);
			    break;
		    case  "GameOver":
			    DefeatText.SetActive(true);
			    break;
	    }
    }

    public void StopMusique()
    {
	    Debug.Log("Stop musique");
	    audioSource.mute = false;
    }
}
