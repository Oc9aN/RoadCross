using UnityEngine;
using System.Collections;

public class OLogs : MonoBehaviour {
    private ORiver River;
    public float FSpeed;
    public int Cheak;
    void Start () {
        River = GetComponentInParent<ORiver>();
        Cheak = River.LogDirection;
    }
	
	// Update is called once per frame
	void Update () {
        if (Cheak == 0)
        {
            transform.localPosition += transform.right * FSpeed * Time.deltaTime;
        }
        else
        {
            transform.localPosition -= transform.right * FSpeed * Time.deltaTime;
        }
        if (transform.localPosition.x > 24f || transform.localPosition.x < -24f)
        {
            Destroy(gameObject);
        }
    }
}
