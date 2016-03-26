using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

    public GameObject Avatar;
    // Use this for initialization
    void Start () {
        //Note: default prefab with this doesn't initialize the avatar
        Instantiate(Avatar);
    }
    
    // Update is called once per frame
    void Update () {
        //Instantiate(Avatar);
    }
}
