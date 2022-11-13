using System.Transactions;
using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int  openingDirection;
    //1 -> B
    //2 -> T
    //3 -> L
    //4 -> R

    private RoomTemplates templates;
    private int rand;
    private int randRoom;
    public bool spawned = false;

    private void Start() {
        Destroy(gameObject, 4f);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn() {
        
        if (spawned == false)
        {
        if(openingDirection == 1){
            // Spawns bottom door.
            rand = UnityEngine.Random.Range(0, templates.bottomRooms.Length);
            randRoom = UnityEngine.Random.Range(0,1);
            if(randRoom%2 == 1 && templates.spawnedBossRoom == false && templates.waitTime > 0.2f){
                Instantiate(templates.bossRooms[0], transform.position, UnityEngine.Quaternion.identity);
            }else{
            Instantiate(templates.bottomRooms[rand], transform.position, UnityEngine.Quaternion.identity);
            }
        }else if(openingDirection == 2)
        {
            // Spawns top door.
            rand = UnityEngine.Random.Range(0, templates.topRooms.Length);
            randRoom = UnityEngine.Random.Range(0,2);

            if(randRoom%2 == 1 && templates.spawnedBossRoom == false && templates.waitTime > 0.2f){
                Instantiate(templates.bossRooms[3], transform.position, UnityEngine.Quaternion.identity);
            }else{
            Instantiate(templates.topRooms[rand], transform.position, UnityEngine.Quaternion.identity);
            }
        }else if(openingDirection == 3){
            // Spawns left door.
            rand = UnityEngine.Random.Range(0, templates.leftRooms.Length);
            randRoom = UnityEngine.Random.Range(0,2);

            if(randRoom%2 == 0 && templates.spawnedBossRoom == false && templates.waitTime > 0.2f){
                Instantiate(templates.bossRooms[1], transform.position, UnityEngine.Quaternion.identity);
            }else {
            Instantiate(templates.leftRooms[rand], transform.position, UnityEngine.Quaternion.identity);
            }
        }else
        {
            //spawn right door.
            rand = UnityEngine.Random.Range(0, templates.rightRooms.Length);
            randRoom = UnityEngine.Random.Range(0,2);

            if(randRoom%2 == 0 && templates.spawnedBossRoom == false && templates.waitTime > 0.2f){
                Instantiate(templates.bossRooms[2], transform.position, UnityEngine.Quaternion.identity);
            }else{
            Instantiate(templates.rightRooms[rand], transform.position, UnityEngine.Quaternion.identity);
            }
        }

        spawned = true;
    }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("SpawnPoint")){
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
                Destroy(gameObject);
            }
            spawned = true;
        }

    }
}
