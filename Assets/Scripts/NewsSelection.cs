using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsSelection : MonoBehaviour {

    //public Canvas contentCanvas;
    //public Canvas selectionCanvas;
    //private GameObject content;

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;

    public GameObject newsPlane;
    public TextMesh newsText;

    private string webData;
/*    
    private string [] urls = {
        "https://thetakeout.com/which-non-alcoholic-beer-is-marginally-better-than-just-1823528279",
        "https://twocents.lifehacker.com/how-different-retirement-income-is-taxed-1825581598",
        "https://skillet.lifehacker.com/whats-your-favorite-grocery-store-1825661539",
        "https://twocents.lifehacker.com/consider-the-opportunity-cost-with-every-investment-1825046624",
        "https://lifehacker.com/remember-three-good-things-that-happened-every-day-1823268910"
    };
    */
    void OnEnable() {
        btn1.onClick.AddListener(() => buttonCallBack(btn1));
        btn2.onClick.AddListener(() => buttonCallBack(btn2));
        btn3.onClick.AddListener(() => buttonCallBack(btn3));
        btn4.onClick.AddListener(() => buttonCallBack(btn4));
        btn5.onClick.AddListener(() => buttonCallBack(btn5));

    }

    private void buttonCallBack(Button buttonPressed) {
        if (buttonPressed == btn1) {
            Debug.Log("Clicked: " + btn1.name);
        } else if (buttonPressed == btn2) {
            Debug.Log("Clicked: " + btn2.name);
        } else if (buttonPressed == btn3) {
            Debug.Log("Clicked: " + btn3.name);
        } else if (buttonPressed == btn4) {
            Debug.Log("Clicked: " + btn4.name);
        } else if (buttonPressed == btn5) {
            Debug.Log("Clicked: " + btn5.name);

            //System.Net.WebClient wc = new System.Net.WebClient();
            //webData = wc.DownloadString(urls[4]);
            newsPlane.SetActive(true);
            //newsPlane.transform.GetChild(0).GetComponent<TextMesh>()
            newsText.text = "When we rounded up our staff’s Weekly Upgrades last Friday, \n our editors were doing more walking on our way to work, \n gaming our credit card rewards, exploring new podcasts, \n and investing in fake sunlight. \nThis week, we’re working on our positivity, making decadent sandwiches at home, keeping cleaner kitchens, and in some cases, nursing ourselves back to health.\nWhat upgrades did you make this week? Let us know in the comments.";
            
//webData;
            //newsText.text = webData;
        } 
    }

    void OnDisable() {
        btn1.onClick.RemoveAllListeners();
        btn2.onClick.RemoveAllListeners();
        btn3.onClick.RemoveAllListeners();
        btn4.onClick.RemoveAllListeners();
        btn5.onClick.RemoveAllListeners();
    }    

/* 
   void SwitchToContentCanvas() {
   selectionCanvas.enabled = false;
   contentCanvas.enabled = true;
   }
   void SwitchToSelectionCanvas() {
   contentCanvas.enabled = false;
   selectionCanvas.enabled = true;
   }

   public void LoadNewsContents() { // button 1
   SwitchToContentCanvas();
   }
*/    
}
