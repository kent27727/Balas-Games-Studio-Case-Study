using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> boxList2 = new List<GameObject>();
    public GameObject boxPrefab2;
    public Transform collectPoint;

    public static int boxLimit = 2;

    

    private void OnEnable()
    {
        TriggerManager.OnBoxCollect += GetBox;
        TriggerManager.OnBoxGive +=GiveBox;
    }

    private void OnDisable()
    {
        TriggerManager.OnBoxCollect -= GetBox;
        TriggerManager.OnBoxGive -= GiveBox;
    }

    void GetBox()
    {
        if (boxList2.Count <= boxLimit)
        {
            GameObject temp = Instantiate(boxPrefab2, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, 0.5f+((float)boxList2.Count / 20), collectPoint.position.z);
            boxList2.Add(temp);
            if (TriggerManager.boxManager != null)
            {
                TriggerManager.boxManager.RemoveLast();
            }

        }
    }

    public void GiveBox()
    {
        if (boxList2.Count > 0)
        {
            TriggerManager.workerManager.GetBox();
            RemoveLast();
        }
    }

    public void RemoveLast()
    {
        if (boxList2.Count > 0)
        {
            Destroy(boxList2[boxList2.Count - 1]);
            boxList2.RemoveAt(boxList2.Count - 1);
        }
    }

    public void PowerUpBoxLimit()
    {
        boxLimit += 1;
    }



}
