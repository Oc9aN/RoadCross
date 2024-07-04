using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ORoad : MonoBehaviour {
    public List<GameObject> Cars = new List<GameObject>();
    private Vector3 StartPos, LookRo;
    private GameObject AnyCar;
    private float SetCarTime, Count;
    // Use this for initialization
    void Start () {
        SetCarTime = 0;
        Count = Random.Range(5, 10);
    }
	// Update is called once per frame
	void Update ()
    {
        if (Time.time - SetCarTime >= Count)
        {
            SetCar();
            SetCarTime = Time.time;
            Count = Random.Range(5, 10);
        }
    }
    void SetCar()
    {
        if (Random.Range(0, 2) == 0 && (AnyCar == null || AnyCar.transform.localRotation.y >= 0))//왼쪽에서 오른쪽
        {
            LookRo = new Vector3(0f, 90f, 0f);
            StartPos = new Vector3(-12f, 0.35f, 0);
        }
        else if (AnyCar == null || AnyCar.transform.localRotation.y <= 0)
        {
            LookRo = new Vector3(0f, -90f, 0f);
            StartPos = new Vector3(12f, 0.35f, 0);
        }
        AnyCar = Instantiate(Cars[Random.Range(0, 8)]) as GameObject;
        AnyCar.transform.parent = gameObject.transform;
        AnyCar.transform.localPosition = StartPos;
        AnyCar.transform.localRotation = Quaternion.Euler(LookRo);
    }
}
