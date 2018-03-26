using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public event System.Action<Player> OnLocalPlayerJoined;
    private GameObject gObject;
    
    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameManager
                {
                    gObject = new GameObject("_gameManager")
                };
                m_Instance.gObject.AddComponent<InputController>();
                m_Instance.gObject.AddComponent<Timer>();
                m_Instance.gObject.AddComponent<Respawner>();
            }
            return m_Instance;
        }
    }

    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if(m_InputController == null)
            {
                m_InputController = gObject.GetComponent<InputController>();
            }
            return m_InputController;
        }
    }

    private Player m_LocalPlayer;
    public Player LocalPlayer
    {
        get
        {
            return m_LocalPlayer;
        }
        set
        {
            m_LocalPlayer = value;

            if (OnLocalPlayerJoined != null)
                OnLocalPlayerJoined(m_LocalPlayer);
        }
    }

    private Timer m_Timer;
    public Timer Timer
    {
        get
        {
            if (m_Timer == null)
                m_Timer = gObject.GetComponent<Timer>();
            return m_Timer;
        }
    }

    private Respawner m_Respawner;
    public Respawner Respawner
    {
        get
        {
            if (m_Respawner == null)
                m_Respawner = gObject.GetComponent<Respawner>();
            return m_Respawner;
        }
    }
}
