using System;

namespace NFLMath
{
    public class YardageCalculation
    {
        public static int FieldGoalDistance(string end, int lineOfScrimage)
        {
            const string OwnEnd = "OWN";
            const string OppEnd = "OPP";
            const int MidField = 50;
            const int KickAdjustment = 17;

            const int MaxLineOfScrimage = 40;
            int startingDistanceFromGoal;
            if (end == OwnEnd && lineOfScrimage < MaxLineOfScrimage)
            {
                throw new ArgumentException("Filed Goal is too long.");
            }

            if (end == OwnEnd)
            {
                startingDistanceFromGoal = MidField + (MidField - lineOfScrimage);
            }
            else if (end == OppEnd)
            {
                startingDistanceFromGoal = lineOfScrimage;
            }
            else
            {
                startingDistanceFromGoal = lineOfScrimage;
            }

            return startingDistanceFromGoal + KickAdjustment;
        }
    }
}
