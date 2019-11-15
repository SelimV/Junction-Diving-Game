/*

using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

    public static AdManager Singleton;

    private void Start ()
    {
        if (Singleton)
        {
            Destroy (gameObject);
        } else
        {
            Singleton = this;
        }
    }

    public void ShowShortAd ()
    {
        if (Advertisement.IsReady ("video"))
        {
            OpenMisclickPanel ();

            Advertisement.Show ("video");
        }
    }

    public void ShowRewardedVideo ()
    {
        if (Advertisement.IsReady ("rewardedVideo"))
        {

            var options = new ShowOptions { resultCallback = HandleRewardedVideo };
            Advertisement.Show ("rewardedVideo", options);

        }
    }

    private void HandleRewardedVideo (ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                //
                //
                // GIVE REWARD HERE
                //
                //
                break;
            default:
                break;
        }
    }
}

*/