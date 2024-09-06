// Quest class definition (Class Definition)
[System.Serializable]
public class Quest
{
    public bool isActive; // Example of Encapsulation
    public string title; // Example of Encapsulation
    public string description; // Example of Encapsulation
    public int scrapReward; // Example of Encapsulation
    public QuestGoal goal; // Aggregation: Quest has-a QuestGoal, but QuestGoal can exist independently

    // Method to mark a quest as complete, demonstrating behavior encapsulation (Encapsulation)
    public void Complete()
    {
        isActive = false;
    }
}
