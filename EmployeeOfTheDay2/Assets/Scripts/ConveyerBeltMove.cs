using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBeltMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector3 target = Vector3.zero;
    public BoxCollider[] colliders = null;
    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> deleteMark = new List<GameObject>();
    void Start()
    {
        colliders = GetComponents<BoxCollider>();
    }

    void Update()
    {
        foreach (var i in targets)
        {
            if (i.GetComponent<ObjectData>().gameObjectData["Moving"] == this.gameObject)
            {
                i.transform.position = Vector3.MoveTowards(i.transform.position, new Vector3(transform.position.x + target.x, i.transform.position.y, transform.position.z + target.z), Time.deltaTime * moveSpeed);
                if (target.x != 0)
                {
                    if (transform.position.x + target.x == i.transform.position.x)
                    {
                        deleteMark.Add(i.gameObject);
                    }
                }
                else
                {
                    if (transform.position.z + target.z == i.transform.position.z)
                    {
                        deleteMark.Add(i.gameObject);
                    }
                }
            }
            else if (i.GetComponent<ObjectData>().gameObjectData["Moving"] == null)
            {
                i.GetComponent<ObjectData>().gameObjectData["Moving"] = this.gameObject;
                i.transform.position = Vector3.MoveTowards(i.transform.position, new Vector3(transform.position.x + target.x, i.transform.position.y, transform.position.z + target.z), Time.deltaTime * moveSpeed);
            }
        }
        foreach (var i in deleteMark)
        {
            targets.Remove(i);
            i.GetComponent<ObjectData>().gameObjectData["Moving"] = null;
        }
        deleteMark.Clear();
    }

    void OnCollisionEnter(Collision col)
    {
        bool exists = false;
        foreach (var i in targets)
        {
            if (col.gameObject == i) exists = true;
        }
        if (!exists)
        {
            targets.Add(col.gameObject);
            if (!col.gameObject.GetComponent<ObjectData>().gameObjectData.ContainsKey("Moving"))
            {
                col.gameObject.GetComponent<ObjectData>().gameObjectData.Add("Moving", this.gameObject);
            }
        }
    }
}