using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class BoolSignalLogicGate : MonoBehaviour
{
    enum LogicGate { AND, OR, NOT }

    [SerializeField] LogicGate gate = LogicGate.AND;

    public BoolSignal signal1;
    public BoolSignal signal2;

    public void Evaluate ()
    {
        switch (gate)
        {

            case LogicGate.AND:
                RaiseBoolEvent( signal1.value && signal2.value);
                break;

            case LogicGate.OR:
                RaiseBoolEvent( signal1.value || signal2.value);
                break;

            case LogicGate.NOT:
                RaiseBoolEvent( !signal1.value);
                break;

            default:
                break;

        }
    }


    public void RaiseBoolEvent (bool value)
    {
        if (value)
        {
            onTrue.Invoke ();    
        } else
        {
            onFalse.Invoke ();
        }
    }

    public UnityEvent onTrue;
    public UnityEvent onFalse;


}
