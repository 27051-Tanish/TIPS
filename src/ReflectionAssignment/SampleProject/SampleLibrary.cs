namespace SampleProject
{
    public class SampleLibrary
    {
         // 1. Fields
         private string _secretId = "ID-9999";
         public string? RegionCode;

         // 2. Properties
         public int Id { get; set; }
         public string Name { get; private set; } = string.Empty; // Mixed access property
         public bool IsActive => true;             // Getter-only property

         // 3. Event
         public event EventHandler? StatusChanged;

         // 4. Methods
         public void UpdateName(string newName)
         {
             Name = newName;
         }

         private string GetSecretId()
         {
             return _secretId;
         }
    }
}
