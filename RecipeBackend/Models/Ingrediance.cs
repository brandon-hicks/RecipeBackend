namespace RecipeBackend.Models
{
    public class Ingrediance
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Amount { get; set; }

        public Ingrediance ()
        {
            Name = "";
            Unit = "";
            Amount = "";
        }
    }
}