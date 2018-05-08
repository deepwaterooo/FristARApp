using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    // update this called once per frame
    void Update() {
        transform.Rotate(Vector3.zero, 20*Time.deltaTime);
    }
}
