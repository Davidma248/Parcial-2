using NUnit.Framework;
using Parcial2;

namespace Parcial2Tests1
{
    [TestFixture]
    public class CombatTests
    {
        [Test]
        public void TestAttackWithoutArmor()
        {
            Character attacker = new Character("John", 100, ClassType.Warrior);
            Character defender = new Character("Jane", 100, ClassType.Mage);
            Weapon weapon = new Weapon("Sword", 10, WeaponType.Sword, 3);
            attacker.EquipWeapon(weapon);

            int expectedDamage = 10;
            int expectedDefenderHealth = defender.Health - expectedDamage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedDefenderHealth, defender.Health);
        }

        [Test]
        public void TestAttackWithArmor()
        {
            Character attacker = new Character("John", 100, ClassType.Warrior);
            Character defender = new Character("Jane", 100, ClassType.Mage);
            Weapon weapon = new Weapon("Sword", 10, WeaponType.Sword, 3);
            Armor armor = new Armor("Leather", 5, ArmorType.Light, 5);
            attacker.EquipWeapon(weapon);
            defender.EquipArmor(armor);

            int expectedArmorDurability = armor.Durability - 5;
            int expectedDefenderHealth = defender.Health;

            attacker.Attack(defender);

            Assert.AreEqual(expectedArmorDurability, armor.Durability);
            Assert.AreEqual(expectedDefenderHealth, defender.Health);
        }

        [Test]
        public void TestAttackWithoutWeapon()
        {
            Character attacker = new Character("John", 100, ClassType.Warrior);
            Character defender = new Character("Jane", 100, ClassType.Mage);
            Armor armor = new Armor("Leather", 5, ArmorType.Light, 5);
            defender.EquipArmor(armor);

            int expectedArmorDurability = armor.Durability - 2;
            int expectedDefenderHealth = defender.Health;

            attacker.Attack(defender);

            Assert.AreEqual(expectedArmorDurability, armor.Durability);
            Assert.AreEqual(expectedDefenderHealth, defender.Health);
        }

        [Test]
        public void TestAttackBreaksWeapon()
        {
            Character attacker = new Character("John", 100, ClassType.Warrior);
            Character defender = new Character("Jane", 100, ClassType.Mage);
            Weapon weapon = new Weapon("Sword", 10, WeaponType.Sword, 1);
            defender.EquipArmor(new Armor("Leather", 5, ArmorType.Light, 5));
            attacker.EquipWeapon(weapon);

            int expectedWeaponDurability = weapon.Durability - 1;
            int expectedDefenderHealth = defender.Health;

            attacker.Attack(defender);

            Assert.AreEqual(expectedWeaponDurability, weapon.Durability);
            Assert.IsFalse(attacker.IsEquipped(weapon));
            Assert.AreEqual(expectedDefenderHealth, defender.Health);
        }

        [Test]
        public void TestArmorBreaks()
        {
            Character attacker = new Character("John", 100, ClassType.Warrior);
            Character defender = new Character("Jane", 100, ClassType.Mage);
            Weapon weapon = new Weapon("Sword", 10, WeaponType.Sword, 10);
            Armor armor = new Armor("Leather", 5, ArmorType.Light, 1);
            attacker.EquipWeapon(weapon);
            defender.EquipArmor(armor);

            int expectedArmorDurability = armor.Durability - 1;
            int expectedDefenderHealth = defender.Health - (weapon.Damage - armor.Protection);

           
    attacker.Attack(defender);

            Assert.AreEqual(expectedArmorDurability, armor.Durability);
            Assert.AreEqual(expectedDefenderHealth, defender.Health);
        }
    }
}


