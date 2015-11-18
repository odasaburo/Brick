using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
public class AdManager : MonoBehaviour {

    [SerializeField]
    string gameID = "1016346";

    void Awake()
    {
        Advertisement.Initialize(gameID, true);
    }

    public void ShowAd(string zone = "")
    {
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif
        if (string.Equals(zone, ""))
        {
            zone = null;
        }
        if (Advertisement.IsReady())
        {
            Advertisement.Show(zone);
        }
    }

    void AdCallbackHandler(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("finished");
                break;
            case ShowResult.Skipped:
                Debug.Log("skipped");
                break;
        }
    }

    IEnumerator WaitForAd()
    {
        float currenTimescale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
        {
            yield return null;
        }

        Time.timeScale = currenTimescale;
    }
}
