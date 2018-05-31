using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if (m_InputController == null)
            {
                m_InputController = GetComponent<InputController>();
            }
            return m_InputController;
        }
    }

    private Timer m_Timer;
    public Timer Timer
    {
        // getting Timer script
        get
        {
            if (m_Timer == null)
            {
                m_Timer = GetComponent<Timer>();
            }
            return m_Timer;
        }
    }

    private Respawner m_Respawner;
    public Respawner Respawner
    {
        // getting Respawner script component
        get
        {
            if (m_Respawner == null)
            {
                m_Respawner = gameObject.GetComponent<Respawner>();
            }
            return m_Respawner;
        }
    }

}
