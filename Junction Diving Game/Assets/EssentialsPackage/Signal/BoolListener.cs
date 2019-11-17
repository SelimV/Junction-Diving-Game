using UnityEngine;
using UnityEngine.Events;
#pragma warning disable 0649

public class BoolListener : MonoBehaviour {
    
    [SerializeField] BoolSignal signal;

    private void OnEnable ()
    {
        signal.Subscribe (this);
    }

    public void SignalRaised (bool value)
    {
        onSignalRaised.Invoke (value);
    }

    [SerializeField] BoolEvent onSignalRaised;

}
