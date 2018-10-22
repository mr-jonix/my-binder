using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenToggle : MonoBehaviour {

    public void ToggleFullscreenMode()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

}
