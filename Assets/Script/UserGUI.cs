using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    GUIStyle LabelStyle1;
    GUIStyle LabelStyle2;
    GUIStyle ButtonStyle;
    Score score;

    // Use this for initialization
    void Awake()
    {
        score = GetComponent<Score>();
        
        LabelStyle1 = new GUIStyle();
        LabelStyle1.fontSize = 20;
        LabelStyle1.alignment = TextAnchor.MiddleCenter;

        LabelStyle2 = new GUIStyle();
        LabelStyle2.fontSize = 40;
        LabelStyle2.alignment = TextAnchor.MiddleCenter;

        ButtonStyle = new GUIStyle("Button");
        ButtonStyle.fontSize = 20;
    }

    void Update()
    {

    }

    public void Continue()
    {
        score.SetGameStatus(0);
    }

    void OnGUI()
    {
        if (score != null)
        {
            //playing
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 20, 100, 50), "Host: " + score.GetHostScore(), LabelStyle1);
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 180, 100, 50), "Client: " + score.GetClientScore(), LabelStyle1);
            if (score.GetGameStatus() == 1) // host win
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 80, 100, 50), "Host win!", LabelStyle2);
                
            }
            else if (score.GetGameStatus() == 2) // client win
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Client win!", LabelStyle2);
                
            }
        }        
    }
}