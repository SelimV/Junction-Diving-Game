using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Signals/Int")]
public class IntSignal : ScriptableObject {

    private IntEvent signal = new IntEvent();

    public int value { get { return _value; } }
    [SerializeField] private int _value = 0;

    public void Raise (int value)
    {
        signal.Invoke (value);
        _value = value;
    }

    public void Subscribe (IntListener listener)
    {
        signal.AddListener (listener.SignalRaised);
    }

    public void UnSubscribe (IntListener listener)
    {
        signal.RemoveListener (listener.SignalRaised);
    }

}
