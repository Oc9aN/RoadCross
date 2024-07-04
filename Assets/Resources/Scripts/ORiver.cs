using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ORiver : MonoBehaviour {
    public List<GameObject> Logs = new List<GameObject>();
    public int LogDirection; //트루면 왼쪽에서오른쪽
    private Vector3 StartPos;
    private GameObject AnyLog;
    private OLogs MovingLog;
    private float SetLogTime, Count;
    // Use this for initialization
    void Start () {
        LogDirection = Random.Range(0, 2);
        SetLogTime = 0;
        Count = Random.Range(2f, 4f);
        MovingLog = GetComponentInChildren<OLogs>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - SetLogTime >= Count)
        {
            StarLog();
            SetLogTime = Time.time;
            Count = Random.Range(2f, 4f);
        }
    }
    void StarLog()
    {
        if (LogDirection == 0)//왼쪽에서 오른쪽
        {
            StartPos = new Vector3(-12f, -0.1f, 0f);
        }
        else
        {
            StartPos = new Vector3(12f, -0.1f, 0f);
        }
        AnyLog = Instantiate(Logs[Random.Range(0, 4)]) as GameObject;
        AnyLog.transform.parent = gameObject.transform;
        AnyLog.transform.localPosition = StartPos;
    }
}
