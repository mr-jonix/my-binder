using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SelectionAgent : MonoBehaviour
{
    public static SelectionAgent instance = null;
    public CardView selection = null;
    public CardView sideView = null;
    public AlbumView albumView = null;

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    public void Select(CardView cardView)
    {
        if (selection != null)
        {
            Deselect();
        }

        selection = cardView;
        selection.Select();
        sideView.SetCardLink(selection.cardLink);
    }

    public void Deselect()
    {
        if (selection != null)
        {
            selection.Deselect();
        }
        selection = null;
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (selection != null)
            {
                if (selection.albumIndex > 0)
                {
                    Select(albumView.cardViews[selection.albumIndex - 1]);
                }
                else
                {
                    albumView.PrevPage();
                    Select(albumView.cardViews[17]);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (selection != null)
            {
                if (selection.albumIndex < 17)
                {
                    if (albumView.page + selection.albumIndex + 1 < albumView.cardList.Count)
                    {
                        Select(albumView.cardViews[selection.albumIndex + 1]);
                    }
                }
                else
                {
                    albumView.NextPage();
                    Select(albumView.cardViews[0]);

                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Minus)|| Input.GetKeyUp(KeyCode.KeypadMinus))
        {
            if (selection != null)
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    selection.UpdateQuantities(MyBinder.CardTreatment.FOIL, -1);
                }
                else
                {
                    selection.UpdateQuantities(MyBinder.CardTreatment.REGULAR, -1);
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Plus)|| Input.GetKeyUp(KeyCode.Equals) || Input.GetKeyUp(KeyCode.KeypadPlus))
        {
            if (selection != null)
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    selection.UpdateQuantities(MyBinder.CardTreatment.FOIL, 1);
                }
                else
                {
                    selection.UpdateQuantities(MyBinder.CardTreatment.REGULAR, 1);
                }
            }
        }
    }
}
