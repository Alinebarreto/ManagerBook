﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBook.Core.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string StoreId { get; set; }
    }
}
