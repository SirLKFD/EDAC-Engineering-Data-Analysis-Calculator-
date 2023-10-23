class Sequencing
{
    private Dictionary<string, int> statisticCounts = new Dictionary<string, int>();

    public int GetNextCount(string statisticType)
    {
        if (!statisticCounts.ContainsKey(statisticType))
        {
            statisticCounts[statisticType] = 1;
        }
        else
        {
            statisticCounts[statisticType]++;
        }

        return statisticCounts[statisticType];
    }

    public void AdjustCount(string statisticType, int deletedCount)
    {
        if (statisticCounts.ContainsKey(statisticType) && statisticCounts[statisticType] > deletedCount)
        {
            statisticCounts[statisticType]--;
        }
    }
}
