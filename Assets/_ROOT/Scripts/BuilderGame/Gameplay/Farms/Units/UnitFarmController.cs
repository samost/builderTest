using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using BuilderGame.Gameplay.Farms.Data;
using BuilderGame.Gameplay.Unit.Animation;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units
{
    public class UnitFarmController: MonoBehaviour, IFitterable
    {
        //можно поменять и прокидвать динамически оставлю так
        [SerializeField]
        private SeedData _currentSeed;

        public SeedData SeedData => _currentSeed;
        
        
        //Для того чтобы анимки нормально миксовались
        private const float DelayBeforeWork = 2f;
        
        [SerializeField]
        private UnitWeaponChanger _unitWeaponChanger;
        [SerializeField]
        private UnitAnimator _unitAnimator;

        private LandPiece _currentLand;

        private float _nextWorkTime;
        

        private void OnTriggerExit(Collider collider)
        {
            TryCancelWork(collider);
        }

        private void OnTriggerStay(Collider collider)
        {
            if (Time.realtimeSinceStartup >= _nextWorkTime)
            {
                LandPiece landPiece = collider.GetComponent<LandPiece>();
                TryWork(landPiece);
            }
        }

        private void TryWork(LandPiece landPiece)
        {
            _currentLand = landPiece != null ? landPiece : null;

            if (_currentLand != null)
            {
                _currentLand.Fitter = this;
                _unitWeaponChanger.ChangeWeapon(_currentLand.WeaponType);
                _unitAnimator.ToggleWorkAnimation(_currentLand.WeaponType);

                _unitAnimator.AnimationEventEmitter.OnTriggered += AnimationEventEmitter_OnTriggered;
                _currentLand.SendSeedData(SeedData);
            }
            
            _nextWorkTime = Time.realtimeSinceStartup + DelayBeforeWork;
        }

        private void TryCancelWork(Collider collider)
        {
            LandPiece landPiece = collider.GetComponent<LandPiece>();

            if (landPiece!= null)
            {
                landPiece.Fitter = null;
                
                if (landPiece == _currentLand)
                {
                    _currentLand = null;
                    _unitWeaponChanger.ChangeWeapon(WeaponType.Hands);
                    _unitAnimator.ToggleWorkAnimation(WeaponType.Hands);
                }
            }
            
        }

        private void AnimationEventEmitter_OnTriggered()
        {
            _unitAnimator.AnimationEventEmitter.OnTriggered -= AnimationEventEmitter_OnTriggered;
            _currentLand.Hit();
            _unitWeaponChanger.CurrentWeapon.PlayFx();
        }
    }
    
}