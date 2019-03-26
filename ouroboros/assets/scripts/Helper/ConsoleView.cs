/// 
/// Marshals events and data between ConsoleController and uGUI.
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEditor;

public class ConsoleView : MonoBehaviour
{
    ConsoleController console = new ConsoleController();
    GameStateController gamestate;
    bool didShow = false;

    public GameObject ViewContainer; //Container for console view, should be a child of this GameObject
    public Text logTextArea;
    public InputField inputField;
    
    //====================================================
    void OnVisibilityChanged(bool visible)
    {
        SetVisibility(visible);
    }

    void OnLogChanged(string[] newLog)
    {
        UpdateLogStr(newLog);
    }
    //====================================================

    void Start()
    {
        gamestate = GameObject.FindObjectOfType(typeof(GameStateController)) as GameStateController;

        if (console != null)
        {
             console.visibilityChanged += OnVisibilityChanged;
             console.logChanged += OnLogChanged;
        }
        UpdateLogStr(console.log);
    }
    ~ConsoleView()
    {
        console.visibilityChanged -= OnVisibilityChanged;
        console.logChanged -= OnLogChanged;
    }

    void UpdateLogStr(string[] newLog)
    {
        if (newLog == null)
        {
            logTextArea.text = "";
        }
        else
        {
            logTextArea.text = string.Join("\n", newLog);
        }
    }

    void Update()
    {
        
        //Toggle visibility when tilde key pressed
        if (Input.GetKeyDown("i"))
        {
            Debug.Log("Console activated!");
            ToggleVisibility();
        }
        //Toggle visibility when 5 fingers touch.
        if (Input.touches.Length == 5)
        {
            if (!didShow)
            {
                ToggleVisibility();
                didShow = true;
            }
        }
        else
        {
            didShow = false;
        }
    }

    void ToggleVisibility()
    {
        SetVisibility(!ViewContainer.activeSelf);
    }

    void SetVisibility(bool visible)
    {
        ViewContainer.SetActive(visible);
    }

   
    /// 
    /// Event that should be called by anything wanting to submit the current input to the console.
    /// 
    public void RunCommand()
    {
        if (gamestate.executeStateCommand(inputField.text)) { return; }

        console.RunCommandString(inputField.text);
        
        inputField.text = "";
    }

}