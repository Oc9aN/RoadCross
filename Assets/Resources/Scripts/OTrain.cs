using UnityEngine;
using System.Collections;

public class OTrain : MonoBehaviour
{
    public int Speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        transform.localPosition += transform.right * Speed * Time.deltaTime;
        if (transform.localPosition.x >= 30f || transform.localPosition.x <= -30f)
            Destroy(gameObject);
    }
}
