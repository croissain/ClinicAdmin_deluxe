using ClinicAdmin.DTO;
using System;

namespace ClinicAdmin.DAO
{
    public class InvoiceDAO
    {
        private static InvoiceDAO _instance;
        private double totalCost;
        private double examCost;
        private double drugCost;
        private DateTime created_at;
        private PrescriptionDAO prescription;

        public double TotalCost
        {
            get => totalCost; set => totalCost = value;
        }
        public double ExamCost
        {
            get => examCost; set => examCost = value;
        }
        public double DrugCost
        {
            get => drugCost; set => drugCost = value;
        }
        public DateTime Created_at
        {
            get => created_at; set => created_at = value;
        }
        public PrescriptionDAO Prescription
        {
            get => prescription; set => prescription = value;
        }

        public static InvoiceDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new InvoiceDAO();
            }
            return _instance;
        }

        public Invoice AddInvoice(InvoiceDAO invoiceDAO)
        {
            Invoice result = null;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var invoice = new Invoice()
                {
                    TotalCost = invoiceDAO.TotalCost,
                    PrescriptionId = invoiceDAO.Prescription.Id,
                    Created_at = invoiceDAO.Created_at,
                    ExaminationFee = invoiceDAO.ExamCost,
                    DrugFee = invoiceDAO.DrugCost
                };
                result = context.Invoices.Add(invoice);
                context.SaveChanges();
            }
            return result;
        }
    }
}
