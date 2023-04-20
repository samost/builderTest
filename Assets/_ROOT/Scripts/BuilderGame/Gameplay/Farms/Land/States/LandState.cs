
using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.States;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States
{
    public abstract class LandState: IState
    {
        protected LandPiece _landPiece;
        protected LandStateMachine LandStateMachine;

        protected LandState(LandPiece landPiece, LandStateMachine landStateMachine)
        {
            _landPiece = landPiece;
            LandStateMachine = landStateMachine;
        }

        public virtual void Enter()
        {
            _landPiece.WeaponType = GetValidWeaponType();
        }

        public virtual void Exit()
        {
            
        }

        public virtual void Update()
        {
           
        }

        public abstract WeaponType GetValidWeaponType();
    }
}