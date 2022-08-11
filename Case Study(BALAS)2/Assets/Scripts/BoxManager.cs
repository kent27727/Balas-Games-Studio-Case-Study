using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{

    public List<GameObject> boxList = new List<GameObject>();
    public GameObject boxPrefab;
    public Transform exitPoint;
    bool isWorking;
    int stackCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(boxSpawner());
        
    }

    public void RemoveLast()
    {
        if (boxList.Count > 0)
        {
            Destroy(boxList[boxList.Count - 1]);
            boxList.RemoveAt(boxList.Count - 1);
        }
    }

    private IEnumerator boxSpawner()
    {
        while (true)
        {
            
            int boxCount = boxList.Count;
            int rowCount = (int)boxCount / stackCount;
            if (isWorking == true)
            {
                GameObject temp = Instantiate(boxPrefab);
                temp.transform.position = new Vector3(exitPoint.position.x+((float)rowCount/2), 0.80f, exitPoint.position.z);
                boxList.Add(temp);
                if(boxList.Count>=5)
                {
                    isWorking = false;
                }
            }

            else if (boxList.Count < 5)
            {
                isWorking = true;
            }
            
            
            
            yield return new WaitForSeconds(5f);
        }
        
    }
}
