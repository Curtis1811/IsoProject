using System.Collections.Generic;

namespace LevelUp
{
    public class LevelUpHandler
    {
        #region Initialization
        private int _level;
        private float _experiencePoints;
        private int _maxLevel;

        public LevelBrackets StoredLevelBrackets;

        public class LevelBrackets
        {
            public class Level
            {
                public int TargetLevel;
                public float ExperienceForThisLevel;
            }
            
            public List<Level> LevelBracketsList;
            
            public LevelBrackets(float experienceForLevel, float experienceMultiplierPerLevel, int maxLevel)
            {
                ConstructLevelUpData(experienceForLevel, experienceMultiplierPerLevel, maxLevel);
            }
            
            public Level GetCurrentLevelBracket(int level)
            {
                return LevelBracketsList[level];
            }
            
            private void ConstructLevelUpData(float experienceForLevel, float experienceMultiplierPerLevel, int maxLevel)
            {
                LevelBracketsList = new List<Level>();
            
                for (int i = 0; i < maxLevel; i++)
                {
                    if (i == 0)
                    {
                        LevelBracketsList.Add(
                            new Level
                            {
                                TargetLevel = i,
                                ExperienceForThisLevel = 0.0f
                            });

                        LevelBracketsList.Add(
                            new Level
                            {
                                TargetLevel = i + 1,
                                ExperienceForThisLevel = experienceForLevel * experienceMultiplierPerLevel
                            });
                    }
                    else
                    {
                        LevelBracketsList.Add(
                            new Level
                            {
                                TargetLevel = i + 1,
                                ExperienceForThisLevel = experienceForLevel * (experienceMultiplierPerLevel * (i + 1))
                            });
                    }

                }
            }
            
        }
        
        #endregion
            
        #region Constructors
        LevelUpHandler(float experienceForLevel, float experienceMultiplierPerLevel, int maxLevel,
            int startingLevel = 0)
        {
            StoredLevelBrackets = new LevelBrackets(experienceForLevel, experienceMultiplierPerLevel, maxLevel);
            _maxLevel = maxLevel;
            SetLevel(startingLevel);
        }
       #endregion
       
        public int GetLevel()
        {
            return _level;
        }
        
        public float GetCurrentExperience()
        {
            return _experiencePoints;
        }
        
        void LevelUp(float experienceToRemove = 0.0f)
        {
            _experiencePoints =- experienceToRemove;
            _level =+ 1;
        }
        
        public int SetLevel(int targetLevel)
        {
            if (targetLevel < 0)
            {
                _level = 0;
            }
            else if (targetLevel > _maxLevel)
            {
                _level = _maxLevel;
            }
            else
            {
                _level = targetLevel;
            }

            _experiencePoints = 0;
            
            return _level;
        }
        
        void GainExperience(float experiencePoints, bool canLevelUp = true)
        {
            _experiencePoints =+ experiencePoints;
            if (canLevelUp)
            { 
                CheckForLevelUp();
            }
           
        }
        
        public bool CheckForLevelUp()
        {
            var experienceForNextLevel = StoredLevelBrackets.GetCurrentLevelBracket(_level).ExperienceForThisLevel;
            
            if (_level != _maxLevel
                && _experiencePoints >= experienceForNextLevel)
            {
                LevelUp(experienceForNextLevel);
                CheckForLevelUp();
                return true;
            }
            return false;
        }
    }
}