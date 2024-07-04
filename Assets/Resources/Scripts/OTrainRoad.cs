using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OTrainRoad : MonoBehaviour {
    public GameObject Train;
    public GameObject Light;
    private GameObject AnyTrain;
    private Vector3 StartPos, LookRo;
    private float SetTrainTime, Count;
    // Use this for initialization
    void Start () {
        Count = Random.Range(10, 21);
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - SetTrainTime >= Count)
        {
            Light.SetActive(true);
            SetTrain();
            SetTrainTime = Time.time;
            Count = Random.Range(10, 21);
        }
        if (AnyTrain == null)
        {
            Light.SetActive(false);
        }
    }
    void SetTrain()
    {
        if (Random.Range(0, 2) == 0 && AnyTrain == null)//왼쪽에서 오른쪽
        {
            StartPos = new Vector3(-30f, 0.35f, 0);
            LookRo = new Vector3(0f, 0f, 0f);
        }
        else if (AnyTrain == null)
        {
            StartPos = new Vector3(30f, 0.35f, 0);
            LookRo = new Vector3(0f, -180f, 0f);
        }
        AnyTrain = Instantiate(Train) as GameObject;
        AnyTrain.transform.parent = gameObject.transform;
        AnyTrain.transform.localPosition = StartPos;
        AnyTrain.transform.localRotation = Quaternion.Euler(LookRo);
    }
}
