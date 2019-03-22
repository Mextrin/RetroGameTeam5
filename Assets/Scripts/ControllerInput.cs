﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    static List<int> assignedControllers = new List<int>();
    int controllerID = 0;

    public bool ConnectedController { get { return controllerID > 0; } }
    public string Horizontal { get { return "Controller" + controllerID + "Horizontal"; } }
    //public string Vertical { get { return "Controller" + controllerID + "Vertical"; } }
    public string Jump { get { return "Controller" + controllerID + "Jump"; } }
    public string Action { get { return "Controller" + controllerID + "Action"; } }

    public static void FlushControllers()
    {
        assignedControllers.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!assignedControllers.Contains(1))
        {
            /*print("Assigned controller " + 1 + " to " + gameObject.name);*/
            assignedControllers.Add(1);
            controllerID = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerID <= 0)
        {
            //See if any controller activates
            for (int i = 1; i <= 2; i++)
            {
               /* print(i + " " + Input.GetButtonDown("Controller" + i + "Jump"));*/
                if (!assignedControllers.Contains(i) && Input.GetButtonDown("Controller" + i  + "Jump"))
                {
                    /*print("Assigned controller " + i + " to " + gameObject.name);*/
                    controllerID = i;
                    assignedControllers.Add(i);
                }
            }
        }
    }
}
