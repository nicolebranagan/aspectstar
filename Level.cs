using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspectStar
{
    public static class Level
    {
        public static int levelMax = 9;

        public static LevelDef getTestLevel(GameScreen game)
        {
            LevelDef testLevel = new LevelDef();

            int[] tileMap = new int[Map.rows * Map.columns] {
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 2, 0, 1, 1, 1, 1, 1, 0, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1,
                1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            // Create the map
            int[] key = { 0, 1, 2, 3, 4 };
            testLevel.levelMap = new Map(Game1.texCollection.testMap, key, tileMap);

            testLevel.enemyList = new List<Enemy>();
            testLevel.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2(100, 100), testLevel.levelMap, game));
            testLevel.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2(300, 250), testLevel.levelMap, game));
            testLevel.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2(160, 160), testLevel.levelMap, game));

            return testLevel;
        }

        public static LevelDef getLevel(int levelnum, GameScreen game)
        {
            LevelDef level = new LevelDef();
            int[] tileMap;
            int[] test_key = { 0, 1, 2, 3, 4 };
            int[] factory_key = { 0, 1, 1, 0, 2, 3, 4, 1};
            switch (levelnum)
            {
                case 1:
                    tileMap = new int[Map.rows * Map.columns] {
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 1, 1, 1, 1, 0, 0, 0, 3, 0, 0, 1, 0, 1, 0, 0, 4, 0, 0, 0, 1, 1, 1, 1, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

                    level.levelMap = new Map(Game1.texCollection.testMap, test_key, tileMap);

                    level.enemyList = new List<Enemy>();
                    level.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2(3 * 32, 12 * 32), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2(22 * 32, 12 * 32), level.levelMap, game, Game1.Aspects.Green));
                    level.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2(13 * 32, 11 * 32), level.levelMap, game, Game1.Aspects.Blue));
                    break;

                case 2:
                    tileMap = new int[Map.rows * Map.columns] {
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1,
                        1, 0, 0, 0, 0, 4, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

                    level.levelMap = new Map(Game1.texCollection.testMap, test_key, tileMap);

                    level.enemyList = new List<Enemy>();
                    level.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2(5 * 32, 4 * 32), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2((Map.columns - 5) * 32, 4 * 32), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2(9 * 32, 8 * 32), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2((Map.columns - 9) * 32, 8 * 32), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.smartmouse, new Vector2((Map.columns / 2) * 32, (Map.rows - 3) * 32), level.levelMap, game, Game1.Aspects.Red));
                    break;
                case 3:
                    tileMap = new int[Map.rows * Map.columns] {
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1,
                        1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
                        1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
                        1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
                        1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 4, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 4, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

                    level.levelMap = new Map(Game1.texCollection.testMap, test_key, tileMap);

                    level.enemyList = new List<Enemy>();
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2(5 * 32, 10 * 32), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2(6 * 32, 12 * 32), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2(19 * 32, 13 * 32), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2(2 * 32, 2 * 32), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2((Map.columns/2) * 32, 4 * 32), level.levelMap, game));
                    break;
                case 4:
                    tileMap = new int[Map.rows * Map.columns] {
                        7, 7, 7, 7, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 7, 7, 7, 7,
                        7, 7, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 7, 7,
                        7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7,
                        7, 1, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 1, 7,
                        1, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 4, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 4, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 4, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1,
                        1, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 1,
                        7, 1, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 1, 7,
                        7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7,
                        7, 7, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 7, 7,
                        7, 7, 7, 7, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 7, 7, 7, 7 };

                    level.levelMap = new Map(Game1.texCollection.factoryMap, factory_key, tileMap);

                    level.enemyList = new List<Enemy>();
                    level.enemyList.Add(new Enemy(EnemyDict.smartmouse, new Vector2((Map.columns / 2) * 32 + 16, (Map.rows - 2) * 32 - 16), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.smartmouse, new Vector2((Map.columns / 2) * 32 + 16, (2) * 32 - 16), level.levelMap, game, Game1.Aspects.Green));
                    level.enemyList.Add(new Enemy(EnemyDict.smartmouse, new Vector2((2) * 32 - 16, (Map.rows / 2) * 32 + 16), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.smartmouse, new Vector2((Map.columns - 2) * 32 - 16, (Map.rows / 2) * 32 + 16), level.levelMap, game, Game1.Aspects.Green));
                    break;
                case 5:
                    tileMap = new int[Map.rows * Map.columns] {
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 0, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 0, 0, 0, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 0, 0, 0, 0, 0, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 1, 0, 0, 0, 0, 0, 0, 0, 1, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 1, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 1, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 1, 0, 0, 0, 0, 0, 4, 0, 6, 0, 0, 0, 0, 0, 1, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 1, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 1, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 1, 0, 0, 0, 0, 0, 0, 0, 1, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 0, 0, 0, 0, 0, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 0, 0, 0, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 0, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 };

                    level.levelMap = new Map(Game1.texCollection.factoryMap, factory_key, tileMap);

                    level.enemyList = new List<Enemy>();
                    level.enemyList.Add(new Enemy(EnemyDict.smartmouse, new Vector2((Map.columns / 2)*32 + 16, (Map.rows - 1)*32 - 16), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.smartmouse, new Vector2((18) * 32 + 16, (8) * 32 - 16), level.levelMap, game, Game1.Aspects.Blue));
                    level.enemyList.Add(new Enemy(EnemyDict.smartmouse, new Vector2((6) * 32 + 16, (8) * 32 - 16), level.levelMap, game, Game1.Aspects.Green));
                    break;
                case 6:
                    tileMap = new int[Map.rows * Map.columns] {
                        7, 7, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 7, 7,
                        7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 1,
                        1, 0, 0, 0, 4, 0, 6, 0, 5, 0, 3, 0, 3, 0, 3, 0, 5, 0, 6, 0, 4, 0, 0, 0, 1,
                        1, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 1,
                        1, 0, 0, 0, 6, 0, 5, 0, 4, 0, 3, 0, 3, 0, 3, 0, 6, 0, 4, 0, 5, 0, 0, 0, 1,
                        1, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 1,
                        1, 0, 0, 0, 5, 0, 4, 0, 6, 0, 3, 0, 3, 0, 3, 0, 4, 0, 5, 0, 6, 0, 0, 0, 1,
                        1, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 1,
                        1, 0, 0, 0, 4, 0, 6, 0, 5, 0, 3, 0, 3, 0, 3, 0, 5, 0, 6, 0, 4, 0, 0, 0, 1,
                        1, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7,
                        7, 7, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 7, 7 };

                    level.levelMap = new Map(Game1.texCollection.factoryMap, factory_key, tileMap);

                    level.enemyList = new List<Enemy>();
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2(5 * 32 - 8, 4 * 32 + 8), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2(5 * 32 - 8, 6 * 32 + 8), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2(5 * 32 - 8, 8 * 32 + 8), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2(5 * 32 - 8, 10 * 32 + 8), level.levelMap, game));

                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2((Map. columns - 5) * 32 - 8, 4 * 32 + 8), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2((Map.columns - 5) * 32 - 8, 6 * 32 + 8), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2((Map.columns - 5) * 32 - 8, 8 * 32 + 8), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2((Map.columns - 5) * 32 - 8, 10 * 32 + 8), level.levelMap, game));
                    break;
                case 7:
                    tileMap = new int[Map.rows * Map.columns] {
                        1, 2, 2, 2, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 2, 2, 2, 1,
                        1, 0, 0, 0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 0, 0, 0, 1,
                        1, 0, 5, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 6, 0, 1,
                        1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1,
                        1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1,
                        2, 1, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0, 2, 1, 0, 1, 2,
                        7, 1, 0, 2, 0, 0, 1, 0, 0, 0, 0, 1, 3, 1, 0, 0, 0, 0, 1, 0, 0, 2, 0, 1, 7,
                        1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1,
                        1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 2, 2, 2, 1, 0, 0, 0, 1, 2, 2, 2, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 4, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        2, 1, 0, 0, 0, 0, 0, 0, 1, 2, 1, 0, 0, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0, 1, 2,
                        7, 2, 2, 2, 2, 2, 2, 2, 2, 7, 2, 2, 2, 2, 2, 7, 2, 2, 2, 2, 2, 2, 2, 2, 7 };

                    level.levelMap = new Map(Game1.texCollection.spaceMap, factory_key, tileMap);

                    level.enemyList = new List<Enemy>();
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2(3 * 32, 10 * 32), level.levelMap, game, Game1.Aspects.Blue));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2((Map.columns - 4) * 32, 10 * 32), level.levelMap, game, Game1.Aspects.Blue));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2((Map.columns - 10) * 32, 10 * 32), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.smartmouse, new Vector2(7 * 32, 3 * 32), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.smartmouse, new Vector2(19 * 32, 3 * 32), level.levelMap, game, Game1.Aspects.Green));
                    break;
                case 8:
                    tileMap = new int[Map.rows * Map.columns] {
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 1, 2, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 2, 1, 7, 7, 7, 7,
                        7, 7, 7, 7, 1, 6, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 6, 1, 7, 7, 7, 7,
                        7, 7, 7, 7, 2, 2, 2, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 2, 2, 2, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 2, 2, 2, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 0, 0, 0, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 0, 3, 0, 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 1, 2, 2, 2, 2, 1, 2, 2, 2, 1, 0, 0, 0, 1, 2, 2, 2, 1, 2, 2, 2, 2, 1, 7,
                        7, 1, 0, 0, 0, 0, 2, 0, 0, 0, 2, 5, 2, 6, 2, 0, 0, 0, 2, 0, 0, 0, 0, 1, 7,
                        7, 2, 1, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 1, 2, 7,
                        7, 7, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 7, 7,
                        7, 7, 7, 2, 2, 2, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 2, 2, 1, 0, 0, 0, 0, 0, 1, 2, 2, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 2, 2, 2, 2, 2, 2, 2, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 };

                    level.levelMap = new Map(Game1.texCollection.spaceMap, factory_key, tileMap);

                    level.enemyList = new List<Enemy>();
                    level.enemyList.Add(new Enemy(EnemyDict.dog, new Vector2(4 * 32, 9 * 32), level.levelMap, game));
                    level.enemyList.Add(new Enemy(EnemyDict.dog, new Vector2((Map.columns -5) * 32, 9 * 32), level.levelMap, game));
                    break;
                case 9:
                    tileMap = new int[Map.rows * Map.columns] {
                        7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 2, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                        7, 1, 2, 2, 2, 2, 2, 2, 2, 7, 7, 1, 0, 1, 7, 7, 2, 2, 2, 2, 2, 2, 2, 1, 7,
                        7, 1, 0, 0, 0, 0, 0, 0, 0, 2, 7, 2, 0, 2, 7, 2, 0, 0, 0, 0, 0, 0, 0, 1, 7,
                        7, 1, 0, 6, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 5, 0, 1, 7,
                        7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7,
                        7, 1, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 1, 7,
                        7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7,
                        7, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 7,
                        7, 7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7, 7,
                        7, 7, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 7, 7,
                        7, 1, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 1, 7,
                        7, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 7,
                        1, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 7, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 7, 7, 7, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

                    level.levelMap = new Map(Game1.texCollection.spaceMap, factory_key, tileMap);

                    level.enemyList = new List<Enemy>();
                    level.enemyList.Add(new Enemy(EnemyDict.dog, new Vector2((Map.columns /2) * 32 + 16, 2 * 32), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2((Map.columns - 4) * 32 + 16, (Map.rows -2) * 32), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2((4) * 32 + 16, (Map.rows - 2) * 32), level.levelMap, game, Game1.Aspects.Green));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2((5) * 32, 3 * 32), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.bird, new Vector2((Map.columns - 5) * 32, 3 * 32), level.levelMap, game, Game1.Aspects.Green));
                    break;
                default:
                    tileMap = new int[Map.rows * Map.columns] {
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

                    level.levelMap = new Map(Game1.texCollection.testMap, test_key, tileMap);

                    level.enemyList = new List<Enemy>();
                    level.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2(3 * 32, 12 * 32), level.levelMap, game, Game1.Aspects.Red));
                    level.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2(22 * 32, 12 * 32), level.levelMap, game, Game1.Aspects.Green));
                    level.enemyList.Add(new Enemy(EnemyDict.mouse, new Vector2(13 * 32, 11 * 32), level.levelMap, game, Game1.Aspects.Blue));
                    break;
            }
            return level;
        }
    }

    public struct LevelDef
    {
        public Map levelMap;               // Map for the level
        public List<Enemy> enemyList;     // List of all enemies in level
    }
}
