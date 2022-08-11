using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public List<GameObject> boxList = new List<GameObject>();
    List<GameObject> moneyList = new List<GameObject>();

    int stackCount = 1;

    public Transform boxPoint,moneyDropPoint;
    public GameObject boxPrefab,moneyPrefab;

    private void Start()
    {
        StartCoroutine(GenerateMoney());
    }

    IEnumerator GenerateMoney()
    {
        while (true)
        {
            if (boxList.Count > 0)
            {
                
                GameObject temp = Instantiate(moneyPrefab);
                temp.transform.position = new Vector3(moneyDropPoint.position.x + ((float)moneyList.Count/10), 0.80f, moneyDropPoint.position.z);
                moneyList.Add(temp);
                RemoveLast();
            }
            yield return new WaitForSeconds(1f);
        }
        
    }
    public void GetBox()
    {
        int boxCount = boxList.Count;
        int rowCount = (int)boxCount / stackCount;
        GameObject temp = Instantiate(boxPrefab);
        temp.transform.position = new Vector3(boxPoint.position.x + ((float)rowCount / 2),0.80f, boxPoint.position.z);
        boxList.Add(temp);

    }

    public void RemoveLast()
    {
        if (boxList.Count > 0)
        {
            Destroy(boxList[boxList.Count - 1]);
            boxList.RemoveAt(boxList.Count - 1);
        }
    }
}
