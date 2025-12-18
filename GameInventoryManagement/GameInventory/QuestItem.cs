namespace GameInventory
{
    public class QuestItemBuilder : ItemBuilder<QuestItemBuilder>
    {
        private string questName = "";
        private bool isCompleted = false;

        public QuestItemBuilder SetQuestName(string questName)
        {
            this.questName = questName;
            return this;
        }

        public QuestItemBuilder SetCompleted(bool completed)
        {
            this.isCompleted = completed;
            return this;
        }

        public override Item Build()
        {
            return new QuestItem
            {
                Type = ItemType.QUEST,
                Name = item.Name,
                Cost = item.Cost,
                Count = item.Count,
                Description = item.Description,
                QuestName = this.questName,
                IsCompleted = this.isCompleted
            };
        }
    }

    // Примеры квестовых предметов
    public class KeyItemBuilder : QuestItemBuilder
    {
        public KeyItemBuilder(string name, string questName)
        {
            SetName(name);
            SetCost(0); // Квестовые предметы обычно бесплатные
            SetCount(1);
            SetQuestName(questName);
            SetCompleted(false);
            SetDescription("Важный предмет для выполнения квеста");
        }
    }

    public class ArtifactBuilder : QuestItemBuilder
    {
        public ArtifactBuilder(string name, string questName)
        {
            SetName(name);
            SetCost(0);
            SetCount(1);
            SetQuestName(questName);
            SetCompleted(false);
            SetDescription("Древний артефакт с магическими свойствами");
        }
    }
}