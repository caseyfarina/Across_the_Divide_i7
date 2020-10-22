using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateMultiDisplay : MonoBehaviour
{
   // public Vector2 displayZeroDimensions = new Vector2(1920, 1080);
   // public Vector2 displayOneDimensions = new Vector2(1920, 1080);
   // public Vector2 displayTwoDimensions = new Vector2(1920, 1080);
   // public Vector2 displayThreeDimensions = new Vector2(1920, 1080);
   // public Vector2 displayFourDimensions = new Vector2(1920, 1080);
   // public Vector2 displayFiveDimensions = new Vector2(1920, 1080);
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.

        for (int i = 0; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
            Display.displays[i].SetParams(Display.displays[i].renderingWidth, Display.displays[i].renderingWidth, 0, 0);
        }

        //OLD CODE ABOUT INITIALIZING EVERY DISPLAY INPEDMNDENTLY
        /*
        if (Display.displays.Length > 0)
            Display.displays[0].Activate();
        Display.displays[0].
            Display.displays[0].SetParams(Display.displays[0].renderingWidth, Display.displays[0].renderingWidth, 0, 0);
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
            Display.displays[1].SetParams((int)displayOneDimensions.x, (int)displayOneDimensions.y, 0, 0);
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();
            Display.displays[2].SetParams((int)displayTwoDimensions.x, (int)displayTwoDimensions.y, 0, 0);
        if (Display.displays.Length > 3)
            Display.displays[3].Activate();
            Display.displays[3].SetParams((int)displayThreeDimensions.x, (int)displayThreeDimensions.y, 0, 0);
        if (Display.displays.Length > 4)
            Display.displays[4].Activate();
        Display.displays[4].SetParams((int)displayFourDimensions.x, (int)displayFourDimensions.y, 0, 0);
        if (Display.displays.Length > 5)
            Display.displays[5].Activate();
            Display.displays[5].SetParams((int)displayFiveDimensions.x, (int)displayFiveDimensions.y, 0, 0);
        // if (Display.displays.Length > 4)
        //    Display.displays[4].Activate();
        // if (Display.displays.Length > 5)
        //    Display.displays[5].Activate();
        // if (Display.displays.Length > 6)
        //    Display.displays[6].Activate(); */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
