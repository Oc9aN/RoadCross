using UnityEngine;
using System.Collections;

public class OMngCtrl : MonoBehaviour {
    private static OMngCtrl i = null;
	// Use this for initialization
	void Awake () {
        Screen.SetResolution(720, 1280, false);
        if (i == null)
        {
            DontDestroyOnLoad(this.gameObject);
            i = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
