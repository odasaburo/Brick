using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class simpleADS : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Advertisement.Initialize("1016346", false);
        //Advertisement.Show();
        StartCoroutine(ShowAdWhenReady());
	}


    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady())
        {
            yield return null;
        }
        Debug.Log("advertise");
        Advertisement.Show();
    }

}
