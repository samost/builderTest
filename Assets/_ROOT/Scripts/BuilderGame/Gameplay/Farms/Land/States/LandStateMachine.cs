using System;
using System.Collections;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States.Types;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States
{
    public class LandStateMachine
    {
        private const float ChangeDelay = 0.76f;
        
        private LandState _currentState;

        public LandPiece LandPiece
        {
            get;
        }
        
        private GrassLandState _grassLandState;
        private DirtLandState _dirtLandState;
        private SeedLandState _seedLandState;
        private DoneLandState _doneLandState;

        public GrassLandState GrassLandState => _grassLandState;
        public DirtLandState DirtLandState => _dirtLandState;
        public SeedLandState SeedLandState => _seedLandState;
        public DoneLandState DoneLandState => _doneLandState;

        public LandStateMachine(LandPiece landPiece)
        {
            LandPiece = landPiece;
            _grassLandState = new GrassLandState(this);
            _dirtLandState = new DirtLandState(this);
            _seedLandState = new SeedLandState(this);
            _doneLandState = new DoneLandState(this);
        }

        public void ChangeState(LandState landState)
        {
            _currentState?.Exit();
            _currentState = landState;
            _currentState.Enter();
        }

        public void Hit()
        {
            _currentState.Update();
        }

        public WeaponType GetValidWeaponType()
        {
            return _currentState.GetValidWeaponType();
        }
        
    }
}