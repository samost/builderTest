using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using BuilderGame.Gameplay.Unit.Animation;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units
{
    public class UnitFarmController: MonoBehaviour
    {
        [SerializeField]
        private UnitWeaponChanger _unitWeaponChanger;
        [SerializeField]
        private UnitAnimator _unitAnimator;

        [Inject]
        private CinemachineImpulseSource _impulseSource;
        
        private LandPiece _currentLand;
        
        private void OnTriggerEnter(Collider collider)
        {
            TryWork(collider);
        }

        private void OnTriggerExit(Collider collider)
        {
            TryCancelWork(collider);
        }

        private void TryWork(Collider collider)
        {
            LandPiece landPiece = collider.GetComponent<LandPiece>();
            _currentLand = landPiece != null ? landPiece : null;

            if (_currentLand != null)
            {
                _unitWeaponChanger.ChangeWeapon(_currentLand.WeaponType);
                _unitAnimator.ToggleHoeWorkAnimation(true);
                _unitAnimator.AnimationEventEmitter.OnTriggered += AnimationEventEmitter_OnTriggered;
            }
        }

        private void TryCancelWork(Collider collider)
        {
            LandPiece landPiece = collider.GetComponent<LandPiece>();

            if (landPiece == _currentLand)
            {
                _currentLand = null;
                //_unitWeaponChanger.ChangeWeapon(WeaponType.Hands);
                _unitAnimator.ToggleHoeWorkAnimation(false);
            }
        }

        private void AnimationEventEmitter_OnTriggered()
        {
            _currentLand.Hit();

            if (_currentLand.WeaponType == WeaponType.Hoe)
            {
                _impulseSource.GenerateImpulseWithForce(0.05f);
            }
        }
    }
}