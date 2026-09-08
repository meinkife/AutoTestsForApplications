using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreDTO
{
    public record DeleteBookResponseDTO(
        string UserId,
        string Isbn,
        string Message
        );
}
