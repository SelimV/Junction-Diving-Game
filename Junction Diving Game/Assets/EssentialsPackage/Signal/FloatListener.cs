using UnityEngine;
using UnityEngine.Events;
#pragma warning disable 0649

public class FloatListener : MonoBehaviour {

    
    [SerializeField] FloatSignal signal;

    private void OnEnable ()
    {
        signal.Subscribe (this);
    }

    public void SignalRaised (float value)
    {
        onSignalRaised.Invoke (value);
    }

    [SerializeField] FloatEvent onSignalRaised;


}
