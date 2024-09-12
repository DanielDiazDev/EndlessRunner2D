using UnityEngine;

public class MenuInstaller : MonoBehaviour
{
    [SerializeField] private SoundSystem _soundSystem;
    private void Awake()
    {
        ServiceLocator.Instance.RegisterService(_soundSystem);
    }
}
