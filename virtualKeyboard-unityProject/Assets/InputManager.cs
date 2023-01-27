using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;


public class InputManager : MonoBehaviour
{
    public Piano piano;
    // Start is called before the first frame update
    private void Awake()
    {
        piano = new Piano();
    }

    private void OnEnable() 
    {
        piano.Enable();    
    }
    private void OnDisable()
    {
        piano.Disable();
    }
    public float Key(int i)
    {
        string k = "0";
        if(i < 0) 
        {
            k = "m" + Mathf.Abs(i).ToString();
        }
        else 
        {
            k = i.ToString();
        }
        return piano.FindAction(k).ReadValue<float>();
    }
    public void Octave()
    {
        // set modifier based on two buttons
    }
}
