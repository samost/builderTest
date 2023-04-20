using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States.Types;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States
{
    public class LandStateMachine
    {
        private LandState _currentState;
        
        private GrassLandState _grassLandState;
        private DirtLandState _dirtLandState;
        private SeedLandState _seedLandState;

        public GrassLandState GrassLandState => _grassLandState;
        public DirtLandState DirtLandState => _dirtLandState;
        public SeedLandState SeedLandState => _seedLandState;

        public LandStateMachine(LandPiece landPiece)
        {
            _grassLandState = new GrassLandState(landPiece, this);
            _dirtLandState = new DirtLandState(landPiece, this);
            _seedLandState = new SeedLandState(landPiece, this);
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