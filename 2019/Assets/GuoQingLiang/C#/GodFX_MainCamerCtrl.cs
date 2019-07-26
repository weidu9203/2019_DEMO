using UnityEngine;
using UnityEditor;
using System.Collections;
public class GodFX_MainCamerCtrl : MonoBehaviour
{
    /// 镜头目标
    public Transform Target;
    //	Transform SelectionTarget;
    Vector3 _TargetPos;
    /// 镜头离目标的距离
    public Texture ButtonTexture;
    public float Distance = 30.0f;
    /// 最大镜头距离
    public float MaxDistance = 60.0f;
    /// 鼠标滚轮拉近拉远速度系数
    public float ScrollFactor = 15.0f;
    /// 镜头移动速度比率
    public float MoveFactor = 0.15f;
    /// 镜头旋转速度比率
    public float RotateFactor = 10.0f;
    /// 镜头水平环绕角度
    public float HorizontalAngle = 0;
    /// 镜头竖直环绕角度
    public float VerticalAngle = -15;
    private Transform mCameraTransform;
    bool Cant = false;
    bool XYCan = true;
    string unlock = "lock";
    Vector2 mousePosition = new Vector2();
    Camera CompleteCamera;
    int[] mouseFanwei = new int[2];
    int pixelLength;
    string XY = "";
    public static string setWindow = "";
    public static string maxWindow = "";
    int Xpianyi;//GUI偏移
    int Ypianyi;//偏移
    public static bool restCamera = false;
    RectTransform UI;


    void Start()
    {
        _TargetPos = Target.transform.position;
        //	Distance = Vector3.Distance (Target.position, this.transform.position);
        //	Debug.Log ( Vector3.Distance (Target.position, this.transform.position));
        mCameraTransform = transform;
        if (GameObject.Find("Complete Camera"))
        {
            CompleteCamera = GameObject.Find("Complete Camera").GetComponent<Camera>();
        }
        if (GameObject.Find("特效面板"))
        {
            GameObject 特效面板 = GameObject.Find("特效面板");
            //	UI =特效面板.GetComponent<RectTransform>();
            UI = 特效面板.transform.Find("弹出面板").GetComponent<RectTransform>();
        }
    }

