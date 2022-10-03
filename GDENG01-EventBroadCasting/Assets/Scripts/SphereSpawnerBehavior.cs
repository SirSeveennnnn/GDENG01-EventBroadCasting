using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawnerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject template;

    private List<GameObject> spawnList = new List<GameObject>();
    public const string NUM_SPAWN_SPHERES = "NUM_SPAWN_SPHERES";

    // Start is called before the first frame update
    void Start()
    {
        this.template.SetActive(false);
        EventBroadcaster.Instance.AddObserver(EventNames.X22_Events.ON_SPAWN_SPHERE, onSpawnSphere);
        EventBroadcaster.Instance.AddObserver(EventNames.X22_Events.CLEAR_SCENE, this.ClearScene);
    }


    public void onSpawnSphere(Parameters parameters)
    {
        int spawnCount = parameters.GetIntExtra(NUM_SPAWN_SPHERES, 1);

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject spawnCopy = GameObject.Instantiate(this.template, this.transform);
            spawnList.Add(spawnCopy);
            spawnCopy.SetActive(true);

        }
    }

    private void ClearScene()
    {
        for (int i = spawnList.Count - 1; i >= 0; i--)
        {
            Destroy(spawnList[i]);
        }
        spawnList.Clear();
    }
}
