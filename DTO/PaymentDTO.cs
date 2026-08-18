using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutoTestsForApplications.DTO;

public record PaymentDTO
(
    [property: JsonPropertyName("method")]
    string Method,

    [property: JsonPropertyName("status")]
    string Status,

    [property: JsonPropertyName("transactionId")]
    string TransactionId
);
