using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRespawn : MonoBehaviour
{
    [SerializeField] GameObject spawnArea;
    private BoxCollider spawnRange;
    [SerializeField] GameObject target;
    Coroutine randomSpawn;

    private void Start()
    {
        spawnRange = spawnArea.GetComponent<BoxCollider>();

        StartCoroutine(RandomSpawn());
    }

    private Vector3 RandomArea()
    {
        Vector3 originPos = spawnArea.transform.position;
        float posX = spawnRange.bounds.size.x;
        float posY = spawnRange.bounds.size.y;

        posX = Random.Range((posX / 2) * -1, posX / 2);
        posY = Random.Range((posY / 2) * -1, posY / 2);
        Vector3 randomPos = new Vector3(posX, posY, 0);

        Vector3 respawnPos = originPos + randomPos;
        return respawnPos;
    }

    IEnumerator RandomSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);

            GameObject respawnTarget = Instantiate(target, RandomArea(), Quaternion.identity);
            Destroy(respawnTarget, 5.0f);
        }
    }
}
