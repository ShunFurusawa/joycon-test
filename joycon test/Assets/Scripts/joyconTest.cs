using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class joyconTest : MonoBehaviour
{
    private static readonly Joycon.Button[] m_buttons = 
        Enum.GetValues (typeof (Joycon.Button)) as Joycon.Button[];

    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;
    private Joycon.Button? m_pressedButtonL;
    private Joycon.Button? m_pressedButtonR;

    void Start()
    {
        SetControllers();
    }

    
    void Update()
    {        
        m_pressedButtonL = null;
        m_pressedButtonR = null;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        SetControllers();

        foreach (var button in m_buttons)
        {
            if (m_joyconL.GetButton (button))
            {
                m_pressedButtonL = button;       
            }
            if(m_joyconR.GetButton (button))
            {
                m_pressedButtonR = button;      //ここ何やってるのか絶妙によくわからん
            }              
        }

        if (Input.GetKeyDown (KeyCode.Z))
        {
            m_joyconL.SetRumble(160, 320, 0.6f, 200);   //規定値に戻す？
        }
        if (Input.GetKeyDown (KeyCode.X))
        {
            m_joyconR.SetRumble(160, 320, 0.6f, 200);
        }
    }

    private void OnGUI()
    {
        var style = GUI.skin.GetStyle ("label");
        style.fontSize = 24;

        if (m_joyconR == null || m_joycons.Count <= 0)
        {
            GUILayout.Label("joy-conが接続されていません");
            return;
        }

        if (!m_joycons.Any (c => c.isLeft ))    //cとは？あとアロー演算子もようわからん
        {
            GUILayout.Label("Joy-con(L) が接続されていません");
            return;
        }
        if (!m_joycons.Any(c => !c.isLeft))
        {
            GUILayout.Label("Joy-con(R) が接続されていません");
            return;
        }

        GUILayout.BeginHorizontal (GUILayout.Width (960));

        foreach (var joycon in m_joycons)
        {
            //各データの取得してるらしい
            var isLeft = joycon.isLeft; 
            var name = isLeft ? "Joy-con(L)" : "Joy-con(R)";
            var key = isLeft ? "Z キー" : "Xキー"; 
            var button = isLeft ? m_pressedButtonL : m_pressedButtonR;
            var stick = joycon.GetStick();
            var gyro = joycon.GetGyro();
            var accel = joycon.GetAccel();
            var orientation = joycon.GetVector();

            //それぞれのデータを視覚的に表示してる。GUILayout初めて見たから用勉強
            GUILayout.BeginVertical(GUILayout.Width(480));
            GUILayout.Label(name);
            GUILayout.Label(key + "：振動");
            GUILayout.Label("押されているボタン : " + button);
            GUILayout.Label(string.Format ("スティック：({0}, {1})", stick[0], stick[1]));
            GUILayout.Label("ジャイロ：" + gyro);
            GUILayout.Label("加速度：" + accel);
            GUILayout.Label("ジャイロ：" + orientation);
            GUILayout.EndVertical();
        }

        GUILayout.EndHorizontal ();
    }

    private void SetControllers()
    {
        m_joycons = JoyconManager.Instance.j;
        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joyconL = m_joycons.Find(c => c.isLeft);
        m_joyconR = m_joycons.Find(c => !c.isLeft);
    }
}
