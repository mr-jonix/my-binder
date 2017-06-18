using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour {

    public MTGCard cardLink;
    public Sprite defaultImage;
    public UnityEngine.UI.RawImage cardImageObject;


	// Use this for initialization
	void Start () {
        cardImageObject.texture = defaultImage.texture;
    }
	
	// Update is called once per frame
	void Update () {

        if (cardLink == null)
        {
            cardImageObject.texture = defaultImage.texture;
        }
		
	}

    public IEnumerator SetImageFromURL(string url)
    {
        Debug.Log("Start download from " + url);

        // Start a download of the given URL
        WWW www = new WWW(url);

        // Wait for download to complete
        yield return www;
        Debug.Log("download OK");
        
        
        // assign texture
        cardImageObject.texture = www.texture;
    }
}
