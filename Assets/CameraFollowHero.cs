using UnityEngine;
using System.Collections;

public class CameraFollowHero : MonoBehaviour {

    public GameObject hero;

    Vector3 heroOffset = new Vector3(0, 10, -6);

	void Start () {
        transform.LookAt(hero.transform);
        transform.position = hero.transform.position + heroOffset;
	}
	
	void Update () {
        transform.position = Vector3.Lerp(transform.position, hero.transform.position + heroOffset, 10f * Time.deltaTime);
    }
}
