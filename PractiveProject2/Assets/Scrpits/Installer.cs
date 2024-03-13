using System;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(IStatus), typeof(IGround))
            .WithId("Player").To<Player_Charp>().AsSingle();
        Container.Bind(typeof(IInput))
            .WithId("Player").To<PlayerInput_CSharp>().AsSingle();
        Container.Bind<IFixedTickable>()
            .To<PlayerController_CSharp>().AsSingle().NonLazy();
    }
}