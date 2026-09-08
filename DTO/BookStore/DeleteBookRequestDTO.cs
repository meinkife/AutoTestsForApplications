using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DTO
{
    public record DeleteBookRequestDTO(
        string Isbn,
        string UserId
        );
}
