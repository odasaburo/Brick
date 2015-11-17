using UnityEngine;
using System.Collections;

public class specialPower : MonoBehaviour {

    public GameObject[] specials;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void createSpecial(Vector2 createposition, int i)
    {
        GameObject clone;
        clone =  Instantiate(specials[i]);
        clone.GetComponent<specialballControl>().setposition(createposition);

    }

}
