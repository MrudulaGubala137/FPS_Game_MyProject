using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject[] enemyPrefab;
    public int radius;
    public int spawnNumber;
    void Start()
    {
        for(int i=0;i<spawnNumber;i++)
        {
            

                Vector3 randomPoint = transform.position + Random.insideUnitSphere * radius;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
                {
                   
                    Instantiate(enemyPrefab[0], randomPoint, Quaternion.identity);

                }
                else
                    i--;
            }
        }
        
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
