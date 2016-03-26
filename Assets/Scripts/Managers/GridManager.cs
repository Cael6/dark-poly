using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

    public GameObject[][] gridZones;
    public GameObject gridZoneObj;

    public int gridRows = 100;
    public int gridCols = 100;

	// Use this for initialization
	void Start () {
        gridZones = new GameObject[gridRows][];
	    for (int i = 0; i < gridRows; i++)
        {
            gridZones[i] = new GameObject[gridCols];
            for (int j = 0; j < gridCols; j++)
            {
                Vector3 zoneTranslate = new Vector3(i * gridZoneObj.GetComponent<Renderer>().bounds.size.x, 0.01f, j * gridZoneObj.GetComponent<Renderer>().bounds.size.z);
                Quaternion zoneRotation = Quaternion.Euler(new Vector3(90, 0, 0));
                gridZones[i][j] = (GameObject) Instantiate(gridZoneObj, zoneTranslate, zoneRotation);
                Debug.Log(gridZones[i][j].transform.position.x + " " + gridZones[i][j].transform.position.z);
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
