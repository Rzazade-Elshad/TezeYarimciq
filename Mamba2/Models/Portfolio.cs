namespace Mamba2.Models;

public class Portfolio
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Dectription {  get; set; }
    public int? CategoryId {  get; set; }
    public Category Category { get; set; }
    public string? ImgUrl {  get; set; }
}
