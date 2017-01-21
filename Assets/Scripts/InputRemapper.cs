using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using InControl;


using UnityEditor;

public class InputRemapper : MonoBehaviour
{

    public AnimationCurve curve;
    public Color color;

    public float sensitivty = 0;

    Texture2D tex;
    Color[] colors;


    // Use this for initialization
    void Start()
    {
        tex = new Texture2D(100, 100, TextureFormat.RGB24, false);
        colors = new Color[100 * 100];
    }

    // Update is called once per frame
    void Update()
    {

        Keyframe[] keys = curve.keys;

        keys[0].outTangent = sensitivty;
        keys[2].inTangent = -sensitivty;

        curve.keys = keys;

    }

    void OnGUI()
    {
        //float x = InputManager.ActiveDevice.LeftStick.X;
        //float remappedX = curve.Evaluate(x);


        //GUILayout.Label("Raw X: " + x.ToString());
        //GUILayout.Label("Remap X: " + remappedX.ToString());

        //tex.SetPixels(colors);


        for (int i = 0; i < tex.width; i++)
        {
            float px = i;
            //float py = curve.Evaluate(Mathf.InverseLerp(-1, 1, px / (float)tex.width)) * tex.height;
            float cx = Mathf.Lerp(-1, 1, Mathf.InverseLerp(0, tex.width, i));
            //Debug.Log(cx);
            float py = Mathf.Lerp(0, tex.height, Mathf.InverseLerp(-1, 1, curve.Evaluate(cx)));

            tex.SetPixel((int)px, (int)py, Color.red);
        }

        tex.Apply();

        GUI.DrawTexture(new Rect(0, 0, 400, 400), tex);

    }


}
