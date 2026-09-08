using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DTO
{
    public record AddCollectionOfBooksToUserDTO(
        string UserId,
        List<CollectionOfIsbnsDTO> Books
    );
}
