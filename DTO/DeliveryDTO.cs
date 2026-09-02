using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutoTestsForApplications.DTO;

    public record DeliveryDTO
    (
        [property: JsonPropertyName("type")]
        string Type,

        [property: JsonPropertyName("status")]
        string Status,

        [property: JsonPropertyName("estimatedDate")]
        string Estimated_Date,

        [property: JsonPropertyName("trackingNumber")]
        string Tracking_Number
        );

