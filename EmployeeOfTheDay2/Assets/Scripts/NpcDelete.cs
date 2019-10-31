using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDelete : MonoBehaviour
{
    public GameObject npcPrefab;
    public Transform spawnpoints;
    private void Start()
    {
        Instantiate(npcPrefab, spawnpoints.position, spawnpoints.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            GameObject.Find("Seating").GetComponent<Seating>().canLeave = false;

            Destroy(other.gameObject);

            Instantiate(npcPrefab, spawnpoints.position, spawnpoints.rotation);
        }
    }
}
