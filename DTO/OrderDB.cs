namespace AutoTestsForApplications.DTO;

public class OrderDB
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string OrderDate { get; set; }
    public string Status { get; set; }
    public double TotalPrice { get; set; }
}