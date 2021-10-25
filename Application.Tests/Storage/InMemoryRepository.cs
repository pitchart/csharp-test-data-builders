using System.Collections.Generic;
using Application.Purchase;
using Application.Storage;

namespace Application.Tests.Storage
{
    public class InMemoryRepository : IRepository
    {
        private readonly Dictionary<int, Invoice> _invoiceMap;

        public InMemoryRepository()
        {
           _invoiceMap = new Dictionary<int, Invoice>();
        }

        public void AddInvoice(Invoice invoice)
        {
            _invoiceMap.Add(invoice.Id, invoice);
        }

        public Dictionary<int, Invoice> GetInvoiceMap() => _invoiceMap;
    }
}
