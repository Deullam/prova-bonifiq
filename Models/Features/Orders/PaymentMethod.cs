using Bogus.Bson;
using System.Runtime.Serialization;

namespace ProvaPub.Models.Features.Orders
{
    /// <summary> Enumeração que representa os diferentes métodos de pagamento disponíveis. </summary>
    public enum PaymentMethod
    {
        [EnumMember(Value = "Pix")]
        Pix = 0,

        [EnumMember(Value = "CreditCard")]
        CreditCard = 1,

        [EnumMember(Value = "PayPal")]
        PayPal = 2
    }
}
