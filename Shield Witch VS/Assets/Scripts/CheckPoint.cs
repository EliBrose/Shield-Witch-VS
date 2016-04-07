using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    // Indicate if the checkpoint is activated
    public bool activated = false;

    // List with all checkpoint objects in the scene
    public static GameObject[] CheckPointsList;

    // Use this for initialization
    void Start () {
        // searches for all the checkpoints in the scene via tag
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint");
    }

    private void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<CheckPoint>().activated = false;
            //cp.GetComponent<CheckPoint>().SetBool("Active", false);
        }
        // We activate the current checkpoint
        activated = true;
    }

    // Get position of the last activated checkpoint
    public static Vector3 GetActiveCheckPointPosition()
    {
        // If player die without activate any checkpoint, we will return a default position
        Vector3 result = new Vector3(0, 0, 0);
        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<CheckPoint>().activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }
        return result;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "Player")
        {
            ActivateCheckPoint();
        }
    }
}
