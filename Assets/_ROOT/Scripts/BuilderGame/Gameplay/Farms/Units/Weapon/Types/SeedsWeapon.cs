using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types
{
    public class SeedsWeapon: UnitWeapon
    {
        public override WeaponType WeaponType => WeaponType.Seeds;
        protected override float ChangeDuration => 0.7f;
    }
}