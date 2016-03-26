using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

    public GridZone[][] gridZones;
    public GridZone gridZoneObj;

    public int gridRows = 100;
    public int gridCols = 100;

    float zonePadding = 0.05f;

	// Use this for initialization
	void Awake () {
        gridZones = new GridZone[gridRows][];
	    for (int i = 0; i < gridRows; i++)
        {
            gridZones[i] = new GridZone[gridCols];
            for (int j = 0; j < gridCols; j++)
            {
                float xPos = i * (gridZoneObj.GetComponent<Renderer>().bounds.size.x + zonePadding);
                float yPos = 0.01f;
                float zPos = j * (gridZoneObj.GetComponent<Renderer>().bounds.size.z + zonePadding);
                Vector3 zoneTranslate = new Vector3(xPos, yPos, zPos);
                Quaternion zoneRotation = Quaternion.Euler(new Vector3(90, 0, 0));
                gridZones[i][j] = (GridZone) Instantiate(gridZoneObj, zoneTranslate, zoneRotation);
                gridZones[i][j].zoneX = i;
                gridZones[i][j].zoneY = j;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
