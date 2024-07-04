using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InGameUICtrl : MonoBehaviour {
    public List<GameObject> UpButtons = new List<GameObject>();
    public List<GameObject> Popups = new List<GameObject>(); //idle, store, score
    public AudioSource SFX;
    public Image BlueBackGround;
    private bool ButtonsActive = false;
    private float fades = 1.0f, cheaktime = 0f;
    // Use this for initialization
    void Start () {
        cheaktime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        Fade();
    }
    public void ButtonsUp()
    {
        ButtonsActive = !ButtonsActive;
        for (int i = 0; i < 3; i++)
        {
            UpButtons[i].SetActive(ButtonsActive);
        }
    }
    public void SoundOn()
    {
        SFX.Play();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void Fade()
    {
        if (Time.time - cheaktime >= 0.05f && fades >= 0f)
        {
            fades -= 0.25f;
            BlueBackGround.color = new Color(BlueBackGround.color.r, BlueBackGround.color.g, BlueBackGround.color.b, fades);
            cheaktime = Time.time;
        }
    }
    public void StorePopupOn()
    {
        Popups[0].SetActive(false);
        Popups[1].SetActive(true);
    }
    public void StorePopupOff()
    {
        Popups[0].SetActive(true);
        Popups[1].SetActive(false);
    }
}
