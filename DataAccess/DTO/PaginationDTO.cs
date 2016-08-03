using System.Collections.Generic;

namespace DataAccess.DTO
{
    public class PaginationDTO<T>
    {
        public IEnumerable<T> Model { get; private set; }
        public int TotalRecords { get; private set; }
        public int TotalPages { get; private set; }

        public PaginationDTO(List<T> model, int totalRecords, int totalPages)
        {
            Model = model;
            TotalRecords = totalRecords;
            TotalPages = totalPages;
        }
    }
}