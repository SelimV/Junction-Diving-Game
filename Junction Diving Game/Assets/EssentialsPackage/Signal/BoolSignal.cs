using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Signals/Bool")]
public class BoolSignal : ScriptableObject {

    private BoolEvent signal = new BoolEvent();

    public bool value { get { return _value; } }
    [SerializeField] private bool _value = false;

    public void Raise (bool value)
    {
        signal.Invoke (value);
        _value = value;
    }

    public void Subscribe (BoolListener listener)
    {
        signal.AddListener (listener.SignalRaised);
    }

    public void UnSubscribe (BoolListener listener)
    {
        signal.RemoveListener (listener.SignalRaised);
    }

}
