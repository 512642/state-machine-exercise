using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class State : MonoBehaviour
{


    public Action ActiveAction, OnEnterAction, OnExitAction;


    public State(Action active, Action onEnter, Action onExit)
    {
        ActiveAction = active;
        OnEnterAction = onEnter;
        OnExitAction = onExit;
    }

    public void Execute()
    {
        if (ActiveAction != null)
        ActiveAction.Invoke();
    }

    public void OnEnter()
    {
        if (OnEnterAction != null)
        OnEnterAction.Invoke();
    }

    public void OnExit()
    {
        if (OnExitAction != null)
        OnExitAction.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
