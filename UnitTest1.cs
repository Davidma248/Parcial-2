using NUnit.Framework;
using Parcial2;

namespace Parcial2Tests
{
    public class Tests
    {
        [Test]
        public void Character_HitPointsCannotBeNegative()
        {
            Assert.Throws<ArgumentException>(() => new Character("Test", -1, 10, 10, CharacterClass.Human));
        }

        [Test]
        public void Weapon_PowerCannotBeZero()
        {
            Assert.Throws<ArgumentException>(() => new Weapon("Test", 0, 10, CharacterClass.Any));
        }

        [Test]
        public void Armor_DefenseCannotBeNegative()
        {
            Assert.Throws<ArgumentException>(() => new Armor("Test", -1, 10, CharacterClass.Any));
        }

        [Test]
        public void Weapon_DurabilityCannotBeZero()
        {
            Assert.Throws<ArgumentException>(() => new Weapon("Test", 10, 0, CharacterClass.Any));
        }

        [Test]
        public void Armor_DurabilityCannotBeZero()
        {
            Assert.Throws<ArgumentException>(() => new Armor("Test", 10, 0, CharacterClass.Any));
        }

        [Test]
        public void Character_CannotEquipWeaponOfDifferentClass()
        {
            var character = new Character("Test", 10, 10, 10, CharacterClass.Human);
            var weapon = new Weapon("Test", 10, 10, CharacterClass.Beast);
            Assert.Throws<InvalidOperationException>(() => character.EquipWeapon(weapon));
        }

        [Test]
        public void Character_CanEquipWeaponOfSameClass()
        {
            var character = new Character("Test", 10, 10, 10, CharacterClass.Human);
            var weapon = new Weapon("Test", 10, 10, CharacterClass.Human);
            character.EquipWeapon(weapon);
            Assert.AreEqual(weapon, character.EquippedWeapon);
        }

        [Test]
        public void Character_CanEquipAnyWeapon()
        {
            var character = new Character("Test", 10, 10, 10, CharacterClass.Human);
            var weapon = new Weapon("Test", 10, 10, CharacterClass.Any);
            character.EquipWeapon(weapon);
            Assert.AreEqual(weapon, character.EquippedWeapon);
        }

        [Test]
        public void Character_CannotEquipArmorOfDifferentClass()
        {
            var character = new Character("Test", 10, 10, 10, CharacterClass.Human);
            var armor = new Armor("Test", 10, 10, CharacterClass.Beast);
            Assert.Throws<InvalidOperationException>(() => character.EquipArmor(armor));
        }

        [Test]
        public void Character_CanEquipArmorOfSameClass()
        {
            var character = new Character("Test", 10, 10, 10, CharacterClass.Human);
            var armor = new Armor("Test", 10, 10, CharacterClass.Human);
            character.EquipArmor(armor);
            Assert.AreEqual(armor, character.EquippedArmor);
        }

        [Test]
        public void Character_CanEquipAnyArmor()
        {
            var character = new Character("Test", 10, 10, 10, CharacterClass.Human);
            var armor = new Armor("Test", 10, 10, CharacterClass.Any);
        }
    }
}