    void Update()
    {

        mousePosition = Input.mousePosition;
        if (!GodFX_CamerUI.isCameraMax)
            if (CompleteCamera.pixelHeight > CompleteCamera.pixelWidth)
            {

                pixelLength = CompleteCamera.pixelHeight;
                XY = "y";
            }
            else
            {
                pixelLength = CompleteCamera.pixelWidth;
                XY = "x";
            }

        switch (this.gameObject.name)
        {
            case "Camera MAIN":
                if (XY == "x")
                {
                    mouseFanwei[0] = 0;
                    mouseFanwei[1] = pixelLength * 1 / 3;
                }
                if (XY == "y")
                {
                    mouseFanwei[0] = pixelLength * 2 / 3;
                    mouseFanwei[1] = pixelLength * 3 / 3;
                }
                Xpianyi = 0;
                Ypianyi = 0;
                setWindow = "MAIN";
                break;
            case "Camera A":
                mouseFanwei[0] = pixelLength * 1 / 3;
                mouseFanwei[1] = pixelLength * 2 / 3;
                if (XY == "x")
                {
                    Xpianyi = pixelLength * 1 / 3;
                    Ypianyi = 0;
                }
                if (XY == "y")
                {
                    Xpianyi = 0;
                    Ypianyi = pixelLength * 1 / 3;
                }
                setWindow = "A";
                break;
            case "Camera B":
                if (XY == "x")
                {
                    mouseFanwei[0] = pixelLength * 2 / 3;
                    mouseFanwei[1] = pixelLength * 3 / 3;

                    Xpianyi = pixelLength * 2 / 3;
                    Ypianyi = 0;
                }
                if (XY == "y")
                {
                    mouseFanwei[0] = 0;
                    mouseFanwei[1] = pixelLength * 1 / 3;

                    Xpianyi = 0;
                    Ypianyi = pixelLength * 2 / 3;
                }
                setWindow = "B";
                break;

        }//switch
        if (XY == "x")
        {
            if (mousePosition.x > mouseFanwei[0] && mousePosition.x < mouseFanwei[1])
                XYCan = true;
            else
                XYCan = false;
        }
        if (XY == "y")
        {
            if (mousePosition.y > mouseFanwei[0] && mousePosition.y < mouseFanwei[1])
                XYCan = true;
            else
                XYCan = false;
        }
        //	Debug.Log (mousePosition +"mouseFanwei [0]" + mouseFanwei [0]  +"mouseFanwei [1]" + mouseFanwei [1] + XYCan );
        if (restCamera)
        {
            XYCan = true;
            restCamera = false;
        }
        if ((XYCan && maxWindow == "" && !Cant) || maxWindow == setWindow)
        {
            //滚轮向前：拉近距离；滚轮向后：拉远距离
            var scrollAmount = Input.GetAxis("Mouse ScrollWheel");
            Distance -= scrollAmount * ScrollFactor;
            //保证镜头距离合法
            if (Distance < 0)
                Distance = 0;
            else if (Distance > MaxDistance)
                Distance = MaxDistance;
            //按住鼠标左右键移动，镜头随之旋转
            var isMouseLeftButtonDown = Input.GetMouseButton(0);
            var isMouseRightButtonDown = Input.GetMouseButton(1);
            var isMouseLeftButtonUp = Input.GetMouseButtonUp(0);
            if (isMouseLeftButtonUp)
            {
                Invoke("UIClose", 0.1f);
            }
            if (isMouseLeftButtonDown)
            {
                //	Screen.lockCursor = true;//锁定光标，隐藏光标.
                var axisX = Input.GetAxis("Mouse X");
                var axisY = Input.GetAxis("Mouse Y");
                //	Debug.Log (axisX + " " + axisY);
                HorizontalAngle += axisX * RotateFactor;
                VerticalAngle += axisY * RotateFactor;
            }
            else
            {
                //	Screen.lockCursor = false;//锁定光标false，隐藏光标.
            }
            if (isMouseRightButtonDown)
            {

                UI.anchoredPosition = new Vector2(mousePosition.x, mousePosition.y);
                UI.gameObject.SetActive(true);
                GodFX_CamerUI.chooseCamera = this.gameObject.GetComponent<Camera>();
                maxWindow = setWindow;
                //	UIState = true;
            }

            if (Input.GetMouseButton(2))
            {
                var axisX = Input.GetAxis("Mouse X");
                var axisY = Input.GetAxis("Mouse Y");
                Target.transform.position = Target.transform.position - new Vector3(axisX * MoveFactor, 0, 0);
                Target.transform.position = Target.transform.position - new Vector3(0, axisY * MoveFactor, 0);
            }
            //按镜头距离调整位置和方向
            var rotation = Quaternion.Euler(-VerticalAngle, HorizontalAngle, 0);
            var offset = rotation * Vector3.back * Distance;
            mCameraTransform.position = (Target.position + offset);
            mCameraTransform.rotation = rotation;
        }
    }
    void UIClose()
    {

        UI.gameObject.SetActive(false);
        if (!GodFX_CamerUI.isCameraMax)
            maxWindow = "";
    }

    void OnGUI()
    {
        float Screenx = Screen.width;
        float Screeny = Screen.height;
        GUILayout.BeginArea(new Rect(0, 0, 20000, 20000));//
        GUI.color = Color.white;//全局设置颜色，设置后后面的控件都变为红色，直到重新设置颜色

        if (GUI.Button(new Rect(0 + Xpianyi, 0 + Ypianyi, 50, 17), "Reset", ""))
        {
            HorizontalAngle = 0;
            VerticalAngle = -15;
        }

        if (GUI.Button(new Rect(50 + Xpianyi, 0 + Ypianyi, 50, 17), unlock, ""))
        {
            if (!Cant)
            {
                Cant = true;
                unlock = "unlock";
            }
            else
            {
                Cant = false;
                unlock = "lock";
            }
        }

        //	if (GUILayout.Button(ButtonTexture, GUILayout.Width (40), GUILayout.Height (17))) 
        GUILayout.EndArea();// 运行状态位置.

    }

}