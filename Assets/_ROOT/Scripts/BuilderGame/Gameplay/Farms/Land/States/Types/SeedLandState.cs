using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using BuilderGame.Gameplay.Farms.Data;
using DG.Tweening;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States.Types
{
    public class SeedLandState: LandState
    {
        private SeedData _seedData;
        public SeedLandState(LandStateMachine landStateMachine) : base(landStateMachine)
        {
        }
        

        public override WeaponType GetValidWeaponType()
        {
            return WeaponType.Hands;
        }

        public override void Enter()
        {
            base.Enter();
            StartGrowth();
        }

        public void AddSeedData(SeedData seedData)
        {
            _seedData = seedData;
        }

        private void StartGrowth()
        {
            _landStateMachine.LandPiece.SeedRoot.SetActive(true);
            _landStateMachine.LandPiece.SeedRoot.transform.DOLocalMoveY(0.21f, _seedData.TimeGrowth).OnComplete((EndGrowth));
        }

        private void EndGrowth()
        {
            GameObject.Instantiate(_seedData.ResultPlant, _landStateMachine.LandPiece.transform);
            _landStateMachine.ChangeState(_landStateMachine.DoneLandState);
        }
    }
}