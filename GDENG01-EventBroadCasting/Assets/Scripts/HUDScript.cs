using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HUDScript : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    private Button cubeSpawnerButton;
    [SerializeField]
    private Button sphereSpawnerButton;
    // Start is called before the first frame update
    public void SpawnCube()
    {
        int numberOfCubes = int.Parse(inputField.text);
        Parameters parameters = new Parameters();
        parameters.PutExtra("NUM_CUBES_KEY", numberOfCubes);

        EventBroadcaster.Instance.PostEvent(EventNames.X22_Events.ON_SPAWN_CUBES, parameters);

    }

    public void SpawnSphere()
    {
        int numberOfSpheres = int.Parse(inputField.text);
        Parameters parameters = new Parameters();
        parameters.PutExtra("NUM_SPAWN_SPHERES", numberOfSpheres);

        EventBroadcaster.Instance.PostEvent(EventNames.X22_Events.ON_SPAWN_SPHERE, parameters);

    }

    public void ClearScene()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.X22_Events.CLEAR_SCENE);
    }
}
