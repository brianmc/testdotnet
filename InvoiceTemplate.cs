using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subscriptions.Models
{
    public class InvoiceTemplate
    {
        [Key]
        public int MerchantId { get; set; }
        public string MerchantName { get; set; }
        public string MerchantLogoURL { get; set; }
        public string MerchantDescription { get; set; }
        public string MerchantAddress { get; set; }
        public string MerchantEmail { get; set; }
        public string MerchantPhone { get; set; }
        public string CustomField1Label { get; set; }
        public string CustomField2Label { get; set; }
        public string CustomField3Label { get; set; }
    }
}
