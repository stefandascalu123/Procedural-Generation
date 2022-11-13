using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomSpawner : MonoBehaviour
{
    private RoomTemplates eventObject;
    // Start is called before the first frame update
    void Start()
    {
        eventObject = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        eventObject.spawnedBossRoom = true;
    }
}
