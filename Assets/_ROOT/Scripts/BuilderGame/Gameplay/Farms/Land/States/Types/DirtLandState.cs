using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using DG.Tweening;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States.Types
{
    public class DirtLandState: LandState
    {
        //Можно вынести в конфиг и прокинуть сюда)))
        private const int HitCountToTransition = 1;
        
        private const float TransitionDuration = 0.5f;
        private readonly Color DirtColor = new Color(212/255f, 106/255f, 55/255f);

        private int _seedCounter;


        public DirtLandState(LandStateMachine landStateMachine) : base(landStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _landStateMachine.LandPiece.MeshRenderer.material.DOColor(DirtColor,  TransitionDuration);
        }

        public override void Update()
        {
            base.Update();
            
            _seedCounter++;
            if (_seedCounter >= HitCountToTransition)
            {
                _landStateMachine.ChangeState(_landStateMachine.SeedLandState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _seedCounter = 0;
        }

        public override WeaponType GetValidWeaponType()
        {
            return WeaponType.Seeds;
        }
    }
}