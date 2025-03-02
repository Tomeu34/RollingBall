using UnityEngine;

public class SkyboxChange : MonoBehaviour
{

    [SerializeField] private Material[] skyboxes;

    public void ChangeSkybox(int index)
    {

        RenderSettings.skybox = skyboxes[index];
        DynamicGI.UpdateEnvironment();

        SkyboxManager.instance.ChangeSkybox(skyboxes[index]);
    }
}
