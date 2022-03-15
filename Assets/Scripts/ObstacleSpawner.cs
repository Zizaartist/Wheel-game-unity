using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject ObstacleTopPrefab;
    public GameObject ObstacleSidesPrefab;
    public Score score;

    [SerializeField]
    private float DifficultyCoef;
    [SerializeField]
    [Min(0)]
    private float MinInterval;
    [SerializeField]
    [Min(0)]
    private float MaxInterval;
    public float SpawningInterval
    {
        get
        {
            // \frac{1}{\left(\frac{x}{400}+0.15\right)}=y
            var handicap = 0.5f * MaxInterval;
            var x = (score.TimePlayed / DifficultyCoef) + handicap;
            Debug.Log($"{x}--{MinInterval + (MaxInterval / (x))}");
            return MinInterval + MaxInterval / (x);
        }
    }

    private List<GameObject> obstacles = new List<GameObject>();

    private void OnEnable() {
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpawningInterval);
            var obstacleChoice = (int)(Random.value * 2);
            var instance = Instantiate(obstacleChoice == 0 ? ObstacleTopPrefab : ObstacleSidesPrefab, 
                this.transform.position, this.transform.rotation);
            obstacles.Add(instance);
        }
    }

    public void ClearObstacles() 
    {
        obstacles.ForEach(obs => Destroy(obs));
        obstacles.Clear();
    }
}
