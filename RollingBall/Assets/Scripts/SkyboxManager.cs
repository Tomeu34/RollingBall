using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public static SkyboxManager instance;
    private Material currentSkybox;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener este objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        currentSkybox = RenderSettings.skybox; // Guardar el Skybox actual
    }

    void OnLevelWasLoaded(int level)
    {
        RenderSettings.skybox = currentSkybox; // Restaurar el Skybox al cambiar de escena
        DynamicGI.UpdateEnvironment(); // Actualizar iluminación global
    }

    public void ChangeSkybox(Material newSkybox)
    {
        currentSkybox = newSkybox;
        RenderSettings.skybox = newSkybox;
        DynamicGI.UpdateEnvironment();
    }
}
