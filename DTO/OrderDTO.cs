using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutoTestsForApplications.DTO;

public record OrderDTO
(
    [property: JsonPropertyName("orderId")]
    string OrderId,

    [property: JsonPropertyName("createdAt")]
    string Created_At,

    [property: JsonPropertyName("customer")]
    CustomerDTO Customer,

    [property: JsonPropertyName("items")]
    List<ItemDTO> Items,

     [property: JsonPropertyName("payments")]
    PaymentDTO Payments,

    [property: JsonPropertyName("delivery")]
    DeliveryDTO Delivery,

    [property: JsonPropertyName("summary")]
    SummaryDTO Summary
);



