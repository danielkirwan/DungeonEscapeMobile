using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    private string placementID = "Rewarded_Android";
    private bool TestMode = true;
    private string androidID = "4381763";
    private void Start()
    {
        //Advertisement.AddListener(this);
        Advertisement.Initialize(androidID, TestMode);
    }

    public void ShowRewardedAd()
    {
        Debug.Log("Showing ad");
        if (Advertisement.IsReady(placementID))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };

            Advertisement.Show(placementID, options);
        }
    }

    void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Player should received 100 gems");
                GameManager.Instance.player.UpdateDiamonds(100);
                UIManager.Instance.OpenShop(GameManager.Instance.player._diamonds);
                break;
            case ShowResult.Skipped:
                Debug.Log("Skipped ad");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad not ready");
                break;
        }
    }
}
