using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public enum UserTaskId
    {
        AddConsignment = 1,
        EditConsignment = 2,
        DeleteConsignment = 3,
        ViewConsignment = 4,
        UpdateConsignmentStatus = 5,
        EmbassyFeeMaster = 6,
        EditEmbassyFees = 7,
        DeleteEmbassyFees = 8,
        EmbassyMaster = 9,
        EditEmbassyMaster = 10,
        DeleteEmbassyMaster = 11,
        SearchEmbassyFee = 12,
        MiscellaneousCharges = 13,
        EditMiscellaneousCharge = 14,
        DeleteMiscellaneousCharge = 15,
        AddVisaForm = 16,
        ViewVisaForm = 17,
       // DeleteVisaForm = 18,
        AddVisaInfo = 18,
        ViewVisaInfo = 19,
        EditVisaInfo = 20,
        DeleteVisaInfo = 21,
        AddHoliday = 22,
        ViewHoliday = 23,
        EditHoliday = 24,
        DeleteHoliday = 25,
        AddAgent = 26,
        EditAgent = 27,
        DeleteAgent = 28,
        ManageAgent = 29,
        AgentList = 30,
        AgentEmailList = 31,
        DeleteVisaForm=34,
        AdvanceSearch = 35,
        ReceiptGeneration=36,
        EditReceipt=37,
        DeleteReceipt=38,
        ExportDataToTally=39,
        AddNewsLetter=40,
        EdtiNewsLetter = 41,
        DeleteNewsLetter = 42,
        InvoiceReceiptPrinting = 43,
        InvoicePrinting = 44,
        InvoiceReprinting=45,
        EditInvoice=46,
        BillRegister=47,
        StatementOfAccount=48,
        BankStatement=49,
        AgingAnalysis=50,
        SummaryReport=51,
        MiscellaneousReport=52,
        Admin=53,
        ViewNewsLetter = 54,
        ExportAgent=55,
        AddCity=56
    }
    public enum UserType
    {
        Admin=1,
        CompanyUser=2,
        AgentUser=3,
        SuperAdmin=4
    }
}
