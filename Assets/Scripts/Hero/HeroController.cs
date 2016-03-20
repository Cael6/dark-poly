using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    public float maxMoveSpeed = 10f;
    public float maxTurnSpeed = 0.5f;
    public Terrain mainTerrain;

    Vector3 latestDestination;

	void Start () {
	
	}
	
	void Update () {

        detectNewDestination();

        if (transform.position != latestDestination)
        {
            //Turn to look at latest Destination
            Vector3 targetDir = latestDestination - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, maxTurnSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);

            //Move towards destination
            float distanceToDestination = Vector3.Distance(transform.position, latestDestination);
            if (distanceToDestination < maxMoveSpeed * Time.deltaTime)
            {
                transform.position = latestDestination;
            }
            else
            {
                transform.Translate(Vector3.forward * maxMoveSpeed * Time.deltaTime);
            }
        }
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        //}
    }

    void detectNewDestination()
    {
        if (Input.GetMouseButton(1)) //Right click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (mainTerrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                latestDestination = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
        }
    }
}
