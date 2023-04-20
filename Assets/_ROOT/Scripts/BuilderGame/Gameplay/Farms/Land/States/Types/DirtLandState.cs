using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States.Types
{
    public class DirtLandState: LandState
    {
        public DirtLandState(LandPiece landPiece, LandStateMachine landStateMachine) : base(landPiece, landStateMachine)
        {
        }

        public override WeaponType GetValidWeaponType()
        {
            return WeaponType.Seeds;
        }
    }
}