using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public Player player;
    public Transform simple;
    public Transform simpleUp;
    public Transform downLeftDanger;
    public Transform downRightDanger;
    public Transform upLeftDanger;
    public Transform upRightDanger;
    float rememberedPos = 0f;
    float realOffset = 0;
    float previousPos = 0f;
    bool dangerRight = false;

    public Queue<Transform> platforms = new Queue<Transform>();

    private void Start()
    {
        SpawnPlatforms();
    }

    public void SpawnPlatforms()
    {
        for (int i = 1; i < 10; i++)
        {
            SpawnOnBottom(realOffset);
            SpawnOnTop(realOffset);
        }
    }

    void SpawnOnTop(float offset)
    {
        float ran = Random.Range(-10f, -4f);
        Vector3 newPos = new Vector3(0f, 10f, offset + ran);
        Transform go;
        if (newPos.z - previousPos > 20)
        {
            newPos = new Vector3(newPos.x, newPos.y, newPos.z - 10f);
            go = Instantiate(simpleUp, newPos, Quaternion.identity, transform);
            dangerRight = false;
        }
        else if (newPos.z - previousPos > 15 && dangerRight)
        {
            newPos = new Vector3(newPos.x, newPos.y, newPos.z - 5f);
            go = Instantiate(simpleUp, newPos, Quaternion.identity, transform);
            dangerRight = false;
        }
        else if(newPos.z - previousPos < 12)
        {
            go = Instantiate(upLeftDanger, newPos, Quaternion.identity, transform);
            dangerRight = false;
        }
        else
        {
            go = Instantiate(upRightDanger, newPos, Quaternion.identity, transform);
            dangerRight = true;
        }
        platforms.Enqueue(go);
        previousPos = realOffset + ran;
        realOffset += 20f + ran;
    }

    void SpawnOnBottom(float offset)
    {
        float ran = Random.Range(-4f, 4f);
        Vector3 newPos = new Vector3(0f, 0f, offset + ran);
        Transform go;
        if(newPos.z - previousPos > 20)
        {
            newPos = new Vector3(newPos.x, newPos.y, newPos.z - 10f);
            go = Instantiate(simple, newPos, Quaternion.identity, transform);
            dangerRight = false;
        }
        else if (newPos.z - previousPos > 15 && dangerRight)
        {
            newPos = new Vector3(newPos.x, newPos.y, newPos.z - 5f);
            go = Instantiate(simple, newPos, Quaternion.identity, transform);
            dangerRight = false;
        }
        else if (newPos.z - previousPos < 5)
        {
            go = Instantiate(downLeftDanger, newPos, Quaternion.identity, transform);
            dangerRight = false;
        }
        else
        {
            go = Instantiate(downRightDanger, newPos, Quaternion.identity, transform);
            dangerRight = true;
        }
        platforms.Enqueue(go);
        previousPos = realOffset + ran;
        realOffset += 20f + ran;
    }

    void SpawnOnTop()
    {
        Transform go = Instantiate(simple, new Vector3(0f, 10f, player.transform.position.z), Quaternion.identity, transform);
        platforms.Enqueue(go);
    }

    void SpawnOnBottom()
    {
        Transform go = Instantiate(simple, new Vector3(0f, 0f, player.transform.position.z), Quaternion.identity, transform);
        platforms.Enqueue(go);
    }

    void DestroyPlatform()
    {
        Destroy(platforms.Dequeue().gameObject, 5f);
        Destroy(platforms.Dequeue().gameObject, 5f);
    }

    private void Update()
    {
        if(player.transform.position.z - rememberedPos >= 40)
        {
            rememberedPos = player.transform.position.z;
            DestroyPlatform();
            SpawnOnBottom(realOffset);
            SpawnOnTop(realOffset);
        }
    }
}
