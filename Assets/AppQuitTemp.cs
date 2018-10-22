using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppQuitTemp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!Screen.fullScreen)
        {
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void QuitAppTemp()
    {
        Application.Quit();
    }
}
