using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subscriptions.Models
{
    public class Invoice
    {
            [Key]
            public int Id { get; set; }
            public string MerchantId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerPhone { get; set; }
            public string Memo { get; set; }
            public Double InvoiceAmount { get; set; }
            public string CustomField1 { get; set; }
            public string CustomField2 { get; set; }
            public string CustomField3 { get; set; }
            public int Status { get; set; }
        
    }
}
