using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppie.Business.ViewModels
{
    public class PaginationModel
    { 
        public int TotalRecords { get; private set; }
        public string Action { get; set; } = "Index";
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int StartRecord { get; private set; }
        public int EndRecord { get; private set; }
        public int PaginationSpan { get; private set; }

        public PaginationModel(int totalRecords, int currentPage, int pageSize = 7, int paginationSpan = 2)
        {
            TotalRecords = totalRecords;
            CurrentPage = currentPage;
            PageSize = pageSize;
            PaginationSpan = paginationSpan;

            TotalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize);

            int paginationStart = currentPage - paginationSpan;
            int paginationEnd = currentPage + paginationSpan;

            if (paginationStart <= 0)
            {
                paginationEnd -= (paginationStart - 1);
                paginationStart = 1;
            }

            if (paginationEnd >= TotalPages)
            {
                paginationEnd = TotalPages;

                if(paginationEnd > 5)
                {
                    paginationStart = paginationEnd - 5;
                }
            }

            StartRecord = (CurrentPage - 1) * PageSize + 1;
            EndRecord = StartRecord - 1 + PageSize;

            if(EndRecord > TotalRecords)
            {
                EndRecord = TotalRecords;
            }

            if (TotalRecords == 0)
            {
                StartPage = 0;
                StartRecord = 0;
                CurrentPage = 0;
                EndRecord = 0;
            }

            else
            {
                StartPage = paginationStart;
                EndPage = paginationEnd;
            }

        }
    }
}
