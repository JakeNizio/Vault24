// QuestGoal class definition (Class Definition)
[System.Serializable]
public class QuestGoal
{
    // Enum for types of goals, an example of using enumerations to define custom types (OOP practice)
    public KindOfGoal type;
    public int requiredAmount;
    public int currentAmount;

    // Method demonstrating behavior of QuestGoal (Encapsulation)
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    // Methods modifying state based on conditions (Encapsulation & Behavior)
    public void EnemyKilled()
    {
        if (type == KindOfGoal.Kill)
            currentAmount++;
    }

    public void ItemCollected()
    {
        if (type == KindOfGoal.Gathering)
            currentAmount++;
    }
}

// Enumeration for the kind of goal, showcasing the use of enums in OOP to define a set of named constants
public enum KindOfGoal
{
    Kill, Gathering
}