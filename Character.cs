namespace Parcial2
{
    public enum CharacterClass
    {
        Human,
        Beast,
        Hybrid,
        Any,
    }

    public class Character
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int BaseAttackPoints { get; set; }
        public int BaseDefensePoints { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public CharacterClass Class { get; set; }

        public Character(string name, int hitPoints, int baseAttackPoints, int baseDefensePoints, CharacterClass characterClass)
        {
            if (hitPoints < 1)
                throw new ArgumentException("The character's hit points cannot be less than 1.");
            Name = name;
            HitPoints = hitPoints;
            BaseAttackPoints = baseAttackPoints;
            BaseDefensePoints = baseDefensePoints;
            Class = characterClass;
        }

        public void Attack(Character opponent)
        {
            if (opponent == null)
                throw new ArgumentNullException(nameof(opponent), "The opponent cannot be null.");
            if (HitPoints <= 0)
                throw new InvalidOperationException("The character cannot attack because it is dead.");

            if (EquippedWeapon != null)
            {
                if (opponent.EquippedArmor == null)
                {
                    int attackPoints = BaseAttackPoints + EquippedWeapon.Power;
                    opponent.HitPoints -= attackPoints;
                    EquippedWeapon.ReduceDurability();
                    if (EquippedWeapon.Durability <= 0)
                        EquippedWeapon = null;
                }
                else
                {
                    opponent.EquippedArmor.ReduceDurability((int)Math.Floor(EquippedWeapon.Power / 2.0));
                    EquippedWeapon.ReduceDurability();
                    if (EquippedWeapon.Durability <= 0)
                        EquippedWeapon = null;
                }
            }
            else
            {
                if (opponent.EquippedArmor == null)
                {
                    int attackPoints = BaseAttackPoints;
                    opponent.HitPoints -= attackPoints;
                }
                else
                {
                    opponent.EquippedArmor.ReduceDurability((int)Math.Floor(BaseAttackPoints / 2.0));
                }
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon), "The weapon cannot be null.");
            if (weapon.Durability <= 0)
                throw new InvalidOperationException("The weapon is broken and cannot be equipped.");

            if (Class == CharacterClass.Any || Class == weapon.Class)
                EquippedWeapon = weapon;
            else
                throw new InvalidOperationException("The character cannot equip this weapon due to its class.");
        }

        public void EquipArmor(Armor armor)
        {
            if (armor == null)
                throw new ArgumentNullException(nameof(armor), "The armor cannot be null.");
            if (armor.Durability <= 0)
                throw new InvalidOperationException("The armor is broken and cannot be equipped.");

            if (Class == CharacterClass.Any || Class == armor.Class)
                EquippedArmor = armor;
            else
                throw new InvalidOperationException("The character cannot equip this armor due to its class.");
        }
    }
}