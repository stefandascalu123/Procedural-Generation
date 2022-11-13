using System.Timers;
using System;
using System.ComponentModel;
using System.Runtime.Versioning;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public GameObject[] bossRooms;

    public List<GameObject> rooms;

    public bool spawnedBossRoom = false;

    public float waitTime;

    private void FixedUpdate() {
       waitTime += Time.deltaTime; 
    }
}
