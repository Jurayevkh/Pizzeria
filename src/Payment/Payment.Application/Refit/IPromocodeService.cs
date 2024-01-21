namespace Payment.Application.Refit;

public interface IPromocodeService
{
    //https://localhost:7260/api/Promocode/GetPromocodeByPromocode?Promocode=Toshkent
    [Get("/GetPromocodeByPromocode/{Promocode}")]
    public Task<PromocodeResult> GetPromocodeByPromocode(string Promocode);
}

public class PromocodeResult
{
    public int Id { get; set; }
    public string Promokod { get; set; }
    public float SumOfDiscount { get; set; }
    public DateTime ExpiryDate { get; set; }

}
