using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour
{

    public float maxMoveSpeed = 10f;
    public float maxTurnSpeed = 20f;
    public GridManager gridMan;
    public int startGridX = 2;
    public int startGridY = 2;

    Vector3 latestDestination;
    bool isAtDestination;
    GridZone targetGridZone;
    
    GridZone currentZone;

    void Start()
    {
        currentZone = gridMan.gridZones[startGridX][startGridY];
        transform.position = new Vector3(currentZone.transform.position.x, transform.position.y, currentZone.transform.position.z);
        isAtDestination = true;
    }

    void Update()
    {

        detectNewDestination();

        if (!isAtDestination)
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
                currentZone = targetGridZone;
                isAtDestination = true;
            }
            else
            {
                transform.Translate(Vector3.forward * maxMoveSpeed * Time.deltaTime);
            }
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * maxMoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * maxMoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -maxTurnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, maxTurnSpeed * Time.deltaTime);
        }
    }

    void detectNewDestination()
    {
        if (Input.GetMouseButtonDown(1)) //Right click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == ("GridZone"))
                {
                    targetGridZone = hit.transform.gameObject.GetComponent<GridZone>();
                    latestDestination = targetGridZone.transform.position;
                }
            }
            isAtDestination = false;
        }
    }
}
