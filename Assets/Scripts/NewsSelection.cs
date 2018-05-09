using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsSelection : MonoBehaviour {

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
            newsPlane.SetActive(true);  
            newsText.text = "When we rounded up our staff’s Weekly \n I didn’t anticipate how strange I’d \n feel buying non-alcoholic beer. I \n rolled into my regular supermarket at \n 9:30 on Saturday morning and loaded \n up the register’s conveyer belt with \n seven six-packs of non-alcoholic beer, \n plus a gallon of milk (we were out). \n The cashier asked for my I.D., which \n I wasn’t expecting. Then, to his credit, \n he did a decent job containing his \n side-eye while asking whether I wanted \n paper or plastic. \n Wow, I said to myself as I watched \n the cashier scan pack after pack of \n NA beer, I look like a serial killer. \n  \n But the awkwardness was worth it, \n readers, for I was on a mission: to \n objectively evaluate and rank \n non-alcoholic beers. \n  \n My curiosity was piqued with reports \n that German Olympians and even \n marathoners use non-alcoholic beers \n as fuel. And it’s not just athletes: \n CNN Money reports Anheuser-Busch \n InBev says low- and non-alcoholic \n beers will make up 20 percent of its \n production volume by 2025. An \n increasing number of people are \n drinking this stuff, but I wanted to \n know: Does it taste any good? \n  \n Like any researcher using the \n scientific method, I had to formulate \n a hypothesis. I figured the best \n non-alcoholic beers would probably be \n pretty good, and the worst would be \n very, very bad. I anticipated that \n the best versions would be passable \n copies of their boozy cousins, but I \n had no guesses as to which brands \n would come out on top. With my mind \n a blank page ready for objective \n analysis, I cracked open the first \n bottle of non-alcoholic beer and \n prepared to rage.";
        } 
        if (buttonPressed == btn2) {
            newsPlane.SetActive(true);  
            newsText.text = "We all dream of the day when we can \n leave a boring corporate job or \n unfulfilling career behind for good, \n take our retirement savings and spend \n more time with our family or take \n that trip we’ve been planning for our \n entire lives. And while you’ll have a \n million considerations at this time \n in your life about what to do with \n your time and money, there’s one more \n to take into account that can \n significantly impact your planning: \n Just how much of your retirement \n income will be taxed. \n  \n Between 401(k) payments, Social \n Security benefits and other \n investment assets, there’s a lot of \n complicated ways this could shake \n out. To simplify, here’s how 13 \n different types of retirement income \n streams are taxed.";
        } 
        if (buttonPressed == btn3) {
            newsPlane.SetActive(true);  
            newsText.text = "Hello, and welcome back to What’s \n Cooking?, the open thread where you \n get to share your brilliant thoughts, \n advice, recipes, and opinions on all \n things food-related. This week I want \n to talk about buying food—specifically, \n where you buy it. \n Last week, I was attacked on the \n internet. As a woman who has been \n writing on said internet for many \n years, I am used to attacks, but this \n one stung. You see, a certain food \n publication put out an article \n suggesting grocery stores for every \n astrological sign. Even though I \n don’t believe in astrology, I totally \n do believe in astrology, so imagine \n my shock when I scrolled down to find \n they were suggesting I, a triple Leo, \n would do best getting my groceries from \n Walmart. This brought up a lot of \n grocery store feelings I didn’t know \n I had. \n Beyond this particular issue and the \n feelings around it, I’d like to talk \n about grocery stores in general, \n because I love grocery stores.";
        } 
        if (buttonPressed == btn4) {
            newsPlane.SetActive(true);  
            newsText.text = "A lot of our thinking about money \n revolves around the gains: I’ll \n invest x to get returns of y percent \n in the long term; I’ll buy this couch \n because it will brighten up my \n apartment and make me happier. But \n when it comes to financial decisions, \n it’s also important to consider what \n you’ll be giving up. \n  \n Because we’re human, we make \n impulsive decisions all the time. But \n rather than rushing decisions or \n simply going through the motions, \n really thinking about what we’re \n giving up when we make these \n decisions is a way to take a \n long-term view of our finances rather \n than a myopic one.";
        } 
        if (buttonPressed == btn5) {
            //Debug.Log("Clicked: " + btn5.name);
            //System.Net.WebClient wc = new System.Net.WebClient();
            //webData = wc.DownloadString(urls[4]);
            newsPlane.SetActive(true);  
            newsText.text = "When we rounded up our staff’s Weekly \n Upgrades last Friday, our editors were \n doing more walking on our way to work,\n gaming our credit card rewards, exploring \n new podcasts, and investing in fake sunlight.\n This week, we are working on our positivity,\n making decadent sandwiches at home, keeping \n cleaner kitchens, and in some cases, nursing \n ourselves back to health. What upgrades did \n you make this week?\n  Let us know in the comments.";
        } 
    }

    void OnDisable() {
        btn1.onClick.RemoveAllListeners();
        btn2.onClick.RemoveAllListeners();
        btn3.onClick.RemoveAllListeners();
        btn4.onClick.RemoveAllListeners();
        btn5.onClick.RemoveAllListeners();
    }    
}
