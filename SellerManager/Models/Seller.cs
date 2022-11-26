using System.ComponentModel.DataAnnotations;

namespace SellerManager.Models
{
    public record Seller(Guid Id,string Name, DateTime CreatedAt, string Email, string Address, decimal DiscountFactor);

}
