using System.Collections.Generic;

namespace Services.DTO
{
    public class PaginationDTO<T>
    {
        public IEnumerable<T> Model { get; }
        public int TotalRecords { get; }
        public int TotalPages { get; }

        public PaginationDTO(IEnumerable<T> model, int totalRecords, int totalPages)
        {
            Model = model;
            TotalRecords = totalRecords;
            TotalPages = totalPages;
        }
    }
}