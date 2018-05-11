using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BackToOriginalInterface : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vbBtnObject;
    public GameObject newsPlane;
    public TextMesh newsText;

    void Start() {
        vbBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        Debug.Log("virtual button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        BackToOriginaInterfaceLook();
    }
    
    void BackToOriginaInterfaceLook() {
        newsText.text = "";
        newsPlane.SetActive(false);
    }
}
