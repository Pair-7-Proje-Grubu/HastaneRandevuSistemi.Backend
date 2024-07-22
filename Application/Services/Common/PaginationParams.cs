﻿namespace Application.Services.Common
{
    public abstract class PaginationParams : IPaginationParams
    {
        private int _pageNumber = 1;
        private int _pageSize = 10;

        public virtual int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value > 0 ? value : 1;
        }

        public virtual int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > 0 && value <= 100) ? value : 10;
        }
    }
}
