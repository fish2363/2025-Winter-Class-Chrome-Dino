using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    public float SpawnDelay = 3f;
    private float currentTime = 0;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= SpawnDelay)
        {
            int randomIndex = Random.Range(0, 4);
            
            GameObject obstacle = Instantiate(obstacles[randomIndex]
                , transform.position, Quaternion.identity);

            //프테라일 경우 y값 조정도 필요함
            if (randomIndex == 3) 
            {
                float positionY = transform.position.y;
                obstacle.transform.position = new Vector3(transform.position.x
                    , Random.Range(positionY, positionY + 2f), transform.position.z);
            }
            
            currentTime = 0;
        }
    }
}
