using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodFX_CamerUI : MonoBehaviour
{
    Camera CompleteCamera;
    public static Camera chooseCamera;
    Camera lastChooseCamera;
    RectTransform UI;
    int ScreenX = 0;
    int ScreenY = 0;
    Rect cameraRect;
    public static bool isCameraMax = false;
    public static bool toMax = false;
    // Use this for initialization
    void Start()
    {
        if (GameObject.Find("Complete Camera"))
        {
            CompleteCamera = GameObject.Find("Complete Camera").GetComponent<Camera>();
        }
        if (GameObject.Find("弹出面板"))
        {
            UI = GameObject.Find("弹出面板").GetComponent<RectTransform>();

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (toMax && isCameraMax)
        {
            toCameraMax();
            toMax = false;
        }
    }
    public void CameraMax()
    {   //	Debug.Log (ScreenX + "  " +ScreenY);
        if (!isCameraMax)
        {
            cameraRect = chooseCamera.rect;
            chooseCamera.rect = new Rect(0, 0, 1, 1);
            chooseCamera.depth = 3;
            UI.gameObject.SetActive(false);
            lastChooseCamera = chooseCamera;
            isCameraMax = true;

        }
        else
        {
            lastChooseCamera.rect = cameraRect;
            chooseCamera.depth = 2;
            UI.gameObject.SetActive(false);
            isCameraMax = false;
            GodFX_MainCamerCtrl.maxWindow = "";
        }
    }
    void toCameraMax()
    {
        //	CameraMax ();
    }

}
