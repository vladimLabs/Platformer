using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerHealth _playerHealth;

    public override void InstallBindings()
    {
        Container.Bind<PlayerMovement>().FromInstance(_playerMovement).AsSingle();
        Container.Bind<PlayerHealth>().FromInstance(_playerHealth).AsSingle();
    }
}
