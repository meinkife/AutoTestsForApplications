using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreDTO
{
    public record BookListDTO(
        List<BookDTO> Books);

}
