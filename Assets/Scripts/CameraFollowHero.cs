using UnityEngine;
using System.Collections;

public class CameraFollowHero : MonoBehaviour {

    public GameObject hero;

    public Vector3 heroOffset = new Vector3(0, 10, -6);

	void Start ()
    {
        transform.position = hero.transform.position + heroOffset;
        transform.LookAt(hero.transform.position);
    }
	
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, hero.transform.position + heroOffset, 10f * Time.deltaTime);
    }
}
