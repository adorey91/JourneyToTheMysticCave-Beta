﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Gamelog
    {
        public Player player;
        public EnemyManager enemyManager;
        public ItemManager itemManager;

        //public Ranger[] ranger;
        //public Mage[] mage;
        //public Melee[] melee;
        //public Boss[] boss;
        //public Money[] money;
        //public Potion[] potion;
        //public Trap[] trap;
        //public Sword[] sword;
        public string enemyAttack;

        public _GameStats gameStats;
        public Map map;

        int columnCount = 0;
        int rowCount = 0;
        //Ranger[] ranger, Melee[] melee, Mage[] mage, Boss[] boss, Money[] money, Potion[] potion, Trap[] trap, Sword[] sword

        public void Init(Player player, EnemyManager enemyManager, ItemManager itemManager , _GameStats gamestats, Map map)
        {
            this.player = player;
            this.enemyManager = enemyManager;
            this.itemManager = itemManager;
            //this.ranger = ranger;
            //this.melee = melee;
            //this.mage = mage;
            //this.boss = boss;
            //this.money = money;
            //this.potion = potion;
            //this.trap = trap;
            //this.sword = sword;
            this.gameStats = gamestats;
            this.map = map;
        }

        public void Update()
        {
            rowCount = map.GetMapRowCount()+2;
            columnCount = 0;
        }

        public void Draw()
        {
            rowCount = map.GetMapRowCount() + 9;
            columnCount = 0;
            Console.SetCursorPosition(columnCount, rowCount);
            Console.Write("Game Log:\n");
            LogAttack();
            LogFloorDamage();
            LogTrap();
            LogPickUp();
            EnemyDeath();

        }

        #region PickUps
        private void LogPickUp()
        {
            //foreach (Money money in money)
            //{
            //    if (money.pickedUp)
            //        Console.Write($"{player.name} picked up money \n");
            //    money.pickedUp = false;
            //}

            //foreach (Potion potion in potion)
            //{
            //    if(potion.pickedUp)
            //    {
            //        if(player.healthSystem.healed)
            //        {
            //            Console.Write($"{player.name} picked up potion, healed {potion.healAmount} \n");
            //            player.healthSystem.healed = false;
            //        }
            //        if(player.healthSystem.cannotHeal)
            //        {
            //            Console.Write($"{player.name} cannot heal anymore \n");
            //            player.healthSystem.cannotHeal = false;
            //        }
            //    }
            //}

            //foreach (Sword sword in sword)
            //{
            //    if(sword.pickedUp)
            //    {
            //        Console.Write($"{player.name} picked up sword, attack damage is now {player.damage}\n");
            //        sword.pickedUp = false;
            //    }
            //}
        }

        #endregion

        #region Attack 
        private void LogAttack()
        {
            if(player.healthSystem.hurt)
            {
                Console.Write($"{player.name} was attacked by {enemyAttack} \n"); // might need to fix this?
                player.healthSystem.hurt = false;
                enemyAttack = null;
            }
            //CheckLogEnemyHurtStatus(ranger);
            //CheckLogEnemyHurtStatus(mage);
            //CheckLogEnemyHurtStatus(melee);
            //CheckLogEnemyHurtStatus(boss);

        }

        private void CheckLogEnemyHurtStatus(Enemy[] enemies)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].healthSystem.hurt)
                {
                    Console.Write($"Attacked {enemies[i].name}{i} - {player.damage} damage\n");
                    enemies[i].healthSystem.hurt = false;
                }
            }
        }
        #endregion

        #region FloorDamage
        private void LogFloorDamage()
        {
            if(player.healthSystem.floorDamage)
            {
                Console.Write($"{player.name} hurt by poison spill\n");
                player.healthSystem.floorDamage = false;
            }
            //CheckEnemyFloorDamage(ranger);
            //CheckEnemyFloorDamage(mage);
            //CheckEnemyFloorDamage(melee);
            //CheckEnemyFloorDamage(boss);
        }

        private void CheckEnemyFloorDamage(Enemy[] enemies)
        {
            for (int i = 0;i < enemies.Length;i++)
            {
                if (enemies[i].healthSystem.hurt)
                {
                    Console.Write($"{enemies[i].name}{i} hurt by poison spill \n");
                    enemies[i].healthSystem.floorDamage = false;
                }
            }
        }
        #endregion

        #region Trap
        private void LogTrap()
        {
            if(player.healthSystem.hurtByTrap)
            {
                Console.Write($"{player.name} hurt by a trap \n");
                player.healthSystem.hurtByTrap = false;
            }
            //CheckEnemyTrap(ranger);
            //CheckEnemyTrap(mage);
            //CheckEnemyTrap(melee);
            //CheckEnemyTrap(boss);
        }

        private void CheckEnemyTrap(Enemy[] enemies)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].healthSystem.hurt)
                {
                    Console.Write($"{enemies[i].name}{i} hurt by a trap \n");
                    enemies[i].healthSystem.hurtByTrap = false;
                }
            }
        }
        #endregion

        #region Death
        private void EnemyDeath()
        {
            //LogEnemyDeath(ranger);
            //LogEnemyDeath(mage);
            //LogEnemyDeath(melee);
            //LogEnemyDeath(boss);
        }

        private void LogEnemyDeath(Enemy[] enemies)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].healthSystem.dead)
                {
                    Console.Write($"{enemies[i].name}{i} has died \n");
                    enemies[i].healthSystem.dead = false;
                }
            }
        }
        #endregion
    }
}
