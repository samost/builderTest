using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using DG.Tweening;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States.Types
{
    public class GrassLandState: LandState
    {
        //Можно вынести в конфиг и прокинуть сюда)))
        private const int HitCountToTransition = 1;
        
        private int _hoeHitCounter;


        public GrassLandState(LandStateMachine landStateMachine) : base(landStateMachine)
        {
        }

        public override void Update()
        {
            base.Update();
            _hoeHitCounter++;

            if (_hoeHitCounter >= HitCountToTransition)
            {
                _landStateMachine.ChangeState(_landStateMachine.DirtLandState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _hoeHitCounter = 0;
        }

        public override WeaponType GetValidWeaponType()
        {
            return WeaponType.Hoe;
        }
    }
}