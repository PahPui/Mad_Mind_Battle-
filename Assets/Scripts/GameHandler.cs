using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //ScreenshotHandler.TakeScreenshot_Static(1280, 720);
            ScreenCapture.CaptureScreenshot("AS.png");
        }
	}
}
