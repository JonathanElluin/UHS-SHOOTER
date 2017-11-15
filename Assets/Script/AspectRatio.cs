using UnityEngine;
using System.Collections;

public class AspectRatio : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        Camera Cam = GetComponent<Camera>();
        //ForceAspectRatio

        float TargetAspect = 16.0f / 9.0f;

        // current aspect ratio
        float CurrentAspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = CurrentAspect / TargetAspect;

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = Cam.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            Cam.rect = rect;
        }
        else
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = Cam.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            Cam.rect = rect;
        }
    }
}
	
