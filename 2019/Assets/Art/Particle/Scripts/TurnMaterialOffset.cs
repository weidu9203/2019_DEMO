using UnityEngine;
using System.Collections;
using System.Collections;

public class TurnMaterialOffset : MonoBehaviour
{

    public float step = 0.01f;
    float v = 0.0f;
    float T = 1.0f;
    bool b1;
    bool b2;

    void Update()
    {
        if(b1){
            v += step;
            if (v >= 1f)
                v = 0f;

            Vector2 v2;
            if (b2)
            {
                 v2 = new Vector2(0f,v);
            }
            else {
                 v2 = new Vector2(v, 0f);
            }
            GetComponent<Renderer>().material.mainTextureOffset = v2;
        }
    }

    void OnGUI() {
        if (GUILayout.Button("开始"))
        {
            b1 = true;

        }

        if (GUILayout.Button("结束"))
        {
            b1 = false;
        }

        if (GUILayout.Button("换向"))
        {
            b2 = true;
        }

        if (GUILayout.Button("还原"))
        {
            b2 = false;
        }

        if(GUILayout.Button("放大")){
            Vector2 size = new Vector2(3f, 3f);
            GetComponent<Renderer>().material.SetTextureScale("_MainTex", size);
        }
        if (GUILayout.Button("旋转"))
        {
            GetComponent<Renderer>().material.SetFloat("_RotationSpeed",10);
        }
    }
}