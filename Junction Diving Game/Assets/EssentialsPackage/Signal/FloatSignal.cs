using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Signals/Float")]
public class FloatSignal : ScriptableObject {

    private FloatEvent signal = new FloatEvent();

    public float value { get { return _value; } }
    [SerializeField] private float _value = 0;

    public void Raise (float value)
    {
        signal.Invoke (value);
        _value = value;
    }

    public void Subscribe (FloatListener listener)
    {
        signal.AddListener (listener.SignalRaised);
    }

    public void UnSubscribe (FloatListener listener)
    {
        signal.RemoveListener (listener.SignalRaised);
    }

}
