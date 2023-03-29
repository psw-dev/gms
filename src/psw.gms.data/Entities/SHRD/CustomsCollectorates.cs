/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Linq;


namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the CustomsCollectorates table in the database 
    /// </summary>
	public class CustomsCollectorates : Entity
    {
        #region Fields

        private int _collectorate_ID;
        private string _collectorate_Code;
        private string _description;
        private string _parent;
        private string _region_ID;
        private string _transport_ID;
        private string _nature;
        private string _transaction_Type;
        private bool? _split_SD_For_Examination;
        private bool? _isActive;
        private string _machine_No_Collectorate;
        private bool? _is_CESS_Active;
        private bool? _is_First_Examination_Mandatory;
        private bool? _is_EDI_Active;
        private bool? _rMS_Active;
        private bool? _is_Advance_Payment_Allow;
        private bool? _is_Token_Consumable;
        private bool? _is_User_Availability_Setting_Allowed;
        private string _collectorate_City_ID;
        private bool? _is_Principal_Appraisement_Mandatory;
        private bool? _is_DrugCell_Marking_Parallel;
        private bool? _is_PDA_Active;
        private bool? _is_PA_Examination_Import_Mandatory;
        private bool? _is_Random_Marking_Active_On_Assessment;
        private string _import_EO_Flow_Status_ID;
        private bool? _is_FIFO_Active_On_Import_AO;
        private bool? _is_For_SD;
        private bool? _is_For_IGM;
        private bool? _is_FIFO_Active_On_Import_PA;
        private bool? _is_Direct_Debiting_Active;
        private bool? _isDirectorate;
        private bool? _is_FIFO_Active_On_Import_EO;
        private string _iATA_Prefix;
        private bool? _is_ICG;
        private bool? _is_Consignment_Cleared_Through_Land;
        private string _description_Cess_Challan_Code;
        private bool? _is_EPayment_Active;
        private bool? _is_Baggage_Collecttorate;
        private bool? _is_AEO_Sorting_Active;

        #endregion

        #region Properties

        public int Collectorate_ID { get { return _collectorate_ID; } set { _collectorate_ID = value; PrimaryKey = value; } }
        public string Collectorate_Code { get { return _collectorate_Code; } set { _collectorate_Code = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string Parent { get { return _parent; } set { _parent = value; } }
        public string Region_ID { get { return _region_ID; } set { _region_ID = value; } }
        public string Transport_ID { get { return _transport_ID; } set { _transport_ID = value; } }
        public string Nature { get { return _nature; } set { _nature = value; } }
        public string Transaction_Type { get { return _transaction_Type; } set { _transaction_Type = value; } }
        public bool? Split_SD_For_Examination { get { return _split_SD_For_Examination; } set { _split_SD_For_Examination = value; } }
        public bool? IsActive { get { return _isActive; } set { _isActive = value; } }
        public string Machine_No_Collectorate { get { return _machine_No_Collectorate; } set { _machine_No_Collectorate = value; } }
        public bool? Is_CESS_Active { get { return _is_CESS_Active; } set { _is_CESS_Active = value; } }
        public bool? Is_First_Examination_Mandatory { get { return _is_First_Examination_Mandatory; } set { _is_First_Examination_Mandatory = value; } }
        public bool? Is_EDI_Active { get { return _is_EDI_Active; } set { _is_EDI_Active = value; } }
        public bool? RMS_Active { get { return _rMS_Active; } set { _rMS_Active = value; } }
        public bool? Is_Advance_Payment_Allow { get { return _is_Advance_Payment_Allow; } set { _is_Advance_Payment_Allow = value; } }
        public bool? Is_Token_Consumable { get { return _is_Token_Consumable; } set { _is_Token_Consumable = value; } }
        public bool? Is_User_Availability_Setting_Allowed { get { return _is_User_Availability_Setting_Allowed; } set { _is_User_Availability_Setting_Allowed = value; } }
        public string Collectorate_City_ID { get { return _collectorate_City_ID; } set { _collectorate_City_ID = value; } }
        public bool? Is_Principal_Appraisement_Mandatory { get { return _is_Principal_Appraisement_Mandatory; } set { _is_Principal_Appraisement_Mandatory = value; } }
        public bool? Is_DrugCell_Marking_Parallel { get { return _is_DrugCell_Marking_Parallel; } set { _is_DrugCell_Marking_Parallel = value; } }
        public bool? Is_PDA_Active { get { return _is_PDA_Active; } set { _is_PDA_Active = value; } }
        public bool? Is_PA_Examination_Import_Mandatory { get { return _is_PA_Examination_Import_Mandatory; } set { _is_PA_Examination_Import_Mandatory = value; } }
        public bool? Is_Random_Marking_Active_On_Assessment { get { return _is_Random_Marking_Active_On_Assessment; } set { _is_Random_Marking_Active_On_Assessment = value; } }
        public string Import_EO_Flow_Status_ID { get { return _import_EO_Flow_Status_ID; } set { _import_EO_Flow_Status_ID = value; } }
        public bool? Is_FIFO_Active_On_Import_AO { get { return _is_FIFO_Active_On_Import_AO; } set { _is_FIFO_Active_On_Import_AO = value; } }
        public bool? Is_For_SD { get { return _is_For_SD; } set { _is_For_SD = value; } }
        public bool? Is_For_IGM { get { return _is_For_IGM; } set { _is_For_IGM = value; } }
        public bool? Is_FIFO_Active_On_Import_PA { get { return _is_FIFO_Active_On_Import_PA; } set { _is_FIFO_Active_On_Import_PA = value; } }
        public bool? Is_Direct_Debiting_Active { get { return _is_Direct_Debiting_Active; } set { _is_Direct_Debiting_Active = value; } }
        public bool? isDirectorate { get { return _isDirectorate; } set { _isDirectorate = value; } }
        public bool? Is_FIFO_Active_On_Import_EO { get { return _is_FIFO_Active_On_Import_EO; } set { _is_FIFO_Active_On_Import_EO = value; } }
        public string IATA_Prefix { get { return _iATA_Prefix; } set { _iATA_Prefix = value; } }
        public bool? Is_ICG { get { return _is_ICG; } set { _is_ICG = value; } }
        public bool? Is_Consignment_Cleared_Through_Land { get { return _is_Consignment_Cleared_Through_Land; } set { _is_Consignment_Cleared_Through_Land = value; } }
        public string Description_Cess_Challan_Code { get { return _description_Cess_Challan_Code; } set { _description_Cess_Challan_Code = value; } }
        public bool? Is_EPayment_Active { get { return _is_EPayment_Active; } set { _is_EPayment_Active = value; } }
        public bool? Is_Baggage_Collecttorate { get { return _is_Baggage_Collecttorate; } set { _is_Baggage_Collecttorate = value; } }
        public bool? Is_AEO_Sorting_Active { get { return _is_AEO_Sorting_Active; } set { _is_AEO_Sorting_Active = value; } }

        #endregion

        #region Methods

        #endregion

        #region public Methods

        public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object>
            {
                {"Collectorate_ID", Collectorate_ID},
                {"Collectorate_Code", Collectorate_Code},
                {"Description", Description},
                {"Parent", Parent},
                {"Region_ID", Region_ID},
                {"Transport_ID", Transport_ID},
                {"Nature", Nature},
                {"Transaction_Type", Transaction_Type},
                {"Split_SD_For_Examination", Split_SD_For_Examination},
                {"IsActive", IsActive},
                {"Machine_No_Collectorate", Machine_No_Collectorate},
                {"Is_CESS_Active", Is_CESS_Active},
                {"Is_First_Examination_Mandatory", Is_First_Examination_Mandatory},
                {"Is_EDI_Active", Is_EDI_Active},
                {"RMS_Active", RMS_Active},
                {"Is_Advance_Payment_Allow", Is_Advance_Payment_Allow},
                {"Is_Token_Consumable", Is_Token_Consumable},
                {"Is_User_Availability_Setting_Allowed", Is_User_Availability_Setting_Allowed},
                {"Collectorate_City_ID", Collectorate_City_ID},
                {"Is_Principal_Appraisement_Mandatory", Is_Principal_Appraisement_Mandatory},
                {"Is_DrugCell_Marking_Parallel", Is_DrugCell_Marking_Parallel},
                {"Is_PDA_Active", Is_PDA_Active},
                {"Is_PA_Examination_Import_Mandatory", Is_PA_Examination_Import_Mandatory},
                {"Is_Random_Marking_Active_On_Assessment", Is_Random_Marking_Active_On_Assessment},
                {"Import_EO_Flow_Status_ID", Import_EO_Flow_Status_ID},
                {"Is_FIFO_Active_On_Import_AO", Is_FIFO_Active_On_Import_AO},
                {"Is_For_SD", Is_For_SD},
                {"Is_For_IGM", Is_For_IGM},
                {"Is_FIFO_Active_On_Import_PA", Is_FIFO_Active_On_Import_PA},
                {"Is_Direct_Debiting_Active", Is_Direct_Debiting_Active},
                {"isDirectorate", isDirectorate},
                {"Is_FIFO_Active_On_Import_EO", Is_FIFO_Active_On_Import_EO},
                {"IATA_Prefix", IATA_Prefix},
                {"Is_ICG", Is_ICG},
                {"Is_Consignment_Cleared_Through_Land", Is_Consignment_Cleared_Through_Land},
                {"Description_Cess_Challan_Code", Description_Cess_Challan_Code},
                {"Is_EPayment_Active", Is_EPayment_Active},
                {"Is_Baggage_Collecttorate", Is_Baggage_Collecttorate},
                {"Is_AEO_Sorting_Active", Is_AEO_Sorting_Active}
            };
        }

        #endregion

        #region Constructors

        public CustomsCollectorates()
        {
            TableName = "[SHRD].[dbo].[Ref_Customs_Collectorates]";
            PrimaryKeyName = "Collectorate_ID";
        }

        #endregion
    }
}

