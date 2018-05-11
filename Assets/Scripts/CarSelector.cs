using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelector : MonoBehaviour {

    public Button [] showCarTrigBtns;
    public GameObject [] cars;
    public int latestActiveCarIndex = -1;
  
    void OnEnable() {
        showCarTrigBtns[0].onClick.AddListener(() => buttonCallBack(showCarTrigBtns[0]));
        showCarTrigBtns[1].onClick.AddListener(() => buttonCallBack(showCarTrigBtns[1]));
        showCarTrigBtns[2].onClick.AddListener(() => buttonCallBack(showCarTrigBtns[2]));
        showCarTrigBtns[3].onClick.AddListener(() => buttonCallBack(showCarTrigBtns[3]));
        showCarTrigBtns[4].onClick.AddListener(() => buttonCallBack(showCarTrigBtns[4]));
        showCarTrigBtns[5].onClick.AddListener(() => buttonCallBack(showCarTrigBtns[5]));  
    }

    void Start() {
        for (int i = 0; i < cars.Length; i++) {
            cars[i].SetActive(false);
        }
    }

    public void DeactivatePreviousGameObjects() {
        if (latestActiveCarIndex >= 0) {
            cars[latestActiveCarIndex].SetActive(false);
            latestActiveCarIndex = -1;
        }
    }
    
    private void buttonCallBack(Button button) {
        for (int i = 0; i < showCarTrigBtns.Length; i++) {
            if (showCarTrigBtns[i] == button) {
                cars[i].SetActive(true);
                latestActiveCarIndex = i;
            } else
                cars[i].SetActive(false);
        }
    }

    void OnDisable() {
        for (int i = 0; i < showCarTrigBtns.Length; i++) {
            showCarTrigBtns[i].onClick.RemoveAllListeners();
        }
    }    
}
