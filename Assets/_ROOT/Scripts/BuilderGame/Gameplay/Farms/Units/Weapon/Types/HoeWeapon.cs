using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types
{
    public class HoeWeapon: UnitWeapon
    {
        [SerializeField]
        private ParticleSystem _hitFx;
        [Inject]
        private CinemachineImpulseSource _impulseSource;
        
        public override WeaponType WeaponType => WeaponType.Hoe;
        protected override float ChangeDuration => 0.5f;
        public override void PlayFx()
        {
            _impulseSource.GenerateImpulseWithForce(0.05f);
            _hitFx.Play();
        }
    }
}