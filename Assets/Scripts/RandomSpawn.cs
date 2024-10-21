using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject respawnArea;
    [SerializeField] BoxCollider respawnRange;
    Coroutine randomPosSpawn;

    private void Start()
    {
        respawnRange = respawnArea.GetComponent<BoxCollider>();

        StartCoroutine(RandomPosSpawn());
    }

    private Vector3 RandomPosition()
    {
        Vector3 originPos = respawnArea.transform.position;
        float posX = respawnRange.bounds.size.x;
        float posY = respawnRange.bounds.size.y;

        posX = Random.Range((posX / 2) * -1, posX / 2);
        posY = Random.Range((posY / 2) * -1, posY / 2);
        Vector3 randomPos = new Vector3(posX, posY, 0f);

        Vector3 respawnPos = originPos + randomPos;
        return respawnPos;
    }

    IEnumerator RandomPosSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);

            GameObject shootTarget = Instantiate(target, RandomPosition(), Quaternion.identity);
        }
    }
}
