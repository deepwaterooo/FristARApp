using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour {

    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;
    public GameObject car6;

    public int BallSelected;

    // Use this for initialization
    void Start() {
        car1.SetActive(false);
        car2.SetActive(false);
        car3.SetActive(false);
        car4.SetActive(false);
        car5.SetActive(false);
        car6.SetActive(false);
    }

    public void LoadCar1() {
        car1.SetActive(true);
        car2.SetActive(false);
        car3.SetActive(false);
        car4.SetActive(false);
        car5.SetActive(false);
        car6.SetActive(false);
    }
    
    public void LoadCar2() {
        car1.SetActive(false);
        car2.SetActive(true);
        car3.SetActive(false);
        car4.SetActive(false);
        car5.SetActive(false);
        car6.SetActive(false);
    }
    
    public void LoadCar3() {
        car1.SetActive(false);
        car2.SetActive(false);
        car3.SetActive(true);
        car4.SetActive(false);
        car5.SetActive(false);
        car6.SetActive(false);
    }
    
    public void LoadCar4() {
        car1.SetActive(false);
        car2.SetActive(false);
        car3.SetActive(false);
        car4.SetActive(true);
        car5.SetActive(false);
        car6.SetActive(false);
    }
    
    public void LoadCar5() {
        car1.SetActive(false);
        car2.SetActive(false);
        car3.SetActive(false);
        car4.SetActive(false);
        car5.SetActive(true);
        car6.SetActive(false);
    }
    
    public void LoadCar6() {
        car1.SetActive(false);
        car2.SetActive(false);
        car3.SetActive(false);
        car4.SetActive(false);
        car5.SetActive(false);
        car6.SetActive(true);
    }
}
