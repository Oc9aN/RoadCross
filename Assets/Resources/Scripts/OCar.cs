using UnityEngine;
using System.Collections;

public class OCar : MonoBehaviour {
    private int Speed;
	// Use this for initialization
	void Start () {
        Speed = Random.Range(3, 7);
    }
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += transform.forward * Speed * Time.deltaTime;
        if (transform.localPosition.x >= 12f || transform.localPosition.x <= -12f)
            Destroy(gameObject);
    }
}
