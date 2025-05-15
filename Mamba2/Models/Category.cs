namespace Mamba2.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Portfolio>? PortfolioList {  get; set; } 
}
