/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Linq;


namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the Ref_Shed_Locations table in the database 
    /// </summary>
	public class RefShedLocations : Entity
    {
        #region Fields

        private int _shed_Location_ID;
        private string _collectorate_Code;
        private int? _shed_Group_Code;
        private string _berth;
        private int? _sHDSRL;
        private string _shed_Name;
        private int? _collectorate_ID;
        private string _group_Type;
        private DateTime? _entry_Date;
        private bool? _isActive;
        private string _aS_Shed_Code;
        private bool? _is_EDI_Active;
        private string _aS_SHED_CODE_EXPORT;
        private bool? _is_Part_Edi_Active;
        private bool? _is_LCL_Edi_Active;
        private int? _berth_Location_ID;
        private bool? _is_Air_EDI_Active;
        private bool? _is_For_Railway;
        private string _tIR_Shed_Code;
        private bool? _is_Seal_Required;
        private bool? _is_Scan_Required;
        private bool? _is_LCL_OD_Edi_active;
        private DateTime? _lCL_OD_Edi_Active_Date;
        private string _sub_AS_Shed_Code;

        #endregion

        #region Properties

        public int Shed_Location_ID { get { return _shed_Location_ID; } set { _shed_Location_ID = value; PrimaryKey = value; } }
        public string Collectorate_Code { get { return _collectorate_Code; } set { _collectorate_Code = value; } }
        public int? Shed_Group_Code { get { return _shed_Group_Code; } set { _shed_Group_Code = value; } }
        public string Berth { get { return _berth; } set { _berth = value; } }
        public int? SHDSRL { get { return _sHDSRL; } set { _sHDSRL = value; } }
        public string Shed_Name { get { return _shed_Name; } set { _shed_Name = value; } }
        public int? Collectorate_ID { get { return _collectorate_ID; } set { _collectorate_ID = value; } }
        public string Group_Type { get { return _group_Type; } set { _group_Type = value; } }
        public DateTime? Entry_Date { get { return _entry_Date; } set { _entry_Date = value; } }
        public bool? IsActive { get { return _isActive; } set { _isActive = value; } }
        public string AS_Shed_Code { get { return _aS_Shed_Code; } set { _aS_Shed_Code = value; } }
        public bool? Is_EDI_Active { get { return _is_EDI_Active; } set { _is_EDI_Active = value; } }
        public string AS_SHED_CODE_EXPORT { get { return _aS_SHED_CODE_EXPORT; } set { _aS_SHED_CODE_EXPORT = value; } }
        public bool? is_Part_Edi_Active { get { return _is_Part_Edi_Active; } set { _is_Part_Edi_Active = value; } }
        public bool? is_LCL_Edi_Active { get { return _is_LCL_Edi_Active; } set { _is_LCL_Edi_Active = value; } }
        public int? Berth_Location_ID { get { return _berth_Location_ID; } set { _berth_Location_ID = value; } }
        public bool? Is_Air_EDI_Active { get { return _is_Air_EDI_Active; } set { _is_Air_EDI_Active = value; } }
        public bool? Is_For_Railway { get { return _is_For_Railway; } set { _is_For_Railway = value; } }
        public string TIR_Shed_Code { get { return _tIR_Shed_Code; } set { _tIR_Shed_Code = value; } }
        public bool? Is_Seal_Required { get { return _is_Seal_Required; } set { _is_Seal_Required = value; } }
        public bool? Is_Scan_Required { get { return _is_Scan_Required; } set { _is_Scan_Required = value; } }
        public bool? Is_LCL_OD_Edi_active { get { return _is_LCL_OD_Edi_active; } set { _is_LCL_OD_Edi_active = value; } }
        public DateTime? LCL_OD_Edi_Active_Date { get { return _lCL_OD_Edi_Active_Date; } set { _lCL_OD_Edi_Active_Date = value; } }
        public string Sub_AS_Shed_Code { get { return _sub_AS_Shed_Code; } set { _sub_AS_Shed_Code = value; } }

        #endregion

        #region Methods

        #endregion

        #region public Methods

        public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object>
            {
                {"Shed_Location_ID", Shed_Location_ID},
                {"Collectorate_Code", Collectorate_Code},
                {"Shed_Group_Code", Shed_Group_Code},
                {"Berth", Berth},
                {"SHDSRL", SHDSRL},
                {"Shed_Name", Shed_Name},
                {"Collectorate_ID", Collectorate_ID},
                {"Group_Type", Group_Type},
                {"Entry_Date", Entry_Date},
                {"IsActive", IsActive},
                {"AS_Shed_Code", AS_Shed_Code},
                {"Is_EDI_Active", Is_EDI_Active},
                {"AS_SHED_CODE_EXPORT", AS_SHED_CODE_EXPORT},
                {"is_Part_Edi_Active", is_Part_Edi_Active},
                {"is_LCL_Edi_Active", is_LCL_Edi_Active},
                {"Berth_Location_ID", Berth_Location_ID},
                {"Is_Air_EDI_Active", Is_Air_EDI_Active},
                {"Is_For_Railway", Is_For_Railway},
                {"TIR_Shed_Code", TIR_Shed_Code},
                {"Is_Seal_Required", Is_Seal_Required},
                {"Is_Scan_Required", Is_Scan_Required},
                {"Is_LCL_OD_Edi_active", Is_LCL_OD_Edi_active},
                {"LCL_OD_Edi_Active_Date", LCL_OD_Edi_Active_Date},
                {"Sub_AS_Shed_Code", Sub_AS_Shed_Code}
            };
        }

        #endregion

        #region Constructors

        #endregion
    }
}

