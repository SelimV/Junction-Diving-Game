using UnityEngine;
using UnityEngine.Events;
#pragma warning disable 0649


public class IntListener : MonoBehaviour {

    
    [SerializeField] IntSignal signal;

    private void OnEnable ()
    {
        signal.Subscribe (this);
    }

    public void SignalRaised (int value)
    {
        onSignalRaised.Invoke (value);
    }

    [SerializeField] IntEvent onSignalRaised;


}
