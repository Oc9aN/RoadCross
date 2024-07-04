using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OGround : MonoBehaviour {
    public List<GameObject> Trees = new List<GameObject>();
    // Use this for initialization
    void Start () {
        MakeTree();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void MakeTree()
    {
        int j = 5;
        for (int i = 0; i < 16; i++)
        {
            GameObject AnyTree = GameObject.Instantiate(Trees[Random.Range(0, 4)]) as GameObject;
            AnyTree.transform.parent = gameObject.transform;
            if (i == 8)
            {
                j = -20;
            }
            AnyTree.transform.localPosition = new Vector3(i + j, 0.35f, 0f);
        }
        for (int m = 0; m < Random.Range(1, 5); m++)
        {
            GameObject AnyTree = GameObject.Instantiate(Trees[Random.Range(0, 6)]) as GameObject;
            AnyTree.transform.parent = gameObject.transform;
            AnyTree.transform.localPosition = new Vector3(Random.Range(-5, 5), 0.35f, 0f);
        }
    }
}
