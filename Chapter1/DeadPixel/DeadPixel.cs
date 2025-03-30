using BrutalAPI;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned.Chapter1.DeadPixel
{
    public class DeadPixel
    {
        public static void Add()
        {
            //AssetBundle saltsAssetBundle = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("reseasonedHawthorne"));
            Enemy DeadPixel = new Enemy("DeadPixel", "DeadPixel_EN")
            {
                 Name = "Dead Pixel",
                 Health = 9,
                 HealthColor = Pigments.Grey,
                 Priority = BrutalAPI.Priority.ExtremelySlow,
                CombatSprite = ResourceLoader.LoadSprite("deadPixel_iconB", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("deadPixel_dead", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("deadPixel_icon", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Arnold_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Arnold_CH").deathSound,
            };
            DeadPixel.PrepareEnemyPrefab("assets/PissShitFartCum/Pixel_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/Pixel_Gibs.prefab").GetComponent<ParticleSystem>());



            DeadPixel.AddEnemy(true, true, true);
        }
    }
}
