using UnityEngine;
#pragma warning disable 0649

public class ShowUIPanel : MonoBehaviour
{

    [SerializeField] private Animator anim;

    public void Show ()
    {
        anim.SetBool ("Hidden", false);
    }

    public void Hide ()
    {
        anim.SetBool ("Hidden", true);
    }

    public void SetState (bool hidden)
    {
        anim.SetBool ("Hidden", hidden);
    }

}
